using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice
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
            services.AddDbContext<ApiDBContext>(opt => opt.UseInMemoryDatabase("CountryDB"));
            services.AddScoped<ApiDBContext>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Practice", Version = "v1" });
            });
        }

        private static void AddData(ApiDBContext context)
        {
            var country = new Country { Id = 1, CountryCode = "234", Name = "Nigeria", CountryIso = "NG" };
            var country1 = new Country { Id = 2, CountryCode = "233", Name = "Ghana", CountryIso = "GN" };
            var country2 = new Country { Id = 1, CountryCode = "229", Name = "Benin Republic", CountryIso = "BN" };
            var country3 = new Country { Id = 1, CountryCode = "225", Name = "Côte d'Ivoire", CountryIso = "CIV" };
            context.Country.Add(country);
            context.Country.Add(country1);
            context.Country.Add(country2);
            context.Country.Add(country3);
            context.SaveChanges();

            var countrydetail = new CountryDetails { Id = 1, CountryId = 1, Operator = "MTN Nigeria", OperatorCode = "MTN NG" };
            var countrydetail1 = new CountryDetails { Id = 2, CountryId = 1, Operator = "Airtel Nigeria", OperatorCode = "ANG" };
            var countrydetail2 = new CountryDetails { Id = 3, CountryId = 1, Operator = "9 Mobile Nigeria", OperatorCode = "MTN NG" };
            var countrydetail3 = new CountryDetails { Id = 4, CountryId = 1, Operator = "Globacom Nigeria", OperatorCode = "GLO NG" };
            var countrydetail4 = new CountryDetails { Id = 5, CountryId = 1, Operator = "Vodafone Ghana", OperatorCode = "Vodafone GH" };
            var countrydetail5 = new CountryDetails { Id = 6, CountryId = 2, Operator = "MTN Ghana ", OperatorCode = "MTN Ghana" };
            var countrydetail6 = new CountryDetails { Id = 7, CountryId = 2, Operator = "Tigo Ghana", OperatorCode = "Tigo Ghana" };
            var countrydetail7= new CountryDetails { Id = 8, CountryId = 2, Operator = "MTN Benin", OperatorCode = "MTN Benin" };
            var countrydetail8= new CountryDetails { Id = 9, CountryId = 3, Operator = "Moov Benin", OperatorCode = "Moov Benin" };
            var countrydetail9 = new CountryDetails { Id = 10, CountryId = 4, Operator = "MTN Côte d'Ivoire", OperatorCode = "MTN CIV" };

            context.CountryDetails.Add(countrydetail);
            context.CountryDetails.Add(countrydetail1);
            context.CountryDetails.Add(countrydetail2);
            context.CountryDetails.Add(countrydetail3);
            context.CountryDetails.Add(countrydetail4);
            context.CountryDetails.Add(countrydetail5);
            context.CountryDetails.Add(countrydetail6);
            context.CountryDetails.Add(countrydetail7);
            context.CountryDetails.Add(countrydetail8);
            context.CountryDetails.Add(countrydetail9);
            context.SaveChanges();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            // var context = app.ApplicationServices.GetService<ApiDBContext>();
            // AddData(context);
            DbInitializer.Seed(serviceProvider.GetRequiredService<ApiDBContext>());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
