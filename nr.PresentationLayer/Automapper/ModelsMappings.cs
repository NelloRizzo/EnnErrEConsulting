using AutoMapper;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.PresentationLayer.Controllers.Api.Models.Customers;
using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;

namespace nr.PresentationLayer.Automapper
{
    public class ModelsMappings : Profile
    {
        public ModelsMappings() {
            CreateMap<PersonModel, PersonDto>()
                .ForMember(d => d.Addresses, m => m.MapFrom(s => s.AdditionalAddresses))
                ;
            CreateMap<PersonDto, PersonModel>()
                .ForMember(d => d.AdditionalAddresses, m => m.MapFrom(s => s.Addresses))
                ;

            #region Addresses            
            CreateMap<AddressModel, AddressDto>()
                .IncludeAllDerived()
                ;
            CreateMap<PostalAddressModel, PostalAddressDto>()
                .IncludeBase<AddressModel, AddressDto>()
                ;
            CreateMap<EmailAddressModel, EmailAddressDto>()
                .IncludeBase<AddressModel, AddressDto>()
                ;
            CreateMap<PhoneNumberAddressModel, PhoneNumberAddressDto>()
                .IncludeBase<AddressModel, AddressDto>()
                ;

            CreateMap<AddressDto, AddressModel>()
                .IncludeAllDerived()
                ;
            CreateMap<PostalAddressDto, PostalAddressModel>()
                .IncludeBase<AddressDto, AddressModel>()
                .ForMember(d => d.Type, m => m.MapFrom(s => "PostalAddressModel"))
                ;
            CreateMap<EmailAddressDto, EmailAddressModel>()
                .IncludeBase<AddressDto, AddressModel>()
                .ForMember(d => d.Type, m => m.MapFrom(s => "EmailAddressModel"))
                ;
            CreateMap<PhoneNumberAddressDto, PhoneNumberAddressModel>()
                .IncludeBase<AddressDto, AddressModel>()
                .ForMember(d => d.Type, m => m.MapFrom(s => "PhoneNumberAddressModel"))
                ;
            #endregion

        }
    }
}
