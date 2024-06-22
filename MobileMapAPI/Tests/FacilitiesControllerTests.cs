using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MobileMapAPI.Tests;

public class FacilitiesControllerTests(WebApplicationFactory<Program> factory) : ApiTest(factory)
{
    [Fact]
    public async Task GetAllFacilities_ReturnsSuccessAndFacilities()
    {
        // Act
        var response = await Client.GetAsync("/resorts/1/facilities");

        // Assert
        response.EnsureSuccessStatusCode();

        var facilities = await response.Content.ReadAsAsync<List<Facility>>();
        Assert.NotEmpty(facilities);
    }

    [Fact]
    public async Task GetAllCategories_ReturnsSuccessAndCategories()
    {
        // Act
        var response = await Client.GetAsync("resorts/1/facilities/categories");

        // Assert
        response.EnsureSuccessStatusCode();

        var categories = await response.Content.ReadAsAsync<List<FacilityCategory>>();

        Assert.NotNull(categories);
        Assert.NotEmpty(categories);
    }
}