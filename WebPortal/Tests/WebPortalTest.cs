using Microsoft.AspNetCore.Mvc.Testing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebPortal.Tests;

public abstract class WebPortalTest : IDisposable
{
    protected readonly IWebDriver Driver = new ChromeDriver();
    private static readonly WebApplicationFactory<Program> Factory = new();
    protected readonly HttpClient Client = Factory.CreateClient();

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
        Client.Dispose();
        Factory.Dispose();
        GC.SuppressFinalize(this);
    }
}