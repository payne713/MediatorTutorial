using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Project.Api.Core.Extensions.ApiVersion;
using Project.Domain.SeedWorks;
using Project.Infrastructure.AutoMapper.Extensions;
using Project.Infrastructure.MediatR.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace Project
{
    public class Startup
    {
        // Default Cors policy name
        private const string _defaultCorsPolicyName = "Project.Api.Cors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // Load assembly from appsetting.json
            string assemblies = Configuration["Assembly:Function"];

            //if (!string.IsNullOrEmpty(assemblies))
            //{
            //    foreach (var item in assemblies.Split('|', StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        Assembly assembly = Assembly.Load(item);
            //        foreach (var implement in assembly.GetTypes())
            //        {
            //            Type[] interfaceType = implement.GetInterfaces();
            //            foreach (var service in interfaceType)
            //            {
            //                services.AddTransient(service, implement);
            //            }
            //        }
            //    }
            //}
            
            // Config automapper mapping rules
            services.AddAutoMapperProfiles();

            // Replace with your connection string.
            var connectionString = Configuration.GetConnectionString("ProjectConnection");

            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));

            // Replace 'UserApplicationDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<ApplicationDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()       // <-- with debugging (remove for production).
            );


            var connStr = Configuration.GetConnectionString("ProjectConnection");

            // Use lowercase urls router mode
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            // Config api version
            //services.AddApiVersion();

            // Config cors policy
            services.AddCors(options => options.AddPolicy(_defaultCorsPolicyName,
                builder => builder.WithOrigins(
                        Configuration["Application:CorsOrigins"]
                        .Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray()
                    )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project", Version = "v1" });
            });

            // Config mediatr
            //services.AddCustomMediatR(new MediatorDescriptionOptions
            //{
            //    StartupClassType = typeof(Startup),
            //    Assembly = Configuration["Assembly:Mediator"].Split("|", StringSplitOptions.RemoveEmptyEntries)
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
