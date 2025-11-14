using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Olha.HW15.Login.PickUp
{
    internal class PickUpTests : BaseTests
    {

        [Test]
        public void TestPickUp()
        {
            //Login
            SuccessLogin();
            string logedinuser = drv.FindElement(By.CssSelector("[data-testid=currentLogedUserDisplayAs]")).Text;
            StringAssert.Contains("Olha", logedinuser);

            //Navigate to WO list page
            drv.Navigate().GoToUrl(Environment.GetEnvironmentVariable(ENT_QA_URL) + "/workorder/workorderlist.aspx");
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid=WoListPage__page]")));
            /*
            wait.Until(drv => !drv.FindElements(By.CssSelector("div.blockUI.blockOverlay")).Any());
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[aria-owns=dropdown-598]"))).Click();;
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[aria-owns=dropdown-893]"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid=WoListPage__page]")));
            */

            //Find first WO with "New" status, save WO number and open QV dialog
            var wolink = By.XPath("(//td[@data-testid='WOStatus']/span[contains(text(), 'New')]/ancestor::td/following-sibling::td/a)[1]");
            var wonumber = drv.FindElement(wolink).Text;
            wait.Until(ExpectedConditions.ElementToBeClickable(wolink)).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid=WoQvDialog__dialog]")));

            //Check if Pick-Up action is available
            try
            {
                var mainAction = drv.FindElement(By.CssSelector(".main-action .area-action-item[title=Pick-Up]"));
                if (mainAction != null)
                {
                    mainAction.Click();
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid=WoActionPickupEditDialog__dialog]")));
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Pick-Up action is not available");
            }

            // Perform Pick-Up action
            drv.FindElement(By.CssSelector("[data-testid=WoActionPickupEditDialog__dialog] [data-testid=id-btn-save]")).Click();

            // Check that action is logged in Activity Log
            var tableActivityLog = drv.FindElement(By.CssSelector("[data-testid=WoActivityLogGridQvSection__section] tbody"));
            wait.Until(ExpectedConditions.StalenessOf(tableActivityLog));
            var loggedactions = drv.FindElements(By.CssSelector("[data-testid=WoActivityLogGridQvSection__section] [data-testid=ActionTitle]"));
            Assert.IsTrue(loggedactions[0].Text.Contains("Picked Up"));

            // Close WO QV dialog
            drv.FindElement(By.CssSelector("[data-testid=WoQvDialog__dialog] [data-testid=id-btn-close]")).Click();
            //var tableWOlist = drv.FindElement(By.CssSelector("#WoListGrid tbody"));
            //wait.Until(ExpectedConditions.StalenessOf(tableWOlist));
            wait.Until(ExpectedConditions.StalenessOf(drv.FindElement(By.CssSelector(".selected-line-grid"))));

            //variant 1 to find updated status
            var updatedstatuselement = drv.FindElement(By.XPath($".//div[contains(@class, 'id-wo-list-grid')]//table//tr//td//a[normalize-space(text())='{wonumber}']"))
                .FindElement(By.XPath("./ancestor::tr"))
                .FindElement(By.CssSelector("[data-testid=WOStatus]"));
            var statusEx = updatedstatuselement.Text;
            Assert.IsTrue(statusEx == "Open");

            //variant 2 to find updated status
            var updatedstatuselement1 = drv.FindElement(By.LinkText(wonumber))
               .FindElement(By.XPath("./ancestor::tr"))
               .FindElement(By.CssSelector("[data-testid=WOStatus]"));
            Assert.IsTrue(updatedstatuselement1.Text == "Open");

            //variant 3 to find updated status
            var updatedstatuselement2 = drv.FindElement(By.CssSelector("tr.selected-line-grid td[data-testid=WOStatus]")).Text;
            Assert.IsTrue(updatedstatuselement2 == "Open");














        }
    }
}
