using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject01.Services
{
    internal class ResumeService : IResumeService
    {
        string upResumeSelector = "#HH-React-Root > div > div > div.HH-MainContent.HH-Supernova-MainContent > div.main-content.main-content_broad-spacing > div > div > div.bloko-column.bloko-column_container.bloko-column_xs-4.bloko-column_m-8.bloko-column_l-11 > div:nth-child(7) > div:nth-child(4) > div > div.applicant-resumes-actions-wrapper > div > div.applicant-resumes-actions-content > div:nth-child(1) > span > button";

        public async Task RaiseResumeAsync(IPage page)
        {
            var element = await page.QuerySelectorAsync(upResumeSelector);

            await page.GoToAsync("https://hh.ru/applicant/resumes");
            if (element != null)
            {
                await page.ClickAsync(upResumeSelector);
                Console.WriteLine("Элемент кнопки поднятия резюме найден и по нему выполнен клик.");
            }
            else
            {
                Console.WriteLine("Ошибка! Элемент кнопки поднятия резюме НЕ найден.");
                Console.ReadLine();
            }
        }
    }
}
