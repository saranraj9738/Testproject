using Microsoft.Playwright;
using System.Reflection;
using System.Threading.Tasks;
using Testproject2.locators;

namespace Testproject2.page
{
    public class Search
    {
        private readonly IPage _page;

        public Search(IPage page)
        {
            _page = page;
        }

        public async Task SearchEmployee(string empname, string empid)
        {
            await _page.Locator(Empsearch.empname).FillAsync(empname);
            await _page.Locator(Empsearch.empid).FillAsync(empid);
            

        }
    }
}
