using AutoMapper;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.PresentationLayer.Controllers.Api.Models.Courses;
using nr.PresentationLayer.Controllers.Api.Models.Customers;
using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;
using nr.Utils;

namespace nr.PresentationLayer.Automapper
{
    /// <summary>
    /// Profili di mapping da Model a Dto e viceversa.
    /// </summary>
    public class ModelsMappings : Profile
    {
        public ModelsMappings() {
            #region Customers
            CreateMap<CustomerModel, CustomerDto>()
                .IncludeAllDerived()
                .ForMember(d => d.Addresses, m => m.MapFrom(s => s.AdditionalAddresses))
                ;
            CreateMap<CustomerDto, CustomerModel>()
                .IncludeAllDerived()
                .ForMember(d => d.AdditionalAddresses, m => m.MapFrom(s => s.Addresses))
                ;

            CreateMap<PersonModel, PersonDto>()
                ;
            CreateMap<PersonDto, PersonModel>()
                .ForMember(d => d.Type, m => m.MapFrom(s => PersonModel.ModelType))
                ;

            CreateMap<CompanyModel, CompanyDto>()
                ;
            CreateMap<CompanyDto, CompanyModel>()
                .ForMember(d => d.Type, m => m.MapFrom(s => CompanyModel.ModelType))
                ;
            #endregion

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

            CreateMap<string, EmailAddressModel>()
                .ForMember(d => d.Email, m => m.MapFrom(s => new EmailAddressModel { Email = s }))
                ;
            CreateMap<EmailAddressModel, string>()
                .ConstructUsing((s, ctx) => s.Email)
                ;

            CreateMap<AddressDto, AddressModel>()
                .IncludeAllDerived()
                ;
            CreateMap<PostalAddressDto, PostalAddressModel>()
                .IncludeBase<AddressDto, AddressModel>()
                .ForMember(d => d.Type, m => m.MapFrom(s => PostalAddressModel.ModelType))
                ;
            CreateMap<EmailAddressDto, EmailAddressModel>()
                .IncludeBase<AddressDto, AddressModel>()
                .ForMember(d => d.Type, m => m.MapFrom(s => EmailAddressModel.ModelType))
                ;
            CreateMap<PhoneNumberAddressDto, PhoneNumberAddressModel>()
                .IncludeBase<AddressDto, AddressModel>()
                .ForMember(d => d.Type, m => m.MapFrom(s => PhoneNumberAddressModel.ModelType))
                ;
            #endregion

            #region Courses
            CreateMap<NewCourseModel, CourseDto>()
                .ForMember(d => d.StandardDuration, m => m.MapFrom(s => TimeSpan.FromHours(s.StandardDurationHours ?? 0)))
                .ForMember(d => d.Topics, m => m.Ignore())
                ;
            
            CreateMap<CourseDto, CourseModel>()
                .ForMember(d => d.StandardDurationHours, m => m.MapFrom(s => s.StandardDuration.HasValue ? s.StandardDuration.Value.TotalHours : 0))
                .ForMember(d => d.Abstract, m => m.MapFrom(s => s.Abstract ?? s.Description.Abstract(255)))
                ;
            CreateMap<CourseModel, CourseDto>()
                .ForMember(d => d.StandardDuration, m => m.MapFrom(s => TimeSpan.FromHours(s.StandardDurationHours ?? 0)))
                ;
            #endregion

            #region Topics
            CreateMap<NewTopicModel, TopicDto>()
                .ForMember(d => d.StandardDuration, m => m.MapFrom(s => TimeSpan.FromHours(s.StandardDurationHours ?? 0)))
                ;
            CreateMap<TopicDto, TopicModel>()
                .ForMember(d => d.StandardDurationHours, m => m.MapFrom(s => s.StandardDuration.HasValue ? s.StandardDuration.Value.TotalHours : 0))
                ;
            CreateMap<TopicDto, NewTopicModel>()
                .ForMember(d => d.StandardDurationHours, m => m.MapFrom(s => s.StandardDuration.HasValue ? s.StandardDuration.Value.TotalHours : 0))
                ;
            #endregion
        }
    }
}
