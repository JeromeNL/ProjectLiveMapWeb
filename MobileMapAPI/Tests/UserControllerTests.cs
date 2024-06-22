using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MobileMapAPI.Tests;

public class UserControllerTests(WebApplicationFactory<Program> factory) : ApiTest(factory)
{
    private const string UserId = "56de71e8-894f-4377-ac90-cdfad7e2d267";

    [Fact]
    public async Task GetAllServiceReportsFromUser_ReturnsSuccessAndReports()
    {
        var response = await Client.GetAsync($"/users/{UserId}/service-reports");

        response.EnsureSuccessStatusCode();

        var reports = await response.Content.ReadAsAsync<List<ServiceReport>>();
        Assert.NotEmpty(reports);
    }

    [Fact]
    public async Task GetAllFacilityReportsFromUser_ReturnsSuccessAndReports()
    {
        var response = await Client.GetAsync($"/users/{UserId}/facility-reports");

        response.EnsureSuccessStatusCode();

        var reports = await response.Content.ReadAsAsync<List<FacilityReport>>();
        Assert.NotEmpty(reports);
    }

    [Fact]
    public async Task GetAllPointsFromUser_ReturnsSuccessAndPoints()
    {
        var response = await Client.GetAsync($"/users/{UserId}/points/total");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetAllPointsOverviewFromUser_ReturnsSuccess()
    {
        var response = await Client.GetAsync($"/users/{UserId}/points/transactions");

        response.EnsureSuccessStatusCode();
    }
}