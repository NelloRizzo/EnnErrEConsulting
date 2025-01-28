
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Customers;

namespace nr.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService, IMapper mapper, ILogger<ApiControllerBase> logger) : ApiControllerBase()
    {
        [HttpPost("person")]
        public async Task<Results<IResult, Ok<PersonDto>>> RegisterPerson([FromBody] PersonModel personModel) {
            if (ModelState.IsValid)
                try {
                    var person = await customerService.RegisterAsync(mapper.Map<PersonDto>(personModel));
                    var result = mapper.Map<PersonModel>(person);
                    return TypedResults.Ok(result);
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception registering person");
                }
            return TypedResults.BadRequest();
        }

        [HttpPost("company")]
        public async Task<Results<IResult, Ok<CompanyModel>>> RegisterCompany([FromBody] CompanyModel companyModel) {
            if (ModelState.IsValid) {
                var company = mapper.Map<CompanyDto>(companyModel);
                await customerService.RegisterAsync(company);
                return TypedResults.Ok(companyModel);
            }
            return TypedResults.BadRequest();
        }
    }
}
