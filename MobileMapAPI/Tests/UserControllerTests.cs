using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MobileMapAPI.Tests;

public class UserControllerTests(WebApplicationFactory<Program> factory) : ApiTest(factory)
{
    [Fact]
    public async Task GetAllServiceReportsFromUser_ReturnsSuccessAndReports()
    {
        var response = await Client.GetAsync($"/users/56de71e8-894f-4377-ac90-cdfad7e2d267/service-reports");

        response.EnsureSuccessStatusCode();

        var reports = await response.Content.ReadAsAsync<List<ServiceReport>>();
        Assert.NotEmpty(reports);
    }

    [Fact]
    public async Task GetAllFacilityReportsFromUser_ReturnsSuccessAndReports()
    {
        var response = await Client.GetAsync("/users/56de71e8-894f-4377-ac90-cdfad7e2d267/facility-reports");

        response.EnsureSuccessStatusCode();

        var reports = await response.Content.ReadAsAsync<List<FacilityReport>>();
        Assert.NotEmpty(reports);
    }

    [Fact]
    public async Task GetAllPointsFromUser_ReturnsSuccessAndPoints()
    {
        var response = await Client.GetAsync("/users/56de71e8-894f-4377-ac90-cdfad7e2d267/points/total");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetAllPointsRewardedFromUser_ReturnsSuccess()
    {
        var response = await Client.GetAsync("users/56de71e8-894f-4377-ac90-cdfad7e2d267/points/awarded");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetAllPointsDeductedFromUser_ReturnsSuccess()
    {
        var response = await Client.GetAsync("users/56de71e8-894f-4377-ac90-cdfad7e2d267/points/deducted");

        response.EnsureSuccessStatusCode();
    }
}