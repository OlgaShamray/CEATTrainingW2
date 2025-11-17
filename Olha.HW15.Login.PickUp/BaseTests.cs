using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Olha.HW15.Login.PickUp
{
    public class BaseTests
    {
        protected IWebDriver drv;
        protected WebDriverWait wait;
        protected const string ENT_QA_URL = "ENT_QA_URL";
        protected const string ENT_QA_USER = "ENT_QA_USER";
        protected const string ENT_QA_PASS = "ENT_QA_PASS";
        protected const string ENT_QA_COMPANY = "ENT_QA_COMPANY";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArguments("--lang=en-US");
            drv = new ChromeDriver(opt);
            //drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait
            wait = new WebDriverWait(drv, TimeSpan.FromSeconds(30));           //eplicit wait
            SuccessLogin();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            drv.Quit();
            drv.Dispose();
        }

        public void SuccessLogin()
        {
            drv.Navigate().GoToUrl(Environment.GetEnvironmentVariable(ENT_QA_URL));
            drv.FindElement(By.Id("username")).SendKeys(Environment.GetEnvironmentVariable(ENT_QA_USER));
            drv.FindElement(By.Id("password")).SendKeys(Environment.GetEnvironmentVariable(ENT_QA_PASS));
            drv.FindElement(By.Id("_companyText")).SendKeys(Environment.GetEnvironmentVariable(ENT_QA_COMPANY));
            drv.FindElement(By.CssSelector("button[type=submit")).Click();
        }
    }
}
