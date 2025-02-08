﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nr.BusinessLayer.EF.DataLayer;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AttachmentEntityCourseEntity", b =>
                {
                    b.Property<int>("AttachmentsId")
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.HasKey("AttachmentsId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("AttachmentEntityCourseEntity");
                });

            modelBuilder.Entity("AttachmentEntityTagEntity", b =>
                {
                    b.Property<int>("AttachmentsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("AttachmentsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("AttachmentEntityTagEntity");
                });

            modelBuilder.Entity("AttachmentEntityTopicEntity", b =>
                {
                    b.Property<int>("AttachmentsId")
                        .HasColumnType("int");

                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.HasKey("AttachmentsId", "TopicsId");

                    b.HasIndex("TopicsId");

                    b.ToTable("AttachmentEntityTopicEntity");
                });

            modelBuilder.Entity("CourseEntityTagEntity", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("CourseEntityTagEntity");
                });

            modelBuilder.Entity("TagEntityTopicEntity", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "TopicsId");

                    b.HasIndex("TopicsId");

                    b.ToTable("TagEntityTopicEntity");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.AttachmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.LinkEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Links");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int?>("StandardDuration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseTopicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex(new[] { "CourseId", "TopicId" }, "IDX_TOPIC_COURSE_UNIQUE")
                        .IsUnique();

                    b.ToTable("CoursesTopics");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.InnerTopicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InnerTopicId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InnerTopicId");

                    b.ToTable("InnerTopics");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StandardDuration")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerEntityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBusiness")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerEntityId");

                    b.ToTable("Addresses");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusinessAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusinessAddressId");

                    b.ToTable("Customers");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Operators.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleName" }, "IDX_ROLE_UNIQUE")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Operators.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IDX_USERNAME_UNIQUE")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Operators.UserRoleRelationship", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Planning.CoursePlanEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CoursePlannings");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Planning.PlanDateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoursePlanEntityId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CoursePlanEntityId");

                    b.ToTable("PlanDates");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Tags.TagEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TagName" }, "IDX_TagName_Unique")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.ContentLinkEntity", b =>
                {
                    b.HasBaseType("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.LinkEntity");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasMaxLength(1000000)
                        .HasColumnType("varbinary(max)");

                    b.ToTable("ContentLinks");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.UrlLinkEntity", b =>
                {
                    b.HasBaseType("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.LinkEntity");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasIndex(new[] { "Url" }, "IDX_LINKURL_UNIQUE")
                        .IsUnique()
                        .HasFilter("[Url] IS NOT NULL");

                    b.ToTable("UrlLinks");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.EmailAddressEntity", b =>
                {
                    b.HasBaseType("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.AddressEntity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.PhoneNumberAddressEntity", b =>
                {
                    b.HasBaseType("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.AddressEntity");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.PostalAddressEntity", b =>
                {
                    b.HasBaseType("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.AddressEntity");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("CivicNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Country")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.ToTable("PostalAddresses");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CompanyEntity", b =>
                {
                    b.HasBaseType("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("FiscalCode")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Pec")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Sdi")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("VatCode")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.PersonEntity", b =>
                {
                    b.HasBaseType("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.ToTable("People");
                });

            modelBuilder.Entity("AttachmentEntityCourseEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.AttachmentEntity", null)
                        .WithMany()
                        .HasForeignKey("AttachmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseEntity", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AttachmentEntityTagEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.AttachmentEntity", null)
                        .WithMany()
                        .HasForeignKey("AttachmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Tags.TagEntity", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AttachmentEntityTopicEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.AttachmentEntity", null)
                        .WithMany()
                        .HasForeignKey("AttachmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseEntityTagEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseEntity", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Tags.TagEntity", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TagEntityTopicEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Tags.TagEntity", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.AttachmentEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.LinkEntity", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseTopicEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseEntity", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.InnerTopicEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", "InnerTopic")
                        .WithMany("InnerTopics")
                        .HasForeignKey("InnerTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InnerTopic");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.AddressEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity", null)
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerEntityId");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.PostalAddressEntity", "BusinessAddress")
                        .WithMany()
                        .HasForeignKey("BusinessAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessAddress");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Operators.UserRoleRelationship", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Operators.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Operators.UserEntity", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Planning.CoursePlanEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Planning.PlanDateEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Planning.CoursePlanEntity", null)
                        .WithMany("Dates")
                        .HasForeignKey("CoursePlanEntityId");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.ContentLinkEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.LinkEntity", null)
                        .WithOne()
                        .HasForeignKey("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.ContentLinkEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.UrlLinkEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.LinkEntity", null)
                        .WithOne()
                        .HasForeignKey("nr.BusinessLayer.EF.DataLayer.Entities.Attachments.UrlLinkEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.EmailAddressEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.AddressEntity", null)
                        .WithOne()
                        .HasForeignKey("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.EmailAddressEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.PhoneNumberAddressEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.AddressEntity", null)
                        .WithOne()
                        .HasForeignKey("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.PhoneNumberAddressEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.PostalAddressEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.AddressEntity", null)
                        .WithOne()
                        .HasForeignKey("nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses.PostalAddressEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CompanyEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity", null)
                        .WithOne()
                        .HasForeignKey("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CompanyEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.PersonEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity", null)
                        .WithOne()
                        .HasForeignKey("nr.BusinessLayer.EF.DataLayer.Entities.Customers.PersonEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseEntity", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", b =>
                {
                    b.Navigation("InnerTopics");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Operators.UserEntity", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Planning.CoursePlanEntity", b =>
                {
                    b.Navigation("Dates");
                });
#pragma warning restore 612, 618
        }
    }
}
