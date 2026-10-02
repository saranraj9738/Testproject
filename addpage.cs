using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Testproject2.locators;
using System;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Testproject2.page
{
    public class Addemp
    {
        private readonly IPage _page;
        private readonly CommonPage commonPage; 
        public Addemp(IPage page)
        {
            _page = page;
            commonPage = new CommonPage(_page); 
        }
        public async Task AddEmployee(string first, string middle, string last, string id)
        {
            await commonPage.Fill(addemp.firstname, first, "First Name Field");
            await commonPage.Fill(addemp.middlename, middle, "Middle Name Field");
            await commonPage.Fill(addemp.lastname, last, "Last Name Field");
            await _page.Locator(addemp.empid).ClearAsync();
            await commonPage.Fill(addemp.empid, id, "Employee ID Field");
        }
        public async Task Dashboard()
        {
            var config = new ConfigurationBuilder().SetBasePath(System.AppContext.BaseDirectory).AddJsonFile("json/data.json", optional: false).Build();
            await _page.WaitForURLAsync(config["dashurl"], new PageWaitForURLOptions { Timeout = 5000 });
            CommonPage.Test.Pass("Successfully opened the OrangeHRM Dashboard.");
        }
        public async Task VerifyNavigationToPersonalDetails()
        {
            await _page.WaitForURLAsync("**/viewPersonalDetails/empNumber/**", new PageWaitForURLOptions { Timeout = 10000 });
            if (!_page.Url.Contains("viewPersonalDetails"))
            {
                throw new Exception($"Assertion Failed: Expected the Personal Details page, get: {_page.Url}");
            }
            CommonPage.Test.Pass("Personal Details screen displayed .");
        }
        public async Task VerifyFieldValidationTags(string expectedtext)
        {
            var firstErrorLocator = _page.Locator(addemp.firsterror);
            var lastErrorLocator = _page.Locator(addemp.lasterror);
            await firstErrorLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await lastErrorLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });
            bool isFirstVisible = await firstErrorLocator.IsVisibleAsync();
            bool isLastVisible = await lastErrorLocator.IsVisibleAsync();
            if (isFirstVisible && isLastVisible)
            {
                string firstText = await firstErrorLocator.InnerTextAsync();
                string lastText = await lastErrorLocator.InnerTextAsync();
                if (firstText.Contains(expectedtext) && lastText.Contains(expectedtext))
                {
                    CommonPage.Test.Pass($"Validation tags matched expected text: '{expectedtext}' on both fields.");
                }
                else
                {
                    CommonPage.Test.Fail($"Text Mismatch: Expected messages to contain '{expectedtext}', but got First: '{firstText}', Last: '{lastText}' instead.");
                    Assert.Fail($"Text Mismatch: Expected messages to contain '{expectedtext}', but got First: '{firstText}', Last: '{lastText}' instead.");
                }
            }
            else
            {
                CommonPage.Test.Fail($"Validation tags were missing: {isFirstVisible}, Last Name Error Visible: {isLastVisible}.");
                Assert.Fail($"Validation tags were missing: {isFirstVisible}, Last Name Error Visible: {isLastVisible}.");
            }
        }
    }
}
