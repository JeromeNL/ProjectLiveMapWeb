using DataAccess.Converters;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace MobileMapAPI.Tests;

public class FacilitiesControllerTests(WebApplicationFactory<Program> factory) : ApiTest(factory)
{
    [Fact]
    public async Task GetAllFacilities_ReturnsSuccessAndFacilities()
    {
        // Arrange
        var response = await Client.GetAsync("/resorts/1/facilities");
        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new TimeOnlyConverter());

        // Act
        response.EnsureSuccessStatusCode();
        var facilities =
            JsonConvert.DeserializeObject<List<Facility>>(await response.Content.ReadAsStringAsync(), settings);
        
        // Assert
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