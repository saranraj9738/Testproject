using TechTalk.SpecFlow;
using Testproject2.page;
using Testproject2.locators;
using Testproject2.fixture;
namespace Testproject2.steps
{
    [Binding]
    public class Addsteps
    {
        private readonly PlaywrightDriver _driver;
        private readonly CommonPage commonpage;
        private readonly Addemp addpage;
        public Addsteps(PlaywrightDriver driver)
        {
            _driver = driver;
            commonpage = new CommonPage(_driver.Page);
            addpage = new Addemp(_driver.Page);
        }
        [Given(@"the user is on the OrangeHRM dashboard")]
        public async Task Givendashboard()
        {
            await addpage.Dashboard();
        }
        [When(@"the user click the PIM module")]
        public async Task Clickpimmodule()
        {
            await commonpage.Click(addemp.pim,"pim module");
        }
        [When(@"the user click the Add Employee module")]
        public async Task Clickaddemployeemodule()
        {
            await commonpage.Click(addemp.add,"add employee");
        }
        [When(@"the user enters a firstname (.*),middlename (.*),lastname (.*),employee id (.*)")]
        public async Task Enternameandid(string first, string middle, string last, string id)
        {
            await addpage.AddEmployee(first, middle, last, id);
        }
        [When(@"the user leaves the firstname (.*) and lastname (.*) field blank")]
        public async Task Leavesnameandidblank(string first, string last)
        {
            await addpage.AddEmployee(first, "", last, "");
        }
        [When(@"the user click the save button")]
        public async Task Clicksavebutton()
        {
            await commonpage.Click(addemp.Button,"save button");
        }
        [Then(@"the user should navigate to the personal details profile page")]
        public async Task Navigatetothepersonaldetails()
        {
            await addpage.VerifyNavigationToPersonalDetails();
        }
        [Then(@"the individual field validation tags should display ""(.*)""")]
        public async Task Validationtagsshoulddisplay(string expectedtext)
        {
            await addpage.VerifyFieldValidationTags(expectedtext);
        }
    }
}
