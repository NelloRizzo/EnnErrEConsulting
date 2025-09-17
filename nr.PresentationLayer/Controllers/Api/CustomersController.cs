
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Customers;

namespace nr.PresentationLayer.Controllers.Api
{
    /// <summary>
    /// Endpoint API per la gestione dei clienti.
    /// </summary>
    /// <param name="customerService">Servizio di gestione dei clienti.</param>
    /// <param name="mapper">Mapper di AutoMapper.</param>
    /// <param name="logger">Logger.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService, IMapper mapper) : ApiControllerBase()
    {
        const string CREATED_AT_ROUTE = $"{nameof(CustomersController)}_{nameof(GetCustomerById)}";

        /// <summary>
        /// Registra una persona.
        /// </summary>
        /// <param name="personModel">Dati da inserire.</param>
        [HttpPost("person")]
        public async Task<CreatedAtRoute<PersonModel>> RegisterPerson([FromBody] PersonModel personModel) {
            var person = await customerService.RegisterAsync(mapper.Map<PersonDto>(personModel));
            var result = mapper.Map<PersonModel>(person);
            return TypedResults.CreatedAtRoute(result, CREATED_AT_ROUTE, new { customerId = person.Id });
        }

        /// <summary>
        /// Registra un'azienda.
        /// </summary>
        /// <param name="companyModel">Dati da inserire.</param>
        [HttpPost("company")]
        public async Task<CreatedAtRoute<CompanyModel>> RegisterCompany([FromBody] CompanyModel companyModel) {
            var company = await customerService.RegisterAsync(mapper.Map<CompanyDto>(companyModel));
            var result = mapper.Map<CompanyModel>(company);
            return TypedResults.CreatedAtRoute(result, CREATED_AT_ROUTE, new { customerId = company.Id });
        }
        /// <summary>
        /// Recupera tutti i clienti.
        /// </summary>
        [HttpGet]
        public async Task<Ok<IEnumerable<CustomerModel>>> GetAllCustomers() {
            var result = await customerService.GetAllAsync();
            return TypedResults.Ok(mapper.Map<IEnumerable<CustomerModel>>(result));
        }
        /// <summary>
        /// Recupera tutti i clienti tramite una parte dell'email.
        /// </summary>
        [HttpPost("by/email")]
        public async Task<Ok<IEnumerable<CustomerModel>>> GetAllCustomersByEmail([FromBody] SearchByEmailModel model) {
            var result = await customerService.GetAllByEmailContainsAsync(model.Email);
            return TypedResults.Ok(mapper.Map<IEnumerable<CustomerModel>>(result));
        }
        /// <summary>
        /// Recupera tutti i clienti tramite una parte di città e/o provincia.
        /// </summary>
        [HttpPost("by/city")]
        public async Task<Ok<IEnumerable<CustomerModel>>> GetAllCustomersByCity([FromBody] SearchByCityModel model) {
            var result = await customerService.GetAllByCityAndProvinceAsync(model.City, model.Province);
            return TypedResults.Ok(mapper.Map<IEnumerable<CustomerModel>>(result));
        }
        /// <summary>
        /// Recupera tutti i clienti tramite una parte del nome.
        /// </summary>
        [HttpPost("by/name")]
        public async Task<Ok<IEnumerable<CustomerModel>>> GetAllCustomersByName([FromBody] SearchByNameModel model) {
            var result = await customerService.GetAllByNameContainsAsync(model.Name);
            return TypedResults.Ok(mapper.Map<IEnumerable<CustomerModel>>(result));
        }

        [HttpGet("{customerId}", Name = CREATED_AT_ROUTE)]
        public async Task<Ok<CustomerModel>> GetCustomerById([FromRoute] int customerId) {
            var customer = await customerService.GetByIdAsync(customerId);
            return TypedResults.Ok(mapper.Map<CustomerModel>(customer));
        }
    }
}
