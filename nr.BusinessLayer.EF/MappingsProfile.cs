using AutoMapper;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.BusinessLayer.Dto.Operators;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using nr.BusinessLayer.EF.DataLayer.Entities.Operators;

namespace nr.BusinessLayer.EF
{
    internal class MappingsProfile : Profile
    {
        public MappingsProfile() {
            #region Users
            CreateMap<UserEntity, UserDto>()
                .ForMember(d => d.Roles, m => m.MapFrom(s => s.Roles.Select(r => r.Role.RoleName)))
                .ForMember(d => d.Password, m => m.Ignore())
                ;
            #endregion

            #region Addresses
            CreateMap<AddressEntity, AddressDto>()
                .IncludeAllDerived()
                ;
            CreateMap<EmailAddressEntity, EmailAddressDto>()
                ;
            CreateMap<PhoneNumberAddressEntity, PhoneNumberAddressDto>()
                ;
            CreateMap<PostalAddressEntity, PostalAddressDto>()
                ;

            CreateMap<AddressDto, AddressEntity>()
                .IncludeAllDerived()
                ;
            CreateMap<EmailAddressDto, EmailAddressEntity>()
                ;
            CreateMap<PhoneNumberAddressDto, PhoneNumberAddressEntity>()
                ;
            CreateMap<PostalAddressDto, PostalAddressEntity>()
                ;
            #endregion

            #region Customers
            CreateMap<CustomerDto, CustomerEntity>()
                .IncludeAllDerived()
                .ForMember(d => d.Addresses, m => m.Ignore())
                ;
            CreateMap<CompanyDto, CompanyEntity>()
                            ;
            CreateMap<PersonDto, PersonEntity>()
                ;

            CreateMap<CustomerEntity, CustomerDto>()
                .IncludeAllDerived()
                ;
            CreateMap<CompanyEntity, CompanyDto>()
                            ;
            CreateMap<PersonEntity, PersonDto>()
                ;
            #endregion
        }
    }
}
