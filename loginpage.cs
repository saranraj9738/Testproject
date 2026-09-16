using Microsoft.Playwright;
using System.Threading.Tasks;
using Testproject2.locators;

namespace Testproject2.page
{
    public class Login
    {
        private readonly IPage _page;

        public Login(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToUrl(string loginurl)
        {
            await _page.GotoAsync(loginurl);
        }

        public async Task EnterUsernameAndPassword(string user, string pass)
        {
            await _page.Locator(login.Username).FillAsync(user);
            await _page.Locator(login.Password).FillAsync(pass);
        }
    }
}
