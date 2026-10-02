using TechTalk.SpecFlow;
using Testproject2.fixture;
using Testproject2.page;
using Testproject2.locators;
namespace Testproject2.steps
{
    [Binding]
    public class reportstep
    {
        private readonly PlaywrightDriver p_driver;
        private readonly CommonPage commonpage;
        private readonly reportpage report;
        public reportstep(PlaywrightDriver driver)
        {
            p_driver = driver;
            commonpage = new CommonPage(driver.Page);
            report = new reportpage(driver.Page);
        }
        [When(@"the user click the Reports module")]
        public async Task Clickreports()
        {
            await commonpage.Click(Report.report,"report module");
        }
        [When(@"the user enters the non existent report name(.*)")]
        public async Task Enter_report_name(string rep_name)
        {
            await report.searchreport(rep_name);
        }
    }
}
