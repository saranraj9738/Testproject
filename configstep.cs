using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testproject2.page;
using Testproject2.locators;
using Testproject2.fixture;
namespace Testproject2.steps
{
    [Binding]
    public class configstep
    {
        private readonly PlaywrightDriver _driver;
        private readonly CommonPage commonpage;
        private readonly configpage configpage;
        public configstep(PlaywrightDriver driver)
        {
            _driver = driver;
            commonpage = new CommonPage(_driver.Page);
            configpage = new configpage(_driver.Page);
        }
        [When(@"the user click the configuration module")]
        public async Task Clickconfigurationmodule()
        {
            await commonpage.Click(config.configu,"configuration ");
        }
        [When(@"the user click the Reporting Methods")]
        public async Task Clickreports()
        {
            await commonpage.Click(config.report_method,"report method");
        }
        [When(@"the user click the Add button")]
        public async Task Clickadd()
        {
            await commonpage.Click(config.Add_button,"add button");
        }
        [When(@"the user enters reporting method name(.*)")]
        public async Task Reportingmethodname(string name)
        {
            await configpage.reportmethod(name);
        }
        [Then(@"the reporting method(.*) should be visible in the records list")]
        public async Task recordvisible(string expectedtext)
        {
            await configpage.reportvisible(expectedtext);
        }
    }
}
