using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using OpenQA.Selenium.Remote;


namespace SeleniumDemoUI
{
    [TestClass]
    public class Login
    {
        //private RemoteWebDriver _browserDriver;
        [TestMethod]
        public void Inicializacion()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            using (var _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {
                
                _driver.Navigate().GoToUrl("http://localhost:3500/user/login");
                _driver.Manage().Window.Maximize();
                //var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));

                IWebElement query = _driver.FindElement(By.Name("username"));
                query.SendKeys("admin");

                IWebElement query2 = _driver.FindElement(By.Name("password"));
                query2.SendKeys("admin");

                IWebElement query3 = _driver.FindElement(By.XPath(".//*[@id='sub']"));
                query3.Click();

                Assert.AreEqual(_driver.Title, "The Shop");

            }
        }
        /*
        {
            //arranque
            _browserDriver = new ChromeDriver();
            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Navigate().GoToUrl("http://shoppingonline.local:3500/user/login");
            //prueba
            _browserDriver.FindElementByName("username").SendKeys("admin");
            _browserDriver.FindElementByName("password").SendKeys("5737b3f");
            //ejecucion
            _browserDriver.FindElementByXPath(".//*[@id='sub']").Click();

            //assert
            Assert.IsTrue(_browserDriver.PageSource.Contains("admin"));
            Assert.IsTrue(_browserDriver.PageSource.Contains("Salir"));
            Assert.IsTrue(_browserDriver.PageSource.Contains("Bienvenido a la e-shop!"));
        }*/
    }
}