using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nr.BusinessLayer.Dto.Operators;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace nr.PresentationLayer.Controllers.Api
{
    /// <summary>
    /// Endpoint API per la gestione degli utenti.
    /// </summary>
    /// <param name="userService">Servizio di gestione degli utenti.</param>
    /// <param name="configuration">Gestore della configurazione.</param>
    /// <param name="logger">Logger.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService, IConfiguration configuration, ILogger<UsersController> logger) : ApiControllerBase()
    {
        /// <summary>
        /// Genera il token JWT.
        /// </summary>
        /// <param name="user">Dati dell'utente.</param>
        /// <returns>Il token JWT.</returns>
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

        /// <summary>
        /// Gestisce il login di un utente.
        /// </summary>
        /// <param name="loginModel">Dati di login.</param>
        [HttpPost("login")]
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Missing))]
        public async Task<Results<InternalServerError, UnauthorizedHttpResult, Ok<TokenModel>>> LoginUser([FromBody] LoginModel loginModel) {
            try {
                var user = await userService.LoginUserAsync(loginModel.Username, loginModel.Password);
                if (user == null) return TypedResults.Unauthorized();
                var token = GenerateJwtToken(user);
                return TypedResults.Ok(new TokenModel { Token = token, Username = user.Email, Roles = user.Roles });
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception logging user");
                return TypedResults.InternalServerError();
            }
        }

        /// <summary>
        /// Gestisce la registrazione di un utente.
        /// </summary>
        /// <param name="userModel">Dati dell'utente.</param>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Missing))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<BadRequest, InternalServerError, Ok<UserModel>>> RegisterUser([FromBody] RegisterUserModel userModel) {
            if (ModelState.IsValid)
                try {
                    var user = await userService.RegisterUserAsync(new UserDto { Email = userModel.Email, Password = userModel.Password, Roles = userModel.Roles?.Split(' ', ',').Select(r => r.Trim()) ?? [] });
                    return TypedResults.Ok(new UserModel { Email = user!.Email, Roles = string.Join(',', user.Roles) });
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception registering user");
                    return TypedResults.InternalServerError();
                }
            logger.LogError("Invalid model: \n{}", string.Join("", ModelState.Select(e => $"\t{e.Key} -> {e.Value}\n")));
            return TypedResults.BadRequest();
        }

        /// <summary>
        /// Ottiene l'elenco di tutti gli utenti.
        /// </summary>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<InternalServerError, Ok<IEnumerable<UserModel>>>> GetUsers() {
            try {
                var users = await userService.GetUsersAsync();
                return TypedResults.Ok(users.Select(u => new UserModel { Email = u.Email, Roles = string.Join(',', u.Roles) }));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting users");
                return TypedResults.InternalServerError();
            }
        }
    }
}
