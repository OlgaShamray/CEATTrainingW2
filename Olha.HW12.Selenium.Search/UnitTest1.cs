using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Olha.HW12.Selenium.Search
{
    public class Tests
    {
        IWebDriver drv;

        [SetUp]
        public void Setup()
        {
            ChromeOptions opt = new ChromeOptions();
            //opt.AddArguments("start-maximized", "auto-open-devtools-for-tabs");
            opt.AddArguments("start-fullscreen");
            //opt.AddArguments("auto-open-devtools-for-tabs");
            drv = new ChromeDriver(opt);
        }

        [TearDown]
        public void TearDown()
        {
            //drv.Quit();
            drv.Dispose();
        }

        [Test]
        public void TestCookie()
        {
            drv.Navigate().GoToUrl("https://www.google.com");

            foreach (var cookie in drv.Manage().Cookies.AllCookies)
            {
                Console.WriteLine("Default cookies:" + cookie.Name + " = " + cookie.Value);
            }
            drv.Manage().Cookies.AddCookie(new Cookie("myCookie", "myValue"));

            foreach (var cookie in drv.Manage().Cookies.AllCookies)
            {
                Console.WriteLine("Cookies after add:" + cookie.Name + " = " + cookie.Value);
            }
            drv.Manage().Cookies.DeleteCookieNamed("myCookie");

            foreach (var cookie in drv.Manage().Cookies.AllCookies)
            {
                Console.WriteLine("Cookies after delete:" + cookie.Name + " = " + cookie.Value);
            }
            drv.Manage().Cookies.DeleteAllCookies();

            foreach (var cookie in drv.Manage().Cookies.AllCookies)
            {
                Console.WriteLine("Cookies after delete ALL:" + cookie.Name + " = " + cookie.Value);
            }

            drv.FindElement(By.CssSelector("[name=q]")).SendKeys("Selenium");

        }

        [Test]
        public void Test2()
        {
            drv.Navigate().GoToUrl("https://www.google.com");

            drv.FindElement(By.Name("q")).SendKeys("Selenium");
        }

        [Test]
        public void Test3()
        {
            drv.Navigate().GoToUrl("https://www.google.com");

            var myElement = drv.FindElement(By.Name("q"));
            myElement.SendKeys("Selenium");
            myElement.SendKeys("Selenium");
            myElement.SendKeys("Selenium");
        }

        [Test]
        public void Test4()
        {
            drv.Navigate().GoToUrl("https://www.google.com");

            var myElement = drv.FindElement(By.Name("q"));        //find element
            myElement.SendKeys("Selenium");                       //action with the element

            myElement = drv.FindElement(By.Name("q"));
            myElement.SendKeys("Selenium");

            myElement = drv.FindElement(By.Name("q"));
            myElement.SendKeys("Selenium");

            drv.FindElement(By.Name("q")).SendKeys("Selenium");

        }
        [Test]
        public void Test5()
        {
            drv.Navigate().GoToUrl("https://www.google.com");

            drv.FindElement(By.Name("q")).SendKeys("Selenium");  //find and action in one line
            drv.FindElement(By.Id("APjFqb")).SendKeys("Selenium");
            //drv.FindElement(By.CssSelector("textarea.gLFuf")).SendKeys("Selenium");

        }
    }
}