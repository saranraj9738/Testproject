using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using AventStack.ExtentReports;
using NUnit.Framework;
namespace Testproject2.page
{
    public class CommonPage
    {
        private readonly IPage _page;
        public static ExtentTest Test;
        public CommonPage(IPage page)
        {
            _page = page;
        }
        public async Task Click(string xpathLocator, string text)
        {
            try
            {
                await _page.ClickAsync(xpathLocator);
                Test.Pass($"{text} is clicked");
            }
            catch (Exception e)
            {
                    Test.Fail($"{text} is not clicked. Exception is: {e.Message}");
                    Assert.Fail($"{text} is not clicked. Exception is: {e.Message}");
            }
        }
        public async Task Fill(string xpathLocator, string value, string text)
        {
            try
            {
                await _page.Locator(xpathLocator).First.FillAsync(value);
                Test.Pass($"'{value}' is successfully entered into {text}");
            }
            catch (Exception e)
            {
                    Test.Fail($"Failed to enter text into {text}. Exception is: {e.Message}");
                    Assert.Fail($"Failed to enter text into {text}. Exception is: {e.Message}");  
            }
        }
    }
}
