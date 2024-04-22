using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MobileMapAPI.Tests;

public abstract class ApiTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient Client = factory.CreateClient();
}