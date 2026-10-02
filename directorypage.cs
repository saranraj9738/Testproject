using Microsoft.Playwright;
using NUnit.Framework;
using Testproject2.locators;
namespace Testproject2.page
{
    public class directory
    {
        private readonly IPage _page;
        private readonly CommonPage commonPage;
        public directory(IPage page)
        {
            _page = page;
            commonPage = new CommonPage(_page);
        }
        public async Task searchdirectory(string name)
        {
            await commonPage.Fill(direct.ename, name, "Employee name entered");
        }
        public async Task Validation(string expectedtext)
        {
            var error =_page.Locator(direct.invalid_name);
            bool isvisible = await error.IsVisibleAsync();
            if(isvisible)
            {
                string message = await error.InnerTextAsync();
                if(message.Contains(expectedtext))
                {
                    CommonPage.Test.Pass($"Message was found{expectedtext}");
                }
                else
                {
                    CommonPage.Test.Fail($"Message was not found{expectedtext}");
                    Assert.Fail($"Message was not found{expectedtext}");
                }
            }
            else
            {
                CommonPage.Test.Fail($"Element not visible{expectedtext}");
                Assert.Fail($"Element not visible{expectedtext}");
            }
        }
    }
}
