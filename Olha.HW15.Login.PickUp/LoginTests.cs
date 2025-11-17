using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Olha.HW15.Login.PickUp
{
    public class LoginTests : BaseTests
    { 

        [TestCase("Olha")]
        public void TestLogin(string expectedusername)
        {
            //Loged in in OneTimeSetUp()
            string logedinuser = drv.FindElement(By.CssSelector("[data-testid=currentLogedUserDisplayAs]")).Text;
            StringAssert.Contains(expectedusername, logedinuser);
        }

        [TestCase("notexistentuserid", ENT_QA_PASS, ENT_QA_COMPANY, "Invalid User ID or Password")]
        [TestCase("", ENT_QA_PASS, ENT_QA_COMPANY, "Invalid User ID or Password")]
        [TestCase(ENT_QA_USER, "incorrectPassword", ENT_QA_COMPANY, "Invalid User ID or Password")]
        [TestCase(ENT_QA_USER, "", ENT_QA_COMPANY, "Invalid User ID or Password")]
        [TestCase(ENT_QA_USER, ENT_QA_PASS, "Nonexistent Company Name", "Invalid company name")]
        [TestCase(ENT_QA_USER, ENT_QA_PASS, "", "Invalid company name")]

        public void TestLoginWithTestCase(string username, string password, string company, string expectedtext)
        {
            drv.Navigate().GoToUrl(Environment.GetEnvironmentVariable(ENT_QA_URL));

            drv.FindElement(By.Id("username")).Clear();
            drv.FindElement(By.Id("username")).SendKeys(Environment.GetEnvironmentVariable(username) ?? username);
            drv.FindElement(By.Id("password")).Clear();
            drv.FindElement(By.Id("password")).SendKeys(Environment.GetEnvironmentVariable(password) ?? password);
            drv.FindElement(By.Id("_companyText")).Clear();
            drv.FindElement(By.Id("_companyText")).SendKeys(Environment.GetEnvironmentVariable(company) ?? company);
            drv.FindElement(By.CssSelector("button[type=submit")).Click();

            var errortext = drv.FindElement(By.CssSelector(".validation-summary-errors ul li")).Text;
            StringAssert.Contains(expectedtext, errortext);
        }
    }

}