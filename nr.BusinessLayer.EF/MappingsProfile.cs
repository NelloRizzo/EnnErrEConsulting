using AutoMapper;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.BusinessLayer.Dto.Operators;
using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using nr.BusinessLayer.EF.DataLayer.Entities.Operators;

namespace nr.BusinessLayer.EF
{
    /// <summary>
    /// Profili per AutoMapper da Entity a Dto e viceversa.
    /// </summary>
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

            #region Courses
            CreateMap<CourseDto, CourseEntity>()
                .ForMember(d => d.StandardDuration, m => m.MapFrom(s => s.StandardDuration.HasValue ? s.StandardDuration.Value.Hours : 0))
                ;
            CreateMap<CourseEntity, CourseDto>()
                .ForMember(d => d.StandardDuration, m => m.MapFrom(s => TimeSpan.FromHours(s.StandardDuration ?? 0)))
                ;
            #endregion
        }
    }
}
