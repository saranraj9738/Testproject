using TechTalk.SpecFlow;
using Testproject2.page;
using Testproject2.locators;
using Testproject2.fixture;
namespace Testproject2.steps
{
    [Binding]
    public class Searchsteps
    {
        private readonly PlaywrightDriver _driver;
        private readonly CommonPage commonpage;
        private readonly Search searchpage; 
        public Searchsteps(PlaywrightDriver driver)
        {
            _driver = driver;
            commonpage = new CommonPage(_driver.Page);
            searchpage = new Search(_driver.Page); 
        }
        [When(@"the user click the Employee List module")]
        public async Task Clickemployeelistmodule()
        {
            await commonpage.Click(Empsearch.emplist,"employee list");
        }
        [When(@"the user enters a employee name (.*),employee id (.*)")]
        public async Task Enternameandid(string empName, string empid)
        {            
            await searchpage.SearchEmployee(empName, empid);
        }
        [When(@"the user enters a not exists employee name(.*),employee id(.*)")]
        public async Task Entersnotexistsnameandid(string empName, string empid)
        {   
            await searchpage.SearchEmployee(empName, empid);
        }
        [When(@"the user click the search button")]
        public async Task Clicksearchbutton()
        {
            await commonpage.Click(Empsearch.Button,"search button");
        }
        [Then(@"the user should see the ""(.*)"" message")]
        public async Task Recordfoundmessage(string expectedMessage)
        {   
            await searchpage.VerifyRecordFoundMessage(expectedMessage);
        }
        [Then(@"the user should see ""(.*)"" message")]
        public async Task Norecordfoundmessage(string expectedMessage)
        {
            await searchpage.VerifyNoRecordFoundMessage(expectedMessage);
        }
    }
}
