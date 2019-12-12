
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Remote;


namespace SeleniumDemoUI
{
    [TestClass]
    public class Login
    {
        private RemoteWebDriver _browserDriver;
        [TestMethod]

        public void Inicializacion()
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
        }
    }
}