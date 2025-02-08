using AutoMapper;
using nr.BusinessLayer.Dto.Attachments;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.BusinessLayer.Dto.Operators;
using nr.BusinessLayer.Dto.Planning;
using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using nr.BusinessLayer.EF.DataLayer.Entities.Operators;
using nr.BusinessLayer.EF.DataLayer.Entities.Planning;

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
                .ForMember(d => d.Topics, m => m.Ignore())
                ;
            #endregion

            #region Topics
            CreateMap<TopicDto, TopicEntity>()
                .ForMember(d => d.StandardDuration, m => m.MapFrom(s => s.StandardDuration.HasValue ? s.StandardDuration.Value.Hours : 0))
                ;
            CreateMap<TopicEntity, TopicDto>()
                .ForMember(d => d.StandardDuration, m => m.MapFrom(s => new TimeSpan(s.StandardDuration ?? 0)))
                ;
            #endregion

            #region Attachments
            CreateMap<AttachmentDto, AttachmentEntity>()
                .IncludeAllDerived()
                .ForMember(d => d.LinkId, m => m.MapFrom(s => s.Content.Id))
                .ForMember(d => d.Link, m => m.MapFrom(s => s.Content))
                ;
            CreateMap<AttachmentEntity, AttachmentDto>()
                .IncludeAllDerived()
                .ForMember(d => d.Content, m => m.MapFrom(s => s.Link))
                ;
            CreateMap<AttachmentEntity, AttachmentWithoutContentDto>()
                .IncludeAllDerived()
                .ForMember(d => d.ContentId, m => m.MapFrom(s => s.Link.Id))
                ;
            CreateMap<ContentLinkEntity, ContentLinkDto>()
                .IncludeAllDerived()
                ;
            CreateMap<ContentLinkDto, ContentLinkEntity>()
                .IncludeAllDerived()
                ;
            CreateMap<LinkEntity, LinkDto>()
                .IncludeAllDerived()
                ;
            CreateMap<LinkDto, LinkEntity>()
                .IncludeAllDerived()
                ;
            CreateMap<UrlLinkEntity, UrlLinkDto>()
                .IncludeAllDerived()
                ;
            CreateMap<UrlLinkDto, UrlLinkEntity>()
                .IncludeAllDerived()
                ;
            #endregion

            #region Planning
            CreateMap<PlanDateEntity, PlanDateDto>()
                .ForMember(d => d.EndTime, m => m.MapFrom(s => s.EndTime.Equals(TimeOnly.MinValue) ? new TimeOnly(18, 0) : s.EndTime))
                .ForMember(d => d.StartTime, m => m.MapFrom(s => s.StartTime.Equals(TimeOnly.MinValue) ? new TimeOnly(9, 0) : s.StartTime))
                ;
            CreateMap<PlanDateDto, PlanDateEntity>()
                ;
            CreateMap<CoursePlanEntity, CoursePlanDto>()
                .ReverseMap()
                ;
            #endregion
        }
    }
}
