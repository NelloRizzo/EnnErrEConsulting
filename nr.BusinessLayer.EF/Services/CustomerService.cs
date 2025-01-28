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
    /// <inheritdoc/>
    public class CustomerService(ILogger<Service> logger, ApplicationDBContext context) : Service(), ICustomerService
    {
        /// <inheritdoc/>
        public Task<CustomerDto> AddAddressAsync(int customerId, AddressDto address) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CustomerDto>> GetAllAsync() {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CustomerDto>> GetAllByCityAndProvinceAsync(string? city, string? province) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CustomerDto>> GetAllByEmailContainsAsync(string email) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CustomerDto>> GetAllByNameContainsAsync(string name) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CustomerDto?> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CustomerDto>> GetCustomersAsync() {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<CustomerDto>> GetPeopleAsync() {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<CustomerDto> RemoveAddressAsync(int customerId, int addressId) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task<CompanyDto> RegisterAsync(CompanyDto companyDto) {
            try {
                var company = mapper.Map<CompanyEntity>(companyDto);
                var trans = await context.Database.BeginTransactionAsync();
                foreach (var address in companyDto.Addresses.Select(mapper.Map<AddressEntity>))
                    company.Addresses.Add(address);
                context.Customers.Add(company);
                await context.SaveChangesAsync();
                await trans.CommitAsync();
                return mapper.Map<CompanyDto>(company);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception registering company");
                throw new ServiceException(innerException: ex);
            }
        }
    }
}
