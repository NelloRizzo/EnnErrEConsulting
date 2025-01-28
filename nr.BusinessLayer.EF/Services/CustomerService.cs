using Microsoft.Extensions.Logging;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using nr.BusinessLayer.Services;
using nr.BusinessLayer.Services.Exceptions;

namespace nr.BusinessLayer.EF.Services
{
    public class CustomerService(ILogger<Service> logger, ApplicationDBContext context) : Service(logger, context), ICustomerService
    {
        public Task<CustomerDto> AddAddressAsync(int customerId, AddressDto address) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetAllByCityAndProvinceAsync(string city, string province) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetAllByEmailAsync(string email) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetAllByNameAsync(string name) {
            throw new NotImplementedException();
        }

        public Task<CustomerDto?> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetCustomersAsync() {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetPeopleAsync() {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> RemoveAddressAsync(int customerId, AddressDto address) {
            throw new NotImplementedException();
        }

        public async Task<PersonDto> RegisterAsync(PersonDto personDto) {
            try {
                var person = mapper.Map<PersonEntity>(personDto);
                var trans = await context.Database.BeginTransactionAsync();
                foreach (var address in personDto.Addresses.Select(mapper.Map<AddressEntity>))
                    person.Addresses.Add(address);
                context.Customers.Add(person);
                await context.SaveChangesAsync();
                await trans.CommitAsync();
                return mapper.Map<PersonDto>(person);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception registering person");
                throw new ServiceException(innerException: ex);
            }
        }

        public Task<CompanyDto> RegisterAsync(CompanyDto companyDto) {
            throw new NotImplementedException();
        }
    }
}
