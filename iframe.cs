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
    class iframe
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
        public void switchframe()
        {
            IWebElement frame = driver.FindElement(By.XPath("//iframe[@id='courses-iframe']"));
          
            //Actions ac = new Actions (driver);
            //ac.ScrollToElement(frame).Perform();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", frame);

            driver.SwitchTo().Frame(frame);
            IWebElement AllaccessPlan = driver.FindElement(By.LinkText("All Access Plan"));
            AllaccessPlan.Click();
            String childheading= driver.FindElement(By.XPath("//h1")).Text;
            TestContext.Progress.WriteLine("Child heading is "+childheading);
            driver.SwitchTo().DefaultContent();
            String heading = driver.FindElement(By.XPath("//h1")).Text;
            TestContext.Progress.WriteLine("Parent Frame is : "+heading);

        }

    }
}
