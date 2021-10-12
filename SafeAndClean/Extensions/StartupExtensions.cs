
using Data.DbContext;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeAndClean.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigIdentityDbContext(this IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(dbConnection));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
            })
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
        }

        public static void BusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<IStudentService, StudentService>();
        }

        public static void ConfigCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }
    }
}
