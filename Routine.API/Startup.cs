using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Routine.API.Date;
using Routine.API.Services;

namespace Routine.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
                //   setup.InputFormatters.Add( new XmlDataContractSerializerInputFormatter(setup));
            }).AddNewtonsoftJson(setup =>
                {
                    setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setup =>
            {
                setup.InvalidModelStateResponseFactory =
                    context =>
                    {
                        var probleDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Type = "https://www.baidu.com",
                            Title = "Error!!",
                            Status =  StatusCodes.Status422UnprocessableEntity,
                            Detail = "No details",
                            Instance =  context.HttpContext.Request.Path
                        };
                        probleDetails.Extensions.Add("traceId",context.HttpContext.TraceIdentifier);

                        return  new UnprocessableEntityObjectResult(probleDetails)
                        {
                            ContentTypes = {"application/problem+json"}
                        };
                    };
            });


            //È«¾Ö
            services.Configure<MvcOptions>(config =>
            {
                var newtonSoftJsonOutputFormatter =
                    config.OutputFormatters.OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();

                newtonSoftJsonOutputFormatter?.SupportedMediaTypes.Add("application/vnd.company.hateoas+json");
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddDbContext<RoutineDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
            services.AddTransient<IPropertyCheckerService, PropertyCheckerService>();
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
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async Contex =>
                    {
                        Contex.Response.StatusCode = 500;
                        await Contex.Response.WriteAsync("Unexpected Error!");
                    });
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}