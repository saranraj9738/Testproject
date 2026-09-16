using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testproject2.fixture;

namespace Testproject2.utils
{
    [Binding]
    public class Hooks
    {
        private readonly PlaywrightDriver _driver;

        public Hooks(PlaywrightDriver driver)
        {
            _driver = driver;
        }

        [BeforeScenario]
        public async Task SetupBrowser()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("json/data.json", optional: false)
                .Build();


            if (_driver._playwright == null)
            {
                _driver._playwright = await Playwright.CreateAsync();
            }

            
            if (_driver._browser == null)
            {
                _driver._browser = await _driver._playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = bool.Parse(config["Headless"]),
                    SlowMo = int.Parse(config["SlowMo"])
                });
            }

            
            _driver._context = await _driver._browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = int.Parse(config["ViewportWidth"]),
                    Height = int.Parse(config["ViewportHeight"])
                }
            });

            _driver.Page = await _driver._context.NewPageAsync();
        }

        [AfterScenario]
        public async Task TearDownBrowser()
        {
            
            if (_driver._context != null)
            {
                await _driver._context.CloseAsync();
            }
        }
    }
}
