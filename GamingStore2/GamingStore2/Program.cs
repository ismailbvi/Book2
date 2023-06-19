using FluentValidation;
using FluentValidation.AspNetCore;
using Gaming_Store_Data.Config;
using GamingStore.BL.InerFaces;
using GamingStore.BL.Services;
using GamingStore.DL.InerFaces;
using GamingStore.DL.Repo;
using GamingStore2.Extensions;
using GamingStore2.Healthchecks;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
namespace GamingStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
        .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
        .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddSerilog(logger);

            builder.Services.Configure<MongoConfiguration>(
                 builder.Configuration.GetSection(nameof(MongoConfiguration)));
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            builder.Services.AddSingleton<IGameRepository, MongoGameRepo>();
            builder.Services.AddSingleton<IOrderRepository, MongoOrderRepo>();
            builder.Services.AddSingleton<IGameService, GameService>();
            builder.Services.AddSingleton<IOrderService, OrderService>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            builder.Services
                .AddValidatorsFromAssemblyContaining(typeof(Program));

            builder.Services.AddHealthChecks()
                .AddCheck<MongoHealthCheck>("MongoDB")
                .AddUrlGroup(new Uri("https://google.bg"), "My Service");


            var app = builder.Build();

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