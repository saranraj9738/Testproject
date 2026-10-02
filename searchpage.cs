using Microsoft.Playwright;
using NUnit.Framework;
using Testproject2.locators;
namespace Testproject2.page
{
    public class Search
    {
        private readonly IPage _page;
        private readonly CommonPage commonPage;
        public Search(IPage page)
        {
            _page = page;
            commonPage = new CommonPage(_page);
        }
        public async Task SearchEmployee(string empname,string empid)
        {
            await commonPage.Fill(Empsearch.empname,empname,"employee name is filled");
            await commonPage.Fill(Empsearch.empid, empid, "employee id is filled");
        }
        public async Task VerifyRecordFoundMessage(string expectedmessage)
        {
            var recordfound = _page.Locator(Empsearch.record);
            await recordfound.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });
            bool isvisible = await recordfound.IsVisibleAsync();
            if(isvisible)
            {
                string record = await recordfound.InnerTextAsync();
                if(record.Contains(expectedmessage))
                {
                    CommonPage.Test.Pass($"message was found {expectedmessage}");
                }
                else
                {
                    CommonPage.Test.Fail($"message was not found {expectedmessage}");
                    Assert.Fail($"message was not found {expectedmessage}");
                }
            }
            else
            {
                CommonPage.Test.Fail($"Element not visible{isvisible}");
                Assert.Fail($"Element not visible{isvisible}");
            }
        }
        public async Task VerifyNoRecordFoundMessage(string expectedMessage)
        {
            var no_record = _page.Locator(Empsearch.norecord);
            await no_record.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });
            bool isvisible = await no_record.IsVisibleAsync();
            if(isvisible)
            {
                string not_found = await no_record.InnerTextAsync();
                if(not_found.Contains(expectedMessage))
                {
                    CommonPage.Test.Pass($"message was found {expectedMessage}");
                }
                else
                {
                    CommonPage.Test.Fail($"message was not found{expectedMessage}");
                    Assert.Fail($"message was not found{expectedMessage}");
                }
            }
            else
            {
                CommonPage.Test.Fail($"Element not visible{isvisible}");
                Assert.Fail($"Element not visible {expectedMessage}");
            }
        }
    }
}
