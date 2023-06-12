﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using SwordLMS.Web.Models;

#nullable disable

namespace SwordLMS.Web.Migrations
{
    [DbContext(typeof(SwordLmsContext))]
    partial class SwordLmsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SwordLMS.Web.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.ContentType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("ContentType", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK_Country_1");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfPublish")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DisplayImagePath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("DurationInMins")
                        .HasColumnType("int");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double?>("Ratings")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentPath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("ContentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DurationInMins")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentTypeId");

                    b.HasIndex("TopicId");

                    b.ToTable("CourseContent", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CourseReview", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Course_Skills");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CourseSkills");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DurationInMins")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK_CourseTopics");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseTopic", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.FeedBack", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("FeedBack1")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("FeedBack");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("FeedBack", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id")
                        .HasName("PK_State_1");

                    b.HasIndex("CountryId");

                    b.ToTable("State", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("City")
                        .HasColumnType("int");

                    b.Property<int?>("Country")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_User_1");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.UserContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WatchedDuration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserContent", (string)null);
                });

            modelBuilder.Entity("SwordLMS.Web.Models.UserCourse", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfEnroll")
                        .HasColumnType("date");

                    b.Property<bool?>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("WatchedDuration")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.City", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .IsRequired()
                        .HasConstraintName("FK_City_State");

                    b.Navigation("State");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseContent", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.ContentType", "ContentType")
                        .WithMany("CourseContents")
                        .HasForeignKey("ContentTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_CourseContent_Course");

                    b.HasOne("SwordLMS.Web.Models.CourseTopic", "Topic")
                        .WithMany("CourseContents")
                        .HasForeignKey("TopicId")
                        .IsRequired()
                        .HasConstraintName("FK_CourseContent_CourseType");

                    b.Navigation("ContentType");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseReview", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.Course", "IdNavigation")
                        .WithOne("CourseReview")
                        .HasForeignKey("SwordLMS.Web.Models.CourseReview", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_CourseReview_Course");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseSkill", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.Course", "Course")
                        .WithOne("CourseSkill")
                        .HasForeignKey("SwordLMS.Web.Models.CourseSkill", "CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_CourseSkills_Course");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseTopic", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.Course", "Course")
                        .WithMany("CourseTopics")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_CourseTopics_Course");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.FeedBack", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_FeedBack_Course");

                    b.HasOne("SwordLMS.Web.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_FeedBack_User");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Skill", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.SubCategory", "SubCategory")
                        .WithMany("Skills")
                        .HasForeignKey("SubCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Skills_SubCategory");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.State", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_State_Country");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.SubCategory", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_SubCategory_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.User", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.UserContent", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.CourseContent", "Content")
                        .WithMany("UserContents")
                        .HasForeignKey("ContentId")
                        .IsRequired()
                        .HasConstraintName("FK_UserContent_Course");

                    b.HasOne("SwordLMS.Web.Models.User", "User")
                        .WithMany("UserContents")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserContent_User");

                    b.Navigation("Content");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.UserCourse", b =>
                {
                    b.HasOne("SwordLMS.Web.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_UserCourses_Courses");

                    b.HasOne("SwordLMS.Web.Models.User", "User")
                        .WithOne("UserCourse")
                        .HasForeignKey("SwordLMS.Web.Models.UserCourse", "UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserCourses_User");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.ContentType", b =>
                {
                    b.Navigation("CourseContents");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Course", b =>
                {
                    b.Navigation("CourseReview");

                    b.Navigation("CourseSkill");

                    b.Navigation("CourseTopics");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseContent", b =>
                {
                    b.Navigation("UserContents");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.CourseTopic", b =>
                {
                    b.Navigation("CourseContents");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.SubCategory", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("SwordLMS.Web.Models.User", b =>
                {
                    b.Navigation("UserContents");

                    b.Navigation("UserCourse");
                });
#pragma warning restore 612, 618
        }
    }
}