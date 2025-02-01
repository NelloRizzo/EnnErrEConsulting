
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Customers;
using System.Net.Mime;
using System.Reflection;

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
        /// <summary>
        /// Registra una persona.
        /// </summary>
        /// <param name="personModel">Dati da inserire.</param>
        [HttpPost("person")]
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonModel))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Text.Plain)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<InternalServerError, BadRequest<string>, Ok<PersonModel>>> RegisterPerson([FromBody] PersonModel personModel) {
            if (ModelState.IsValid)
                try {
                    var person = await customerService.RegisterAsync(mapper.Map<PersonDto>(personModel));
                    var result = mapper.Map<PersonModel>(person);
                    return TypedResults.Ok(result);
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
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Missing))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<BadRequest, InternalServerError, Ok<CompanyModel>>> RegisterCompany([FromBody] CompanyModel companyModel) {
            if (ModelState.IsValid)
                try {
                    var company = await customerService.RegisterAsync(mapper.Map<CompanyDto>(companyModel));
                    var result = mapper.Map<CompanyModel>(company);
                    return TypedResults.Ok(result);
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception registering company");
                    return TypedResults.InternalServerError();
                }
            return TypedResults.BadRequest();
        }
        /// <summary>
        /// Recupera tutti i clienti.
        /// </summary>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerModel>))]
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
        [HttpPost("/by/email")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerModel>))]
        [Produces<Ok<IEnumerable<CustomerModel>>>, ProducesErrorResponseType(typeof(BadRequest))]
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
        [HttpPost("/by/city")]
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerModel>))]
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
        [HttpPost("/by/name")]
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerModel>))]
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
    }
}
