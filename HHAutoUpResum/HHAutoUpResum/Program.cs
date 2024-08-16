using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PuppeteerSharp;
using TestProject01.Models;
using TestProject01.Services;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration Configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
       .Build();

        var userProfilePath = Configuration["BrowserSettings:UserProfilePath"];
        var browserPath = Configuration["BrowserSettings:BrowserPath"];
        if(browserPath == null || userProfilePath == null) { Console.WriteLine("Ошибка! Не найдены browserPath или userProfilePath"); }
        // Настройка DI
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IBrowserFactory, BrowserFactory>(sp => new BrowserFactory(userProfilePath, browserPath))
            .AddSingleton<IAuthService, AuthService>()
            .AddSingleton<IResumeService, ResumeService>()
            .BuildServiceProvider();


        var browserFactory = serviceProvider.GetService<IBrowserFactory>();
        var authService = serviceProvider.GetService<IAuthService>();
        var resumeService = serviceProvider.GetService<IResumeService>();



        var browser = await browserFactory.GetBrowserAsync();
        var page = await browserFactory.GetPageAsync(browser);

        await resumeService.RaiseResumeAsync(page);

        await browser.CloseAsync();
    }
}