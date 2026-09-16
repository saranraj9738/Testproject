
namespace Testproject2.locators
{
    internal class Empsearch
    {
        public static string empname ="//label[text()='Employee Name']/ancestor::div[contains(@class,'oxd-input-group')]//input";
        public static string empid = "//label[text()='Employee Id']/ancestor::div[contains(@class,'oxd-input-group')]//input";
        public static string empstatus = "//label[text()='Employment Status']/ancestor::div[contains(@class,'oxd-input-group')]//div[@class='oxd-select-text-input']";
        public static string fulltimep = "//div[contains(@class,'oxd-select-text')]/child::div[@class='oxd-select-text-input'][text()='Full-Time Permanent']";
        public static string include = "//label[text()='Include']/ancestor::div[contains(@class,'oxd-input-group')]//div[@class='oxd-select-text-input']";
        public static string currentemp = "//div[contains(@class,'oxd-select-text')]/child::div[@class='oxd-select-text-input'][text()='Current Employees Only']";
        public static string supervisior = "//label[text()='Supervisor Name']/ancestor::div[contains(@class,'oxd-input-group')]//input";
        public static string jobtitle= "//label[text()='Job Title']/ancestor::div[contains(@class,'oxd-input-group')]//div[@class='oxd-select-text-input']";
        public static string hrasso = "//div[contains(@class,'oxd-select-text')]/child::div[@class='oxd-select-text-input'][text()='HR Associate']";
        public static string subunit = "//label[text()='Sub Unit']/ancestor::div[contains(@class,'oxd-input-group')]//div[@class='oxd-select-text-input']";
		public static string engineer = "//div[contains(@class,'oxd-select-text')]/child::div[@class='oxd-select-text-input'][text()='Engineering']";
		public static string Button = "//button[@type='submit']";
        public static string emplist = "//a[contains(text(),'Employee List')]";
        public static string pim = "//nav[@aria-label='Sidepanel']//span[text()='PIM']";

        public static string record = "//div[contains(@class,'orangehrm-horizontal')]/child::span[text()='(1) Record Found']";
        public static string norecord = "//div[contains(@class,'orangehrm-horizontal')]/child::span[text()='No Records Found']";
            

    }
}
