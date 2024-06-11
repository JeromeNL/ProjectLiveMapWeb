using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace WebPortal.Tests;

public class FacilityReportTests : WebPortalTest
{
    [Fact]
    public void TableContainsReports()
    {
        // Arrange
        LoginAsSuperAdmin();
        Driver.Navigate().GoToUrl("http://localhost:5008/FacilityReport");

        // Act
        var reports = Driver.FindElements(By.CssSelector("tr"));

        // Assert
        Assert.NotEmpty(reports);
    }
    
    [Fact]
    public void CanRejectReport()
    {
        // Arrange
        LoginAsSuperAdmin();
        Driver.Navigate().GoToUrl("http://localhost:5008/FacilityReport");

        // Act
        var rejectButton = Driver.FindElement(By.CssSelector(".btn-sm.btn-error"));
        rejectButton.Click();

        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
        
        var openModal = Driver.FindElement(By.ClassName("modal-open"));
        var confirmButton = wait.Until(_ => openModal.FindElement(By.CssSelector("button[type=submit]")));
        confirmButton.Click();
        
        var alert = Driver.FindElement(By.CssSelector(".alert-info span"));
        
        // Assert
        Assert.NotNull(alert);
        Assert.Contains("is afgekeurd", alert.Text);
    }
}