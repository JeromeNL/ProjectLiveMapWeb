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
    public void MarkerShowsPopupOnClick()
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

    [Fact]
    public void MapClickInsideParkReturnsFacilityCreate()
    {
        // Arrange
        LoginAsSuperAdmin();
        WaitForMarkers();
        
        // Act
        var marker = Driver.FindElement(By.CssSelector(".leaflet-marker-icon[title='Baron 1898']"));
        var markerSize = marker.Size;
        var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
        
        actions.MoveToElement(marker, markerSize.Width + 10, markerSize.Height / 2).Click().Perform();
        
        // Assert
        Assert.Contains("Facility/create", Driver.Url);
        
    }

    [Fact]
    public void MapClickOutsideParkReturnsError()
    {
        // Arrange
        LoginAsSuperAdmin();
        WaitForMarkers();

        // Act
        var map = Driver.FindElement(By.ClassName("leaflet-map-pane"));
        var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
        actions.MoveToElement(map, 50, 50).Click().Perform();
        
        var error = Driver.FindElement(By.CssSelector(".alert-error span"));

        // Assert
        Assert.Contains("Facility", Driver.Url);
        Assert.Contains("Klik binnen het park om een faciliteit toe te voegen.", error.Text);
    }

    private void WaitForMarkers()
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
        wait.Until(d => d.FindElement(By.ClassName("leaflet-marker-icon")) != null);
    }
    
}