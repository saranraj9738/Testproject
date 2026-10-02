using Microsoft.Extensions.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using Testproject2.fixture;
using Testproject2.locators;
using System.IO;
using Testproject2.page;
namespace Testproject2.utils
{
    [Binding]
    public class Hooks
    {
        private readonly PlaywrightDriver _driver;
        private static ExtentReports extent;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        public Hooks(PlaywrightDriver driver)
        {
            _driver = driver;            
        }
        [BeforeTestRun]
        public static void extentreport()
        {
            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
            if (!Directory.Exists(reportPath)) Directory.CreateDirectory(reportPath);
            var sparkReporter = new ExtentSparkReporter(Path.Combine(reportPath, "UIAutomationReport.html"));
            sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
            sparkReporter.Config.ReportName = "UI Automation Test Report";
            sparkReporter.Config.DocumentTitle = "ExtentReports";
            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);
        }
        [BeforeFeature]
        public static void Beforefeature(FeatureContext feature_context)
        {
            feature = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(feature_context.FeatureInfo.Title);
        }
        [BeforeScenario]
        public async Task SetupBrowserAndUiLogin(ScenarioContext scenario_context)
        {
            scenario = feature.CreateNode<Scenario>(scenario_context.ScenarioInfo.Title);
            CommonPage.Test = scenario;
            var config = new ConfigurationBuilder().SetBasePath(System.AppContext.BaseDirectory).AddJsonFile("json/data.json", optional: false).Build();
            _driver._playwright = await Playwright.CreateAsync();
            _driver._browser = await _driver._playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = bool.Parse(config["Headless"]),
                SlowMo = int.Parse(config["SlowMo"])
            });
            _driver._context = await _driver._browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = int.Parse(config["ViewportWidth"]),
                    Height = int.Parse(config["ViewportHeight"])
                }
            });
            _driver.Page = await _driver._context.NewPageAsync();
            await _driver.Page.GotoAsync(config["loginurl"], new PageGotoOptions { Timeout = 10000 });
            await _driver.Page.Locator(login.Username).FillAsync(config["userdata"]);
            await _driver.Page.Locator(login.Password).FillAsync(config["passworddata"]);
            CommonPage commonPage = new CommonPage(_driver.Page);
            await commonPage.Click(login.Button,"login button clicked");
        }
        [BeforeStep]
        public void BeforeStep(ScenarioContext scenario_context)
        {
            var stepType = scenario_context.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepText = scenario_context.StepContext.StepInfo.Text;
            ExtentTest activeStepNode = null;
            if (stepType == "Given") activeStepNode = scenario.CreateNode<Given>(stepText);
            else if (stepType == "When") activeStepNode = scenario.CreateNode<When>(stepText);
            else if (stepType == "Then") activeStepNode = scenario.CreateNode<Then>(stepText);
            CommonPage.Test = activeStepNode;
        }
        [AfterStep]
        public  void Afterstep(ScenarioContext scenario_context)
        {
            if (scenario_context.TestError != null)
            {
                string errorMessage = scenario_context.TestError.Message;
                CommonPage.Test.Fail(errorMessage);
            }
        }
        [AfterScenario]
        public async Task TearDownBrowser()
        {
            if (_driver._browser != null)
            {
              await _driver._browser.CloseAsync();
            }
        }
        [AfterTestRun]
        public static void flushreport()
        {
            extent.Flush();
        }
    }
}
