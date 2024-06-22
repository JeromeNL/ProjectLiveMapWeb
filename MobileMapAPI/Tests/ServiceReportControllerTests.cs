using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MobileMapAPI.Tests;

public class ServiceReportControllerTests(WebApplicationFactory<Program> factory) : ApiTest(factory)
{
    [Fact]
    public async Task GetAllServiceReports_ReturnsSuccessAndReports()
    {
        var response = await Client.GetAsync("/resorts/1/facilities/service-reports");

        response.EnsureSuccessStatusCode();

        var reports = await response.Content.ReadAsAsync<List<ServiceReport>>();
        Assert.NotEmpty(reports);
    }

    [Fact]
    public async Task GetAllCategories_ReturnsSuccessAndCategories()
    {
        var response = await Client.GetAsync("/resorts/1/facilities/service-reports/categories");

        response.EnsureSuccessStatusCode();

        var categories = await response.Content.ReadAsAsync<List<ServiceReportCategory>>();

        Assert.NotNull(categories);
        Assert.NotEmpty(categories);
    }
}