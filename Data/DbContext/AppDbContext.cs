using Data.Entities;
using Data.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DbContext
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Entities
       
        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectMajor> SubjectMajors { get; set; }
        public virtual DbSet<SubjectMentor> SubjectMentors { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> User { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region double pk fk
          
            modelBuilder.Entity<SubjectMajor>().HasKey(s => new { s.MajorId, s.SubjectId });

            #endregion

            #region seed data

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = ConstUserRoles.ADMIN, Name = ConstUserRoles.ADMIN, NormalizedName = ConstUserRoles.ADMIN, ConcurrencyStamp = ConstUserRoles.ADMIN },
            new IdentityRole() { Id = ConstUserRoles.USER, Name = ConstUserRoles.USER, NormalizedName = ConstUserRoles.USER, ConcurrencyStamp = ConstUserRoles.USER }
           );

            modelBuilder.Entity<User>().HasData(
                new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b060", UserName = "admin", NormalizedUserName = "admin", Fullname = "Admin Ne`", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==" }
               );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b060", RoleId = ConstUserRoles.ADMIN }
            );

            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole() { Id = ConstUserRoles.ADMIN, Name = ConstUserRoles.ADMIN, NormalizedName = ConstUserRoles.ADMIN, ConcurrencyStamp = ConstUserRoles.ADMIN },
            //    new IdentityRole() { Id = ConstUserRoles.CUSTOMER, Name = ConstUserRoles.CUSTOMER, NormalizedName = ConstUserRoles.CUSTOMER, ConcurrencyStamp = ConstUserRoles.CUSTOMER },
            //    new IdentityRole() { Id = ConstUserRoles.EMPLOYEE, Name = ConstUserRoles.EMPLOYEE, NormalizedName = ConstUserRoles.EMPLOYEE, ConcurrencyStamp = ConstUserRoles.EMPLOYEE }
            //    );
            //modelBuilder.Entity<User>().HasData(
            //    new User() { Id = "3c5ec754-01b1-49cf-94e0-09250222b060", UserName = "admin", NormalizedUserName = "admin", Fullname = "Admin Ne`", PasswordHash = "AQAAAAEAACcQAAAAEHaMifmenPio6tOMmkItEGJouVwE0OIMNql432J1dNSZDG10etUQfLlGiCvdmbA1Nw==" }
            //    );
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>() { UserId = "3c5ec754-01b1-49cf-94e0-09250222b060", RoleId = ConstUserRoles.ADMIN}
            //    );
            #endregion
        }
    }
}
