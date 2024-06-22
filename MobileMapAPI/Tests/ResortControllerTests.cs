using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MobileMapAPI.Tests;

public class ResortControllerTests(WebApplicationFactory<Program> factory) : ApiTest(factory)
{
    [Fact]
    public async Task GetAllResorts_ReturnsSuccesAndResorts()
    {
        var response = await Client.GetAsync("/resorts");
        response.EnsureSuccessStatusCode();
        var resorts = await response.Content.ReadAsAsync<List<HolidayResort>>();
        Assert.NotEmpty(resorts);
    }
}