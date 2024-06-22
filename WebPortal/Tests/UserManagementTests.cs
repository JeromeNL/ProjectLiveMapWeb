using OpenQA.Selenium;
using Xunit;

namespace WebPortal.Tests;

public class UserManagementTests : WebPortalTest
{
    [Fact]
    public void CanViewUsers()
    {
        // Arrange
        LoginAsSuperAdmin();
        Driver.Navigate().GoToUrl("http://localhost:5008/User");

        // Act
        var users = Driver.FindElements(By.CssSelector("tr"));

        // Assert
        Assert.NotEmpty(users);
    }
    
    [Fact]
    public void CanCreateUser()
    {
        // Arrange
        LoginAsSuperAdmin();
        Driver.Navigate().GoToUrl("http://localhost:5008/User/Create");

        // Act
        Driver.FindElement(By.Id("UserName")).SendKeys("TestUser");
        Driver.FindElement(By.Id("Password")).SendKeys("Ditiseenzeerlangwachtwoordvanmeerdan12tekens");
        Driver.FindElement(By.CssSelector("input[type=submit]")).Click();
        
        // Assert
        Assert.Contains("/User/Add", Driver.Url);
    }
}