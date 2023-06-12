using GamingStore.BL.Interfaces;
using GamingStore.BL.Services;
using GamingStore.DL.Interfaces;
using GamingStore.DL.Repo;
using GamingStore.DL.Repo.Mongo;
using Gaming_Store_Data.Config;
using Gaming_Store.Extensions;
using Gaming_Store.Healthchecks;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Gaming_Store.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
namespace Gaming_Store
{   
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File("log-.txt",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddSerilog(logger);

            //Add configurations
            builder.Services.Configure<MongoConfiguration>(
                builder.Configuration.GetSection(nameof(MongoConfiguration)));
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            // Add services to the container.
            builder.Services
                .AddSingleton<IGameRepository, MongoGameRepo>();
            builder.Services
                .AddSingleton<IGameService, GameService>();
            builder.Services
                .AddSingleton<IOrderRepository, MongoOrderRepo>();
            builder.Services
                .AddSingleton<IOrderService, OrderService>();
            

            builder.Services.AddAutoMapper(
                typeof(Program));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
                builder.Services.AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
                builder.Services
                    .AddValidatorsFromAssemblyContaining(typeof(Program));

            builder.Services.AddHealthChecks()
                .AddCheck<MongoHealthCheck>("MongoDB")
                .AddUrlGroup(
                    new Uri("https://google.bg"), "My Service");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.RegisterHealthChecks();

            app.MapControllers();

            app.Run();
        }
    }
}
