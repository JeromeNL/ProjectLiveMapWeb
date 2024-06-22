using System.Text.Json.Serialization;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        // Add services to the container.
        builder.Services.AddDbContextPool<LiveMapDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("LivemapDB"))
                .AddInterceptors(new SoftDeleteInterceptor()));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // JSON circular dependency resolution
        builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        var app = builder.Build();
        app.UseSwagger();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}