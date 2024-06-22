using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MobileMapAPI.Tests;

public class FacilityReportControllerTests(WebApplicationFactory<Program> factory) : ApiTest(factory)
{
    [Fact]
    public async Task GetAllFacilityReports_ReturnsSuccessAndReports()
    {
        // Act
        var response = await Client.GetAsync("/resorts/1/facilities/facility-reports");

        // Assert
        response.EnsureSuccessStatusCode();

        var reports = await response.Content.ReadAsAsync<List<FacilityReport>>();
        Assert.NotEmpty(reports);
        Assert.NotNull(reports);
    }

    [Fact]
    public async Task GetOneFacilityReports_ReturnsSuccessAndReport()
    {
        // Act
        var response = await Client.GetAsync("/resorts/1/facilities/facility-reports/1");

        // Assert
        response.EnsureSuccessStatusCode();

        var report = await response.Content.ReadAsAsync<FacilityReport>();
        Assert.NotNull(report);
    }
}