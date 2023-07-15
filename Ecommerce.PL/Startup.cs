using Ecommerce.BLL;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Repostory;
using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.PL
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
            services.AddControllersWithViews().AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            //configure for connection string
            services.AddDbContextPool<ProductContext>(opts =>
           opts.UseSqlServer(Configuration?.GetConnectionString("ConnecStr")));
            //for Dependancies
            services.AddScoped<IProductRep, productRep>();
			services.AddScoped<IOrderRep, OrderRep>();
			services.AddScoped<IOrderProductRep, OrderProductRep>();
			services.AddScoped<ICustomerRep, CustomerRep>();

            services.AddScoped<ISupplierRep, SupplierRep>();
            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<ICountryRep, CountryRep>();
            services.AddScoped<IDistrictRep, DistrictRep>();

            //Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ProductContext>()
                    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

			services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            });

            //AutoMapper
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
