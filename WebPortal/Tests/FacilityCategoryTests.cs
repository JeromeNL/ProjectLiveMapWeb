using OpenQA.Selenium;
using Xunit;

namespace WebPortal.Tests;

public class FacilityCategoryTests : WebPortalTest
{
    [Fact]
    public void CanViewFacilityCategories()
    {
        // Arrange
        Driver.Navigate().GoToUrl("http://localhost:5008/FacilityCategory");

        // Act
        var categories = Driver.FindElements(By.CssSelector("tr"));

        // Assert
        Assert.NotEmpty(categories);
    }
}