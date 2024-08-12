using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject01.Services
{
    internal interface IBrowserFactory
    {
        Task<IBrowser> GetBrowserAsync();
        Task<IPage> GetPageAsync(IBrowser browser);
    }
}
