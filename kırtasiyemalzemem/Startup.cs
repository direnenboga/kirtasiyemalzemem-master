using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using kırtasiyemalzemem.Data;

using Microsoft.AspNetCore.Identity;
using kırtasiyemalzemem.Models;
using Microsoft.AspNetCore.Http;

namespace kırtasiyemalzemem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //öncxe 1 tane context çalıştıralım

            services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BogaDb"));
            //services.AddScoped<IProductService, ProductManager>();
            
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            });

            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Account/Login";
                option.LogoutPath = "/Account/Logout";
                option.AccessDeniedPath = "/Account/Accessdenied";
                option.SlidingExpiration = true;
                option.ExpireTimeSpan = TimeSpan.FromDays(365);
                option.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name="Security.Cookie"
                 };
            });

            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
            services.AddSession();

            //services.AddDbContext<Model>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("kırtasiyemalzememContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
