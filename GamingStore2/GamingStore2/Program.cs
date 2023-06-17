using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using FluentValidation.AspNetCore;
using Serilog;
using MongoDB.Driver;
using GamingStore.Repositories;
using GamingStore.Services;
using GamingStore.Models;
using GamingStore.Controllers;
using GamingStore.Extensions;
using GamingStore.BL.InerFaces;
using GamingStore.BL.Services;
using GamingStore.DL.InerFaces;
using GamingStore.DL.Repo;

namespace GamingStore2
{
    public class Program
    {
        public IConfiguration Configuration { get; }

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add MongoDB
            services.AddSingleton<IMongoClient>(c => new MongoClient(Configuration.GetConnectionString("MongoDB")));
            services.AddScoped<IMongoDatabase>(c => c.GetService<IMongoClient>().GetDatabase(Configuration.GetValue<string>("MongoDB:DatabaseName")));

            // Add repositories
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Add services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IOrderService, OrderService>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(Program));

            // Add FluentValidation
            services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Program>();
                });

            // Add Serilog
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            // Add health checks
            services.AddHealthChecks();

            // Add authentication (e.g., using JWT)
            // services.AddAuthentication(...)
            //     .AddJwtBearer(...);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable health checks endpoint
            app.UseHealthChecks("/health");

            app.UseRouting();

            // Enable authentication
            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

