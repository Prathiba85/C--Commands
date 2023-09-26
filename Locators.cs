using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class WaitPrograms
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
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            //global implicit wait -Wait 5 seconds after every line
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                    }
        [Test]
        public void LocateIdentification()
        {
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.XPath("//input[@id='terms']")).Click();
            driver.FindElement(By.XPath("//input[@id='signInBtn']")).Click();
            //Thread.Sleep(2000);
           
            String errormessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errormessage);
            IWebElement link= driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            
            
            String hrefAttr =  link.GetAttribute("href");
            //Expected - https://rahulshettyacademy.com/documents-request
            String expectedurl = "https://rahulshettyacademy.com/documents-request";
            TestContext.Progress.WriteLine(expectedurl);
            Assert.That(hrefAttr, Is.EqualTo(expectedurl));
            //Assert.AreEqual(expectedurl, hrefAttr);

        }
    }
}
