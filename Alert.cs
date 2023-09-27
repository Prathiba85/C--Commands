using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    class Alert
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
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";

            //global implicit wait -Wait 5 seconds after every line
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


        }

        [Test]
        public void alertexample()
        {
            String name = "Prathiba"; 
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys(name);
            driver.FindElement(By.XPath("//input[@id='confirmbtn']")).Click();
            String alertmessage= driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine(alertmessage);
            driver.SwitchTo().Alert().Accept();
            //To send text to text box in alerts
            // driver.SwitchTo().Alert().SendKeys("OK");
            StringAssert.Contains(name, alertmessage);

        }
    }
}
