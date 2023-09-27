using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning
{
    internal class Actionsclass
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //IWebDriver ---> Is an Interface 
            //ChromeDriver.exe. on chrome browser
            //WebDriverManager -(
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/";

            //global implicit wait -Wait 5 seconds after every line
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


        }
        [Test] 
        public void hoverover () {

            IWebElement more = driver.FindElement(By.XPath("//a[@class='dropdown-toggle']"));
            Actions ac = new Actions(driver);
            ac.MoveToElement(more).Perform();
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu']//li//a[@href='contact-us']")).Click();

        }
    }
}
