using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GermanOutletStore.Data;
using Microsoft.AspNetCore.Identity;
using GermanOutletStore.Models;
using GermanOutletStore.Common;
using AutoMapper;
using GermanOutletStore.Services.Products;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.FileProviders.Physical;

namespace GermanOutletStore.Web
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
            services.AddResponseCompression();
            services.AddResponseCaching();

            services.AddScoped<ProductManager>();            

            services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GermanOutletStore")));

            services.AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<StoreDbContext>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });            

            services.AddAuthentication();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireLowercase = true,
                    RequireDigit = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };
            });

            services.AddAutoMapper();
            services.AddSession();

            services
                .AddMvc(options => options.EnableEndpointRouting = false)          
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env)
        {
            app.UseResponseCaching();
            app.UseResponseCompression();

            if (env.EnvironmentName == "Develop")
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "SiteImages"), ExclusionFilters.None),
                RequestPath = "/SiteImages",
            });
            app.UseCookiePolicy();
            app.UseAuthentication();              

            app.SeedDatabase();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "navigateToProducts",
                    template: "{controller=Products}/{action=AllCategories}/{type}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
