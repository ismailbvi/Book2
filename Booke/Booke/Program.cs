using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repo;
using BookStore.DL.Repo.Mongo;
using BookStore.Models.Configs;
using Booke.Extensions;
using Booke.Healthchecks;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Booke.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Booke
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
                    .AddSingleton<IAuthorRepository, AuthorRepository>();
                builder.Services
                    .AddSingleton<IAuthorService, AuthorService>();
                builder.Services
                    .AddSingleton<IBookRepository, BookRepository>();
                builder.Services
                    .AddSingleton<IBookService, BookService>();
                builder.Services
                    .AddSingleton<IUserInfoRepository, UserInfoRepository>();
                builder.Services
                    .AddSingleton<IUserInfoService, UserInfoService>();
                builder.Services
                    .AddSingleton<ILibraryService, LibraryService>();

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

                app.RegisterHealthCheck();

                app.MapControllers();

                app.Run();
            }
        }
    }
