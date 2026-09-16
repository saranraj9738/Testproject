using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace Testproject2.fixture
{
    [Binding]
    public class PlaywrightDriver
    {
        public IPlaywright _playwright = null!;
        public IBrowser _browser = null!;
        public IBrowserContext _context = null!;
        public IPage Page = null!;
    }
}
