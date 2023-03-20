using Microsoft.EntityFrameworkCore;
using SwordLMS.Web.Models;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;

namespace SwordLMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SwordLmsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SwordLmsContext")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                 options.SlidingExpiration = true;
                 options.AccessDeniedPath = "/Forbidden/";
                 options.LoginPath= "/User/Login";
             });

            builder.Services.AddDbContext<SwordLmsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SwordLmsContext")));


            builder.Services.AddScoped<SwordLmsContext>();


            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           // builder.Services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };
            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseAuthentication(options =>
            //{
            //    options.AutomaticAuthenticate = true;
            //    options.AutomaticChallenge = true;
            //   options.LoginPath = "/Home/Login";
            //});

            // app.UseAuthentication();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");



            app.Run();
        }
    }
}