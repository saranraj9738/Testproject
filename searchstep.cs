using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Testproject2.fixture;
using Testproject2.page;
using Testproject2.locators;

namespace Testproject2.step
{
    [Binding]
    public class Searchsteps
    {
        private readonly PlaywrightDriver _driver;

        public Searchsteps(PlaywrightDriver driver)
        {
            _driver = driver;
        }

        [Given(@"the user click the Employee List module")]
        public async Task GivenTheUserClickTheEmployeeListModule()
        {
            CommonPage commonPage = new CommonPage(_driver.Page);
            await commonPage.Click(Empsearch.emplist);
        }

        [When(@"the user enters a employee name(.*),employee id(.*)")]
        public async Task WhenTheUserEntersAEmployeeNameAndEmployeeId(string empName, string empid)
        {
            await _driver.Page.Locator(Empsearch.empname).First.FillAsync(empName);
            await _driver.Page.Locator(Empsearch.empid).First.FillAsync(empid);
        }

        [When(@"the user enters a not exists employee name(.*),employee id(.*)")]
        public async Task WhenTheUserEntersANotExistsEmployeeNameAndEmployeeId(string empName, string empid)
        {
            await _driver.Page.Locator(Empsearch.empname).First.FillAsync(empName);
            await _driver.Page.Locator(Empsearch.empid).First.FillAsync(empid);
        }

        [When(@"the user click the search button")]
        public async Task WhenTheUserClickTheSearchButton()
        {
            CommonPage commonPage = new CommonPage(_driver.Page);
            await commonPage.Click(Empsearch.Button);
        }
        [Then(@"the user should see the ""(.*)"" message")]
        public async Task ThenTheUserShouldSeeTheRecordFoundMessage(string expectedMessage)
        {
            var recordFoundLocator = _driver.Page.Locator(Empsearch.record);
           try
            {
              await Assertions.Expect(recordFoundLocator).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
                {
                    Timeout = 10000
                });
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Assertion Failed: Target text confirmation message '{expectedMessage}' failed to appear on screen. Details: {ex.Message}");
            }
        }
        [Then(@"the user should see ""(.*)"" message")]
        public async Task ThenTheUserShouldSeeTheNoRecordFoundMessage(string expectedMessage)
        {
            try
            {
                await Assertions.Expect(_driver.Page.Locator(Empsearch.norecord)).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
                {
                    Timeout = 10000
                });
                string actualGridText = await _driver.Page.Locator(Empsearch.norecord).InnerTextAsync();

                if (!actualGridText.Equals(expectedMessage))
                {
                    throw new System.Exception($"Text Mismatch: Expected exact grid message '{expectedMessage}', but saw '{actualGridText}' instead.");
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Assertion Failed: Empty search validation failed. The '{expectedMessage}' tag did not paint. Trace: {ex.Message}");
            }
        }
    }
}
