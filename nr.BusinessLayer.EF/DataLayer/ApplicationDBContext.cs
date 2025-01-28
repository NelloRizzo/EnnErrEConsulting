using Microsoft.EntityFrameworkCore;
using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using nr.BusinessLayer.EF.DataLayer.Entities.Operators;
using nr.BusinessLayer.EF.DataLayer.Entities.Tags;

namespace nr.BusinessLayer.EF.DataLayer
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
    {
        public virtual DbSet<TagEntity> Tags { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<PersonEntity> People { get; set; }
        public virtual DbSet<CompanyEntity> Companies { get; set; }
        public virtual DbSet<AddressEntity> Addresses { get; set; }
        public virtual DbSet<EmailAddressEntity> EmailAddresses { get; set; }
        public virtual DbSet<PostalAddressEntity> PostalAddresses { get; set; }
        public virtual DbSet<PhoneNumberAddressEntity> PhoneNumbersAddresses { get; set; }
        public virtual DbSet<CourseEntity> Courses { get; set; }
        public virtual DbSet<TopicEntity> Topic { get; set; }
        public virtual DbSet<AttachmentEntity> Attachments { get; set; }
    }
}
