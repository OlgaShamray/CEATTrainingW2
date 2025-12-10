using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using NUnit.Framework;
using System;

namespace Olha.HW15.Login.PickUp
{
    internal class ReportGeneration : BaseLoginTest
    {
        [Test]
        public void TestReportGeneration()
        {
            //Logged in in OneTimeSetUp()
            var initialHandle = drv.CurrentWindowHandle;

            //Navigate to Report List page
            drv.Navigate().GoToUrl(Environment.GetEnvironmentVariable(ENT_QA_URL) + "/report/reportlist.aspx");
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".reports-list-grid")));
           
            Thread.Sleep(100);

            //Find first report
            var reportLink = By.CssSelector("(td[data-testid=DisplayAs] a)[0]");
            var reportName = drv.FindElement(reportLink).Text;

            //Open Generate Report Dialog
            wait.Until(ExpectedConditions.ElementToBeClickable(reportLink)).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid=GenerateReportDialog__dialog]")));

            //var reportName = drv.FindElements(reportLink).First().Text;

            var showHeaderSwitch = drv.FindElement(By.CssSelector("[data-testid=showHeader]"));

            if (showHeaderSwitch.GetAttribute("aria-checked") == "false")
            {
                showHeaderSwitch.Click();
            }

            //Click Generate button
            var initialWindowCount = drv.WindowHandles.Count;
            drv.FindElement(By.CssSelector("[data-testid=id-generate-button]")).Click();

            //Wait for new window to open
            wait.Until(driver => driver.WindowHandles.Count > initialWindowCount);

            //Switch to new window
            drv.SwitchTo().Window(drv.WindowHandles.Last());

            //Wait for page to load
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[style='width:167.64mm;min-width: 167.64mm;'] span")));

            //Verify report header
            var reportHeader = drv.FindElements(By.CssSelector("div[style='width:167.64mm;min-width: 167.64mm;'] span")).First().Text;
            Assert.IsTrue(reportHeader.Equals(reportName));

            //Close new window
            drv.Close();

            //Switch back to main window
            drv.SwitchTo().Window(initialHandle);

            //Click Close button on Generate Report Dialog
            drv.FindElement(By.CssSelector("[data-testid=GenerateReportDialog__dialog] [data-testid=id-btn-close]")).Click();

            //Verify report list page
            Assert.IsTrue(drv.FindElement(By.CssSelector(".reports-list-grid")).Displayed);
        }
    }
}

