using TechTalk.SpecFlow;
using Testproject2.page;
using Testproject2.locators;
using Testproject2.fixture;
namespace Testproject2.steps
{
    [Binding]
    public class Directorysteps
    {
        private readonly PlaywrightDriver _driver;
        private readonly CommonPage commonpage;
        private readonly directory directorypage;
        public Directorysteps(PlaywrightDriver driver)
        {
            _driver = driver;
            commonpage = new CommonPage(_driver.Page);
            directorypage = new directory(_driver.Page);
        }
        [When(@"the user click the Directory module")]
        public async Task Clickdirectorymodule()
        {
            await commonpage.Click(direct.directory,"directory");
        }
        [When(@"the user enters a not existent employee name(.*)")]
        public async Task Enterwrongname(string name)
        {
            await directorypage.searchdirectory(name);
        }
        [Then(@"the validation tag should display ""(.*)""")]
        public async Task Validationtagshoulddisplay(string expectedValidationText)
        {
            await directorypage.Validation(expectedValidationText);
        }
    }
}

