using AutoMapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Sentry;
using Serilog;
using Serilog.Events;
using WebDevelopmentAPI.Data;
using WebDevelopmentAPI.Handler;
using WebDevelopmentAPI.Health;
using WebDevelopmentAPI.Repository;

namespace WebDevelopmentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //serilog
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
            Log.Logger = loggerConfiguration
                      .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                      .Enrich.FromLogContext()
                      .WriteTo.Console()
                      .CreateLogger();

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            //bind between repos
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();

            //add api health check
            builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!);

            //mapper
            var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
            IMapper mapper=automapper.CreateMapper();
            builder.Services.AddSingleton(mapper);

            //sanity integration
            SentrySdk.Init("https://8229ffd4e1ad4ffc8f3d33e06f3b3ce1@o4505436274819072.ingest.sentry.io/4505476592697344");
            SentrySdk.CaptureMessage("Hello Sentry");
      
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapHealthChecks("/api/_health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.Run();
        }
    }
}