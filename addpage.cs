using Microsoft.Playwright;
using System.Threading.Tasks;
using Testproject2.locators;

namespace Testproject2.page
{
    public class Addemp
    {
        private readonly IPage _page;

        public Addemp(IPage page)
        {
            _page = page;
        }

        public async Task AddEmployee(string first, string middle, string last, string id)
        { 

            await _page.Locator(addemp.firstname).FillAsync(first);
            await _page.Locator(addemp.middlename).FillAsync(middle);
            await _page.Locator(addemp.lastname).FillAsync(last);

            await _page.Locator(addemp.empid).ClearAsync();
            await _page.Locator(addemp.empid).FillAsync(id);
        }
    }
}
