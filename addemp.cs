
namespace Testproject2.locators
{
    internal class addemp
    {
        public static string firstname = "//input[@name='firstName']";
        public static string middlename = "//input[@name='middleName']";
        public static string lastname = "//input[@name='lastName']";
        public static string empid = "//label[text()='Employee Id']/ancestor::div[contains(@class,'oxd-input-group')]//input";
        public static string Button = "//button[@type='submit']";

        public static string pim = "//nav[@aria-label='Sidepanel']//span[text()='PIM']";

        public static string add = "//a[contains(text(),'Add Employee')]";
        public static string firsterror = "//div[contains(@class,'oxd-input-group')]/preceding-sibling::div[contains(@class,'oxd-input-group')]/span[contains(@class,'oxd-text--span')]";
        public static string lasterror = "//div[contains(@class,'oxd-input-group')]/following-sibling::div[contains(@class,'oxd-input-group')]/span[contains(@class,'oxd-text--span')]";




    }
}