using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Remote;

namespace SeleniumDemoUI
{
    [TestClass]
    public class BuscarGoogleFail
    {
        [TestMethod]
        public void BuscarFacebookFail()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            using (var _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {

                _driver.Navigate().GoToUrl("https://www.google.com/");
                _driver.Manage().Window.Maximize();

                IWebElement query2 = _driver.FindElement(By.Name("q"));
                query2.SendKeys("facebook");

                query2.Submit();

                Assert.AreEqual(_driver.Title, "facebook - Search Google");
            }
        }
    }
}
