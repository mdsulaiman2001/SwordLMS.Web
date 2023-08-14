//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace SwordLMS.Web.Models;

//public partial class SwordLmsContext : DbContext
//{
//    public SwordLmsContext()
//    {
//    }

//    public SwordLmsContext(DbContextOptions<SwordLmsContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Category> Categories { get; set; }

//    public virtual DbSet<City> Cities { get; set; }

//    public virtual DbSet<ContentType> ContentTypes { get; set; }

//    public virtual DbSet<Country> Countries { get; set; }

//    public virtual DbSet<Course> Courses { get; set; }

//    public virtual DbSet<CourseContent> CourseContents { get; set; }

//    public virtual DbSet<CourseReview> CourseReviews { get; set; }

//    public virtual DbSet<CourseSkill> CourseSkills { get; set; }

//    public virtual DbSet<CourseTopic> CourseTopics { get; set; }

//    public virtual DbSet<FeedBack> FeedBacks { get; set; }

//    public virtual DbSet<Role> Roles { get; set; }

//    public virtual DbSet<Skill> Skills { get; set; }

//    public virtual DbSet<State> States { get; set; }

//    public virtual DbSet<SubCategory> SubCategories { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    public virtual DbSet<UserContent> UserContents { get; set; }

//    public virtual DbSet<UserCourse> UserCourses { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//   => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=SwordLMS;Trusted_Connection=True;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Category>(entity =>
//        {
//            entity.ToTable("Category");

//            entity.Property(e => e.Name).HasMaxLength(40);
//        });

//        modelBuilder.Entity<City>(entity =>
//        {
//            entity.ToTable("City");

//            entity.Property(e => e.Name).HasMaxLength(20);

//            entity.HasOne(d => d.State).WithMany(p => p.Cities)
//                .HasForeignKey(d => d.StateId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_City_State");
//        });

//        modelBuilder.Entity<ContentType>(entity =>
//        {
//            entity.ToTable("ContentType");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Type)
//                .HasMaxLength(10)
//                .IsUnicode(false)
//                .IsFixedLength();
//        });

//        modelBuilder.Entity<Country>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK_Country_1");

//            entity.ToTable("Country");

//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .IsUnicode(false)
//                .IsFixedLength();
//        });

//        modelBuilder.Entity<Course>(entity =>
//        {
//            entity.ToTable("Course");

//            entity.Property(e => e.DateOfPublish).HasColumnType("date");
//            entity.Property(e => e.Description).HasMaxLength(500);
//            entity.Property(e => e.DisplayImagePath).HasMaxLength(500);
//            entity.Property(e => e.Name).HasMaxLength(250);
//        });

//        modelBuilder.Entity<CourseContent>(entity =>
//        {
//            entity.ToTable("CourseContent");

//            entity.Property(e => e.ContentPath)
//                .HasMaxLength(500)
//                .IsUnicode(false);
//            entity.Property(e => e.Name).HasMaxLength(10);

//            entity.HasOne(d => d.ContentType).WithMany(p => p.CourseContents)
//                .HasForeignKey(d => d.ContentTypeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CourseContent_Course");

//            entity.HasOne(d => d.Topic).WithMany(p => p.CourseContents)
//                .HasForeignKey(d => d.TopicId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CourseContent_CourseType");
//        });

//        modelBuilder.Entity<CourseReview>(entity =>
//        {
//            entity.ToTable("CourseReview");

//            entity.Property(e => e.Id).ValueGeneratedOnAdd();
//            entity.Property(e => e.Comments).HasMaxLength(500);

//            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CourseReview)
//                .HasForeignKey<CourseReview>(d => d.Id)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CourseReview_Course");
//        });

//        modelBuilder.Entity<CourseSkill>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK_Course_Skills");

//            entity.Property(e => e.CourseId).ValueGeneratedNever();

//        //    entity.HasOne(d => d.Course).WithOne(p => p.CourseSkill)
//        //        .HasForeignKey<CourseSkill>(d => d.CourseId)
//        //        .OnDelete(DeleteBehavior.ClientSetNull)
//        //        .HasConstraintName("FK_CourseSkills_Course");
//       });

