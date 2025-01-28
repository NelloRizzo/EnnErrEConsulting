﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nr.BusinessLayer.EF.DataLayer;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20250128075305_AddedAllAddresses")]
    partial class AddedAllAddresses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("TopicEntityTopicEntity", b =>
                {
                    b.Property<int>("InnerTopicsId")
                        .HasColumnType("int");

                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.HasKey("InnerTopicsId", "TopicsId");

                    b.HasIndex("TopicsId");

                    b.ToTable("TopicEntityTopicEntity");
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

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .IsRequired()
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

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StandardDuration")
                        .HasColumnType("int");

                    b.Property<int?>("TagEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("TagEntityId");

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

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

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

                    b.ToTable("PostalAddresses");
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

            modelBuilder.Entity("TopicEntityTopicEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", null)
                        .WithMany()
                        .HasForeignKey("InnerTopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
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

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.TopicEntity", b =>
                {
                    b.HasOne("nr.BusinessLayer.EF.DataLayer.Entities.Tags.TagEntity", null)
                        .WithMany("Topics")
                        .HasForeignKey("TagEntityId");
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

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Courses.CourseEntity", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Customers.CustomerEntity", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Operators.UserEntity", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("nr.BusinessLayer.EF.DataLayer.Entities.Tags.TagEntity", b =>
                {
                    b.Navigation("Topics");
                });
#pragma warning restore 612, 618
        }
    }
}
