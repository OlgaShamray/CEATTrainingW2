using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Olha.HW15.Login.PickUp
{
    internal class PickUpTests : BaseTests
    {

        [Test]
        public void TestPickUp()
        {
            //Loged in in OneTimeSetUp()
            
            //Navigate to WO list page
            drv.Navigate().GoToUrl(Environment.GetEnvironmentVariable(ENT_QA_URL) + "/workorder/workorderlist.aspx");

            //Find first WO with "New" status and expected assignee, save WO number and open QV dialog
            var woLink = By.XPath("(//tr[.//td[@data-testid='WOStatus']/span[contains(text(), 'New')] and .//td[@data-testid='EmpName']/a[contains(text(), 'Olha')]]/td[@data-testid='Number']/a)[1]");
            wait.Until(ExpectedConditions.ElementToBeClickable(woLink)).Click();
            var woNumber = drv.FindElement(woLink).Text;
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid=WoQvDialog__dialog]")));

            // Perform Pick-Up action
            drv.FindElement(By.CssSelector(".main-action .area-action-item[title=Pick-Up]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid=WoActionPickupEditDialog__dialog]")));
            drv.FindElement(By.CssSelector("[data-testid=WoActionPickupEditDialog__dialog] [data-testid=id-btn-save]")).Click();

            // Check that action is logged in Activity Log
            var tableActivityLog = drv.FindElement(By.CssSelector("[data-testid=WoActivityLogGridQvSection__section] tbody"));
            wait.Until(ExpectedConditions.StalenessOf(tableActivityLog));
            var loggedActions = drv.FindElements(By.CssSelector("[data-testid=WoActivityLogGridQvSection__section] [data-testid=ActionTitle]"));
            Assert.IsTrue(loggedActions[0].Text.Contains("Picked Up"));

            // Close WO QV dialog
            drv.FindElement(By.CssSelector("[data-testid=WoQvDialog__dialog] [data-testid=id-btn-close]")).Click();
            wait.Until(ExpectedConditions.StalenessOf(drv.FindElement(By.CssSelector(".selected-line-grid"))));

            //variant 1 to find updated status - the most reliable variant
            var updatedStatusElement = drv.FindElement(By.XPath($".//div[contains(@class, 'id-wo-list-grid')]//table//tr//td//a[normalize-space(text())='{woNumber}']"))
                .FindElement(By.XPath("./ancestor::tr"))
                .FindElement(By.CssSelector("[data-testid=WOStatus]"));
            var statusEx = updatedStatusElement.Text;
            Assert.IsTrue(statusEx == "Open");

            //variant 2 to find updated status - the most reliable variant
            var updatedStatusElement1 = drv.FindElement(By.LinkText(woNumber))
               .FindElement(By.XPath("./ancestor::tr"))
               .FindElement(By.CssSelector("[data-testid=WOStatus]"));
            Assert.IsTrue(updatedStatusElement1.Text == "Open");

            //variant 3 to find updated status
            var updatedStatusElement2 = drv.FindElement(By.CssSelector("tr.selected-line-grid td[data-testid=WOStatus]")).Text;
            Assert.IsTrue(updatedStatusElement2 == "Open");

        }
    }
}
