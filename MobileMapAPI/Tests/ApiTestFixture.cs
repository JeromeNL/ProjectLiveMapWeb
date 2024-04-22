using DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MobileMapAPI.Tests;

public class ApiTestFixture : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            services.AddEntityFrameworkInMemoryDatabase();

            // Create a new service provider.
            var provider = services
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Add a database context (ApplicationDbContext) using an in-memory
            // database for testing.
            services.AddDbContext<LiveMapDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
                options.UseInternalServiceProvider(provider);
            });

            // Build the service provider.
            var sp = services.BuildServiceProvider();

            // Create a scope to obtain a reference to the database
            // context (ApplicationDbContext).
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<LiveMapDbContext>();
            var loggerFactory = scopedServices.GetRequiredService<ILoggerFactory>();

            var logger = scopedServices
                .GetRequiredService<ILogger<ApiTestFixture>>();

            // Ensure the database is created.
            db.Database.EnsureCreated();

            try
            {
                DataSeeder.InitializeSeedData();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred seeding the " +
                                    "database with test messages. Error: {ex.Message}");
            }
        });
    }
}