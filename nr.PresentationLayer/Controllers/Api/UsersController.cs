using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nr.BusinessLayer.Dto.Operators;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace nr.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService, IConfiguration configuration, ILogger<UsersController> logger) : ApiControllerBase()
    {
        protected IUserService _userService = userService;
        private string GenerateJwtToken(UserDto user) {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = user.Roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("login")]
        public async Task<Results<IResult, Ok<TokenModel>>> LoginUser([FromBody] LoginModel loginModel) {
            try {
                var user = await _userService.LoginUserAsync(loginModel.Username, loginModel.Password);
                if (user == null) return TypedResults.Unauthorized();
                var token = GenerateJwtToken(user);
                return TypedResults.Ok(new TokenModel { Token = token, Username = user.Email, Roles = user.Roles });
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception logging user");
                return TypedResults.BadRequest();
            }
        }
        [HttpPost]
        public async Task<Results<IResult, Ok<UserModel>>> RegisterUser([FromBody] RegisterUserModel model) {
            try {
                if (ModelState.IsValid)
                    try {
                        var user = await _userService.RegisterUserAsync(new UserDto { Email = model.Email, Password = model.Password, Roles = model.Roles?.Split(' ', ',').Select(r => r.Trim()) ?? [] });
                        return TypedResults.Ok(new UserModel { Email = user!.Email, Roles = string.Join(',', user.Roles) });
                    }
                    catch (Exception ex) {
                        logger.LogError(ex, "Exception registering user");
                        return TypedResults.InternalServerError();
                    }
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception registering user");
                return TypedResults.BadRequest();
            }
            logger.LogError("Invalid model: \n{}", string.Join("", ModelState.Select(e => $"\t{e.Key} -> {e.Value}\n")));
            return TypedResults.BadRequest("Invalid model");
        }

        [HttpGet]
        public async Task<Results<IResult, Ok<IEnumerable<UserModel>>>> GetUsers() {
            try {
                var users = await _userService.GetUsersAsync();
                return TypedResults.Ok(users.Select(u => new UserModel { Email = u.Email, Roles = string.Join(',', u.Roles) }));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting users");
                return TypedResults.InternalServerError();
            }
        }
    }
}
