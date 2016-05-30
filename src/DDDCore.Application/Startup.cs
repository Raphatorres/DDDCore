using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDCore.Domain.Interfaces.Repositories;
using DDDCore.Domain.Interfaces.Services;
using DDDCore.Domain.Services;
using DDDCore.Infra.Data.Context;
using DDDCore.Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DDDCore.Application
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var sqlLoggerFactory = new LoggerFactory();
            sqlLoggerFactory.AddConsole(Configuration.GetSection("SqlLogging"));

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            var entityFramework = services;
            entityFramework= entityFramework
                .AddEntityFrameworkSqlServer()
                .AddDbContext<DDDContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"], 
                x => x.MigrationsAssembly("DDDCore.Application")) 
                .UseLoggerFactory(sqlLoggerFactory));

            //Domain
            services.AddScoped<IClienteService, ClienteService>();

            //infra
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<DDDContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
