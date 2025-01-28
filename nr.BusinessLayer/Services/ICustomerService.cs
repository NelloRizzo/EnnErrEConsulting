using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;

namespace nr.BusinessLayer.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<IEnumerable<CustomerDto>> GetAllByNameAsync(string name);
        Task<IEnumerable<CustomerDto>> GetAllByCityAndProvinceAsync(string city, string province);
        Task<IEnumerable<CustomerDto>> GetAllByEmailAsync(string email);
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task<IEnumerable<CustomerDto>> GetPeopleAsync();

        Task<PersonDto> RegisterAsync(PersonDto personDto);
        Task<CompanyDto> RegisterAsync(CompanyDto companyDto);
        Task<CustomerDto?> GetByIdAsync(int id);
        Task<CustomerDto> AddAddressAsync(int customerId, AddressDto address);
        Task<CustomerDto> RemoveAddressAsync(int customerId, AddressDto address);
    }
}
