using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

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
        public virtual void OneTimeSetUp()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArguments("--lang=en-US");
            
            // Disable password manager and related prompts
            opt.AddUserProfilePreference("credentials_enable_service", false);
            opt.AddUserProfilePreference("profile.password_manager_enabled", false);
            opt.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            
            drv = new ChromeDriver(opt);
            //drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait
            wait = new WebDriverWait(drv, TimeSpan.FromSeconds(30));           //emplicit wait
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            drv?.Quit();
            drv?.Dispose();
        }
    }
}
