using OpenQA.Selenium;
using Xunit;

namespace WebPortal.Tests;

public class HolidayResortTests : WebPortalTest
{
    [Fact]
    public void CanViewHolidayResorts()
    {
        // Arrange
        LoginAsSuperAdmin();
        Driver.Navigate().GoToUrl("http://localhost:5008/Resort");

        // Act
        var holidayResorts = Driver.FindElements(By.CssSelector("tr"));

        // Assert
        Assert.NotEmpty(holidayResorts);
    }

    [Fact]
    public void CanViewResortDetails()
    {
        // Arrange
        LoginAsSuperAdmin();
        Driver.Navigate().GoToUrl("http://localhost:5008/Resort");

        // Act
        var resortLink = Driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(2) > a"));
        resortLink.Click();
        var resortName = Driver.FindElement(By.CssSelector("h2"));

        // Assert
        Assert.Contains("Efteling", resortName.Text);
        Assert.Contains("Resort/Details?resortId=1", Driver.Url);
    }
}