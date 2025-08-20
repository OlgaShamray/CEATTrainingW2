using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Olha.HW11.Selenium.Intro
{
    public class Tests
    {
        IWebDriver drvCh;
        IWebDriver drvFf;

        [SetUp]
        public void Setup()
        {
            drvCh = new ChromeDriver();
            drvFf = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()  
        {
            drvCh.Quit();
            drvCh.Dispose();
            drvFf.Quit();
            drvFf.Dispose();
        }   

        [Test]
        public void TestChrome()
        {
            drvCh.Navigate().GoToUrl("https://www.google.com");
            drvCh.FindElement(By.CssSelector("[name=q]")).SendKeys("Selenium");
        }
        [Test]
        public void TestFirefox()
        {
            drvFf.Navigate().GoToUrl("https://www.google.com");
            drvFf.FindElement(By.CssSelector("[name=q]")).SendKeys("Selenium");
        }
    }
}