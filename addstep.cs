using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Testproject2.fixture;
using Testproject2.page;
using Testproject2.locators;

namespace Testproject2.step
{
    [Binding]
    public class Addsteps
    {
        private readonly PlaywrightDriver _driver;

        public Addsteps(PlaywrightDriver driver)
        {
            _driver = driver;
        }

        [Given(@"the user login to the OrangeHRM portal")]
        public async Task GivenTheUserLoginToTheOrangeHRMPortal()
        {
            Login loginPage = new Login(_driver.Page);

            var config = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("json/data.json", optional: false)
                .Build();

            await loginPage.NavigateToUrl(config["loginurl"]);
            await loginPage.EnterUsernameAndPassword(config["userdata"], config["passworddata"]);
            await loginPage.ClickLoginButton();

            await _driver.Page.WaitForTimeoutAsync(10000); 
        }

        [Given(@"the user click the PIM module")]
        public async Task GivenTheUserClickThePIMModule()
        {
            CommonPage commonPage = new CommonPage(_driver.Page);
            await commonPage.Click(addemp.pim);
        }

        [Given(@"the user click the Add Employee module")]
        public async Task GivenTheUserClickTheAddEmployeeModule()
        {
            CommonPage commonPage = new CommonPage(_driver.Page);
            await commonPage.Click(addemp.add);
        }

        [When(@"the user enters a firstname(.*),middlename(.*),lastname(.*),employee id(.*)")]
        public async Task WhenTheUserEntersAFirstnameMiddlenameLastnameAndEmployeeId(string first, string middle, string last, string id)
        {
            Addemp addEmpPage = new Addemp(_driver.Page);
            await addEmpPage.AddEmployee(first, middle, last, id);
        }

        [When(@"the user leaves the firstname(.*) and lastname(.*) field blank")]
        public async Task WhenTheUserLeavesTheFirstnameAndLastnameFieldBlank(string first, string last)
        {
            Addemp addEmpPage = new Addemp(_driver.Page);
            await addEmpPage.AddEmployee(first, "", last, "");
        }

        [When(@"the user click the save button")]
        public async Task WhenTheUserClickTheSaveButton()
        {
            CommonPage commonPage = new CommonPage(_driver.Page);
            await commonPage.Click(addemp.Button);
        }
        [Then(@"the user should navigate to the personal details profile page")]
        public async Task ThenTheUserShouldNavigateToThePersonalDetailsProfilePage()
        {
            await _driver.Page.WaitForURLAsync("**/viewPersonalDetails/empNumber/**", new PageWaitForURLOptions
            {
                Timeout = 10000
            });
            if (!_driver.Page.Url.Contains("viewPersonalDetails"))
            {
                throw new System.Exception($"Assertion Failed: Expected to navigate to the personal details profile page, but remained on: {_driver.Page.Url}");
            }
        }
        [Then(@"the individual field validation tags should display ""(.*)""")]
        public async Task ThenTheIndividualFieldValidationTagsShouldDisplay(string expectedValidationText)
        { 
            var firstErrorLocator = _driver.Page.Locator(addemp.firsterror);
            var lastErrorLocator = _driver.Page.Locator(addemp.lasterror);

            try
            {
                await Assertions.Expect(firstErrorLocator).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 10000 });
                await Assertions.Expect(lastErrorLocator).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 10000 });
                string firstText = await firstErrorLocator.InnerTextAsync();
                string lastText = await lastErrorLocator.InnerTextAsync();

                if (!firstText.Contains(expectedValidationText) || !lastText.Contains(expectedValidationText))
                {
                    throw new System.Exception($"Text Mismatch: Expected messages to read '{expectedValidationText}', but saw First: '{firstText}', Last: '{lastText}'");
                }
            }
            catch (System.Exception ex)
            {
                bool isFirstVisible = await firstErrorLocator.IsVisibleAsync();
                bool isLastVisible = await lastErrorLocator.IsVisibleAsync();

                throw new System.Exception($"Assertion Failed: Individual field verification crashed. " +
                    $"First Name Error Box Visible: {isFirstVisible}, Last Name Error Box Visible: {isLastVisible}. " +
                    $"Details: {ex.Message}");
            }
        }
    }
}
