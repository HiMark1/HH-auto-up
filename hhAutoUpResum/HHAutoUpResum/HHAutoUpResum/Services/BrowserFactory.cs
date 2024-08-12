using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace TestProject01.Services
{
    internal class BrowserFactory : IBrowserFactory
    {
        private readonly LaunchOptions _options;
        // Указываем путь к существующему профилю Браузера
        //string userProfilePath = @"C:\Users\msave\AppData\Local\Google\Chrome\User Data";
        //string browserPath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        public BrowserFactory(string userProfilePath, string browserPath)
        {
            _options = new LaunchOptions
            {
                Headless = true, // Устанавливаем false, чтобы видеть браузер
                ExecutablePath = browserPath,
                UserDataDir = userProfilePath
            };
        }

        public async Task<IBrowser> GetBrowserAsync()
        {

            return await Puppeteer.LaunchAsync(_options);
        }

        public async Task<IPage> GetPageAsync(IBrowser browser)
        {
            return await browser.NewPageAsync();
        }
    }
}
