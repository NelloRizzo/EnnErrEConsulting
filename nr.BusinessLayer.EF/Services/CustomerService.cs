using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using nr.BusinessLayer.Services;
using nr.BusinessLayer.Services.Exceptions;
using nr.Validation;
using System.Net.Mail;

namespace nr.BusinessLayer.EF.Services
{
    /// <inheritdoc/>
    public class CustomerService(ILogger<Service> logger, ApplicationDBContext context) : Service(), ICustomerService
    {
        /// <inheritdoc/>
        public async Task<CustomerDto> AddAddressAsync(int customerId, AddressDto addressDto) {
            try {
                if (!addressDto.IsValid()) throw new InvalidDtoException { InvalidDto = addressDto };
                var customer = await context.Customers.SingleOrDefaultAsync(c => c.Id == customerId) ?? throw new EntityNotFoundException { SearchedKey = customerId, SearchedType = typeof(CustomerDto) };
                var address = mapper.Map<AddressEntity>(addressDto);
                customer.Addresses.Add(address);
                await context.SaveChangesAsync();
                return mapper.Map<CustomerDto>(customer);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception adding address {} for customer {}", addressDto, customerId);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CustomerDto>> GetAllAsync() {
            try {
                return mapper.Map<IEnumerable<CustomerDto>>(await context.Customers.ToListAsync());
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all customers");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CustomerDto>> GetAllByCityAndProvinceAsync(string? city, string? province) {
            try {
                var result = await context.Customers.Include(c => c.BusinessAddress).Include(c => c.Addresses)
                    .Where(c =>
                        ((city == null || c.BusinessAddress.City.Contains(city)) && (province == null || c.BusinessAddress.Region.Contains(province)))
                        || c.Addresses.OfType<PostalAddressEntity>().Any(
                            a => (city == null || a.City.Contains(city)) && (province == null || a.Region.Contains(province)))
                        ).ToListAsync();
                return mapper.Map<IEnumerable<CustomerDto>>(result);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all customers by city {} and province {}", city, province);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CustomerDto>> GetAllByEmailContainsAsync(string email) {
            try {
                var companies = mapper.Map<IEnumerable<CustomerDto>>(await context.Companies.Where(c => c.Pec.Contains(email)).ToListAsync());
                var others = mapper.Map<IEnumerable<CustomerDto>>(await context.Customers.Include(p => p.Addresses).Where(p => p.Addresses.OfType<EmailAddressEntity>().Any(e => e.Email.Contains(email))).ToListAsync());
                return companies.Union(others);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all customers by email {}", email);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CustomerDto>> GetAllByNameContainsAsync(string name) {
            try {
                IQueryable<CustomerEntity> companies = context.Companies.Where(c => c.CompanyName.Contains(name));
                IQueryable<CustomerEntity> people = context.People.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name) || (p.Nickname != null && p.Nickname.Contains(name)));
                var result = await companies.Union(people).ToListAsync();
                return mapper.Map<IEnumerable<CustomerDto>>(result);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all customers by name {}", name);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<CustomerDto?> GetByIdAsync(int id) {
            try {
                return mapper.Map<CustomerDto?>(await context.Customers.FindAsync(id));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving customer by id {}", id);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CustomerDto>> GetCompaniesAsync() {
            try {
                return mapper.Map<IEnumerable<CustomerDto>>(await context.Companies.ToListAsync());
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all companies");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CustomerDto>> GetPeopleAsync() {
            try {
                return mapper.Map<IEnumerable<CustomerDto>>(await context.People.ToListAsync());
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all people");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<CustomerDto> RemoveAddressAsync(int customerId, int addressId) {
            try {
                var customer = await context.Customers.SingleOrDefaultAsync(c => c.Id == customerId) ?? throw new EntityNotFoundException { SearchedKey = customerId, SearchedType = typeof(CustomerDto) };
                var address = customer.Addresses.SingleOrDefault(a => a.Id == addressId) ?? throw new EntityNotFoundException { SearchedKey = addressId, SearchedType = typeof(AddressDto) };
                customer.Addresses.Remove(address);
                await context.SaveChangesAsync();
                return mapper.Map<CustomerDto>(customer);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception removing address with id {} for customer with id {}", addressId, customerId);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<PersonDto> RegisterAsync(PersonDto personDto) {
            try {
                if (!personDto.IsValid()) throw new InvalidDtoException { InvalidDto = personDto };
                var person = mapper.Map<PersonEntity>(personDto);
                var trans = await context.Database.BeginTransactionAsync();
                foreach (var address in personDto.Addresses.Select(mapper.Map<AddressEntity>))
                    person.Addresses.Add(address);
                context.Customers.Add(person);
                await context.SaveChangesAsync();
                await trans.CommitAsync();
                return mapper.Map<PersonDto>(person);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception registering person {}", personDto);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<CompanyDto> RegisterAsync(CompanyDto companyDto) {
            try {
                if (!companyDto.IsValid()) throw new InvalidDtoException { InvalidDto = companyDto };
                var company = mapper.Map<CompanyEntity>(companyDto);
                var trans = await context.Database.BeginTransactionAsync();
                foreach (var address in companyDto.Addresses.Select(mapper.Map<AddressEntity>))
                    company.Addresses.Add(address);
                context.Customers.Add(company);
                await context.SaveChangesAsync();
                await trans.CommitAsync();
                return mapper.Map<CompanyDto>(company);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception registering company {}", companyDto);
                throw new ServiceException(innerException: ex);
            }
        }
    }
}
