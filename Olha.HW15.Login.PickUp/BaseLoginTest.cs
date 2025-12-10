using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olha.HW15.Login.PickUp
{
    public class BaseLoginTest : BaseTests
    {
        [OneTimeSetUp]
        public void Login()
        {
            SuccessLogin();
        }
        public void SuccessLogin()
        {
            drv.Navigate().GoToUrl(Environment.GetEnvironmentVariable(ENT_QA_URL));
            drv.FindElement(By.Id("username")).SendKeys(Environment.GetEnvironmentVariable(ENT_QA_USER));
            drv.FindElement(By.Id("password")).SendKeys(Environment.GetEnvironmentVariable(ENT_QA_PASS));
            drv.FindElement(By.Id("_companyText")).SendKeys(Environment.GetEnvironmentVariable(ENT_QA_COMPANY));
            drv.FindElement(By.CssSelector("button[type=submit]")).Click();
        }

        [TestCase("Olha")]
        public void TestSuccessLogin(string expectedUserName)
        {
            //Loged in in OneTimeSetUp()
            string logedInUser = drv.FindElement(By.CssSelector("[data-testid=currentLogedUserDisplayAs]")).Text;
            StringAssert.Contains(expectedUserName, logedInUser);
        }
    }
}
