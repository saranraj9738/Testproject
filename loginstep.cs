using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System.Security.AccessControl;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testproject2.fixture;
using Testproject2.locators;
using Testproject2.page;

namespace Testproject2.step
{
    [Binding]
    public class LoginSteps
    {
        private readonly PlaywrightDriver _driver;
        private readonly IConfiguration _config;

        
        public LoginSteps(PlaywrightDriver driver)
        {
            _driver = driver;

            _config = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("json/data.json", optional: false)
                .Build();
        }

        
        [Given(@"the user opens a OrangeHRM login page")]
        public async Task GivenTheUserOpensAOrangeHRMLoginPage()
        {
            string urlData = _config["loginurl"];
            Login loginPage = new Login(_driver.Page);
            await loginPage.NavigateToUrl(urlData);
        }
        [When(@"the user enters a valid username and password")]
        public async Task WhenTheUserEntersAValidUsernameAndPassword()
        {
            string userData = _config["userdata"];
            string passData = _config["passworddata"];

            Login loginPage = new Login(_driver.Page);
            await loginPage.EnterUsernameAndPassword(userData, passData);
            CommonPage commonPage = new CommonPage(_driver.Page);
            await commonPage.Click(login.Button);
        }

        
        [When(@"the user enters a invalid username and password")]
        public async Task WhenTheUserEntersAInvalidUsernameAndPassword()
        {
            string invalidUser = _config["invaliduser"];
            string invalidPassword = _config["invalidpassword"];

            Login loginPage = new Login(_driver.Page);
            await loginPage.EnterUsernameAndPassword(invalidUser, invalidPassword);
            CommonPage commonPage = new CommonPage(_driver.Page);
            await commonPage.Click(login.Button);
        }

        
        [Then(@"the user navigates to the dashboard page")]
        public async Task ThenTheUserNavigatesToTheDashboardPage()
        {
            string expectedUrl = _config["dashurl"];
            await _driver.Page.WaitForURLAsync(expectedUrl, new PageWaitForURLOptions { Timeout = 10000 });
        }
        [Then(@"the user should see the login validation message ""(.*)""")]
        public async Task ThenTheUserShouldSeeTheLoginValidationMessage(string expectedMessage)
        { 

            try
            {
                await Assertions.Expect(_driver.Page.Locator(login.invalid)).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
                {
                    Timeout = 10000
                });

               string actualtext = await _driver.Page.Locator(login.invalid).InnerTextAsync();

              if (!actualtext.Contains(expectedMessage))
                {
                    throw new System.Exception($"Assertion Failed: Alert text mismatch! Expected to see '{expectedMessage}', but the text read '{actualtext}' instead.");
                }
            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception($"Assertion Failed: Unsuccessful login validation failed. The red error message did not paint on screen. Details: {ex.Message}");
            }
        }

    }
}
