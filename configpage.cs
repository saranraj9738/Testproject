using Microsoft.Playwright;
using NUnit.Framework;
using Testproject2.locators;
using System.Linq;
using System.Threading.Tasks;
namespace Testproject2.page
{
    public class configpage
    {
        private readonly IPage _page;
        private readonly CommonPage commonPage;
        public configpage(IPage page)
        {
            _page = page;
            commonPage = new CommonPage(_page);
        }
        public async Task reportmethod(string rname)
        {
            await commonPage.Fill(config.Name, rname, "Reporting method name field");
        }
        public async Task reportvisible(string expectedtext)
        {
            var listLocator = _page.Locator(config.report_list);   
            await listLocator.First.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });
            var row_elements = await listLocator.AllAsync();
            var visible_names = (await Task.WhenAll(row_elements.Select(async el => await el.InnerTextAsync()))).ToList();
            bool is_added = visible_names.Any(x => x.Trim().Equals(expectedtext.Trim(), System.StringComparison.OrdinalIgnoreCase));
            if (is_added)
            {
                CommonPage.Test.Pass($"Successfully verified reporting method: '{expectedtext}' is visible inside the grid table summary.");
            }
            else
            {
                CommonPage.Test.Fail($"Bug Found: Expected reporting method '{expectedtext}' was completely missing from the visible records list.");
                Assert.That(is_added, Is.True, $"Bug Found: The '{expectedtext}' was not added to the OrangeHRM reporting methods");
            }
        }
    }
}
