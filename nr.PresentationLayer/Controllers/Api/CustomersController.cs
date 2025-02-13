
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Customers;
using System.Net.Mime;

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
    public class CustomersController(ICustomerService customerService, IMapper mapper, ILogger<ApiControllerBase> logger) : ApiControllerBase()
    {
        const string CREATED_AT_ROUTE = $"{nameof(CustomersController)}_{nameof(GetCustomerById)}";

        /// <summary>
        /// Registra una persona.
        /// </summary>
        /// <param name="personModel">Dati da inserire.</param>
        [HttpPost("person")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PersonModel), StatusCodes.Status201Created, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Text.Plain)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<InternalServerError, BadRequest<string>, CreatedAtRoute<PersonModel>>> RegisterPerson([FromBody] PersonModel personModel) {
            if (ModelState.IsValid)
                try {
                    var person = await customerService.RegisterAsync(mapper.Map<PersonDto>(personModel));
                    var result = mapper.Map<PersonModel>(person);
                    return TypedResults.CreatedAtRoute(result, CREATED_AT_ROUTE, new { customerId = person.Id });
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception registering person");
                    return TypedResults.InternalServerError();
                }
            return TypedResults.BadRequest("Invalid model");
        }

        /// <summary>
        /// Registra un'azienda.
        /// </summary>
        /// <param name="companyModel">Dati da inserire.</param>
        [HttpPost("company")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CompanyModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Text.Plain)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<BadRequest<string>, InternalServerError, CreatedAtRoute<CompanyModel>>> RegisterCompany([FromBody] CompanyModel companyModel) {
            if (ModelState.IsValid)
                try {
                    var company = await customerService.RegisterAsync(mapper.Map<CompanyDto>(companyModel));
                    var result = mapper.Map<CompanyModel>(company);
                    return TypedResults.CreatedAtRoute(result, CREATED_AT_ROUTE, new { customerId = company.Id });
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception registering company");
                    return TypedResults.InternalServerError();
                }
            return TypedResults.BadRequest("Invalid model");
        }
        /// <summary>
        /// Recupera tutti i clienti.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<InternalServerError, Ok<IEnumerable<CustomerModel>>>> GetAllCustomers() {
            try {
                var result = await customerService.GetAllAsync();
                return TypedResults.Ok(mapper.Map<IEnumerable<CustomerModel>>(result));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving all customers");
                return TypedResults.InternalServerError();
            }
        }
        /// <summary>
        /// Recupera tutti i clienti tramite una parte dell'email.
        /// </summary>
        [HttpPost("by/email")]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<InternalServerError, Ok<IEnumerable<CustomerModel>>>> GetAllCustomersByEmail([FromBody] SearchByEmailModel model) {
            try {
                var result = await customerService.GetAllByEmailContainsAsync(model.Email);
                return TypedResults.Ok(mapper.Map<IEnumerable<CustomerModel>>(result));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving all customers by email {}", model.Email);
                return TypedResults.InternalServerError();
            }
        }
        /// <summary>
        /// Recupera tutti i clienti tramite una parte di città e/o provincia.
        /// </summary>
        [HttpPost("by/city")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<InternalServerError, Ok<IEnumerable<CustomerModel>>>> GetAllCustomersByCity([FromBody] SearchByCityModel model) {
            try {
                var result = await customerService.GetAllByCityAndProvinceAsync(model.City, model.Province);
                return TypedResults.Ok(mapper.Map<IEnumerable<CustomerModel>>(result));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving all customers by city {} and province {}", model.City, model.Province);
                return TypedResults.InternalServerError();
            }
        }
        /// <summary>
        /// Recupera tutti i clienti tramite una parte del nome.
        /// </summary>
        [HttpPost("by/name")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<InternalServerError, Ok<IEnumerable<CustomerModel>>>> GetAllCustomersByName([FromBody] SearchByNameModel model) {
            try {
                var result = await customerService.GetAllByNameContainsAsync(model.Name);
                return TypedResults.Ok(mapper.Map<IEnumerable<CustomerModel>>(result));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving all customers by name {}", model.Name);
                return TypedResults.InternalServerError();
            }
        }

        [HttpGet("{customerId}", Name = CREATED_AT_ROUTE)]
        [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<Ok<CustomerModel>, InternalServerError>> GetCustomerById([FromRoute] int customerId) {
            try {
                var customer = await customerService.GetByIdAsync(customerId);
                return TypedResults.Ok(mapper.Map<CustomerModel>(customer));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving customer by id {}", customerId);
                return TypedResults.InternalServerError();
            }
        }
    }
}
