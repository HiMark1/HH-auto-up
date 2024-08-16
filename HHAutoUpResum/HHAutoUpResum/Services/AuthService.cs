using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject01.Models;

namespace TestProject01.Services
{
    internal class AuthService : IAuthService
    {
        public async Task LoginAsync(Page page, UserCredentials credentials)
        {
            await page.GoToAsync("https://hh.ru/account/login");
            await page.TypeAsync("input[type='text' i]", credentials.Username);
            await page.TypeAsync("#password", credentials.Password);
            await page.ClickAsync(".magritte-button_size-large___Gjw7e_5-0-8");
            await page.WaitForNavigationAsync();
        }
    }
}
    