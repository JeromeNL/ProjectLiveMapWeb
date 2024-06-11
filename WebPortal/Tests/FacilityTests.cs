using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace WebPortal.Tests;

public class FacilityTests : WebPortalTest
{
    [Fact]
    public void WorkingMapIsShown()
    {
        // Arrange
        LoginAsSuperAdmin();

        // Act
        var leafletMap = Driver.FindElement(By.ClassName("leaflet-map-pane"));

        // Assert
        Assert.NotNull(leafletMap);
    }

    [Fact]
    public void MapHasMarkers()
    {
        // Arrange
        LoginAsSuperAdmin();
        WaitForMarkers();

        // Act
        var markers = Driver.FindElements(By.ClassName("leaflet-marker-icon"));

        // Assert
        Assert.NotEmpty(markers);
    }

    [Fact]
    public void MarkerShowsPopup()
    {
        // Arrange
        LoginAsSuperAdmin();
        WaitForMarkers();
        
        // Act
        var marker = Driver.FindElement(By.CssSelector(".leaflet-marker-icon[title='Baron 1898']"));
        marker.Click();
        var popup = Driver.FindElement(By.ClassName("leaflet-popup"));

        // Assert
        Assert.NotNull(popup);
        Assert.Contains("Baron 1898", popup.Text);
    }

    private void WaitForMarkers()
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
        wait.Until(d => d.FindElement(By.ClassName("leaflet-marker-icon")) != null);
    }
    
}