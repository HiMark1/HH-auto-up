﻿using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject01.Models;

namespace TestProject01.Services
{
    internal interface IAuthService
    {
        Task LoginAsync(Page page, UserCredentials credentials);
    }
}