//        modelBuilder.Entity<CourseTopic>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK_CourseTopics");

//            entity.ToTable("CourseTopic");

//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .IsFixedLength();

//            entity.HasOne(d => d.Course).WithMany(p => p.CourseTopics)
//                .HasForeignKey(d => d.CourseId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CourseTopics_Course");
//        });

//        modelBuilder.Entity<FeedBack>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToTable("FeedBack");

//            entity.Property(e => e.FeedBack1)
//                .HasMaxLength(500)
//                .HasColumnName("FeedBack");

//            entity.HasOne(d => d.Course).WithMany()
//                .HasForeignKey(d => d.CourseId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_FeedBack_Course");

//            entity.HasOne(d => d.User).WithMany()
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_FeedBack_User");
//        });

//        modelBuilder.Entity<Role>(entity =>
//        {
//            entity.ToTable("Role");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Description).HasMaxLength(50);
//            entity.Property(e => e.Name).HasMaxLength(50);
//        });

//        modelBuilder.Entity<Skill>(entity =>
//        {
//            entity.Property(e => e.Description)
//                .HasMaxLength(10)
//                .IsFixedLength();
//            entity.Property(e => e.Name).HasMaxLength(50);
//            entity.Property(e => e.Version).HasMaxLength(10);

//            entity.HasOne(d => d.SubCategory).WithMany(p => p.Skills)
//                .HasForeignKey(d => d.SubCategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Skills_SubCategory");
//        });

//        modelBuilder.Entity<State>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK_State_1");

//            entity.ToTable("State");

//            entity.Property(e => e.Name).HasMaxLength(20);

//            entity.HasOne(d => d.Country).WithMany(p => p.States)
//                .HasForeignKey(d => d.CountryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_State_Country");
//        });

//        modelBuilder.Entity<SubCategory>(entity =>
//        {
//            entity.ToTable("SubCategory");

//            entity.Property(e => e.Name).HasMaxLength(40);

//            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
//                .HasForeignKey(d => d.CategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_SubCategory_Category");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK_User_1");

//            entity.ToTable("User");

//            entity.Property(e => e.Address).HasMaxLength(250);
//            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
//            entity.Property(e => e.Email)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.FirstName)
//                .HasMaxLength(150)
//                .IsUnicode(false);
//            entity.Property(e => e.LastName)
//                .HasMaxLength(150)
//                .IsUnicode(false);
//            entity.Property(e => e.Password).HasMaxLength(50);
//            entity.Property(e => e.PhoneNumber)
//                .HasMaxLength(10)
//                .IsFixedLength();
//            entity.Property(e => e.UserName).HasMaxLength(50);

//            entity.HasOne(d => d.Role).WithMany(p => p.Users)
//                .HasForeignKey(d => d.RoleId)
//                .HasConstraintName("FK_User_Role");
//        });

//        modelBuilder.Entity<UserContent>(entity =>
//        {
//            entity.ToTable("UserContent");

//            entity.HasOne(d => d.Content).WithMany(p => p.UserContents)
//                .HasForeignKey(d => d.ContentId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_UserContent_Course");

//            entity.HasOne(d => d.User).WithMany(p => p.UserContents)
//                .HasForeignKey(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_UserContent_User");
//        });

//        modelBuilder.Entity<UserCourse>(entity =>
//        {
//            entity.HasKey(e => e.UserId);

//            entity.Property(e => e.UserId).ValueGeneratedNever();
//            entity.Property(e => e.DateOfEnroll).HasColumnType("date");

//            entity.HasOne(d => d.Course).WithMany(p => p.UserCourses)
//                .HasForeignKey(d => d.CourseId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_UserCourses_Courses");

//            entity.HasOne(d => d.User).WithOne(p => p.UserCourse)
//                .HasForeignKey<UserCourse>(d => d.UserId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_UserCourses_User");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
