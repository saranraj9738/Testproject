using Microsoft.Playwright;
using Testproject2.locators;
namespace Testproject2.page
{
    public class reportpage
    {
        private readonly IPage _page;
        private readonly CommonPage commonPage;
        public reportpage(IPage page)
        {
            _page = page;
            commonPage = new CommonPage(_page);
        }
        public async Task searchreport(string rname)
        {
            await commonPage.Fill(Report.report_name, rname, "report name entered");
        }
    }
}
