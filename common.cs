using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Testproject2.page
{
    public class CommonPage
    {
        private readonly IPage _page;

        public CommonPage(IPage page)
        {
            _page = page;
        }

        public async Task Click(string xpathLocator)
        {
           
            await _page.Locator(xpathLocator).First.ClickAsync();
            await _page.WaitForTimeoutAsync(10000);
        }
    }
}
