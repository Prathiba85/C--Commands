using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Collections;
using LanguageExt.ClassInstances;
using LanguageExt.Common;

namespace SeleniumLearning
{
    class Autosuggestdropdown
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
        public void Autosuggestdropdownexample()
        {
            String name = "India";
            driver.FindElement(By.XPath("//input[@id='autocomplete']")).SendKeys("ind");
            IList<IWebElement> conuntrylist=  driver.FindElements(By.XPath("//ul[@id='ui-id-1']//li//div"));
            foreach (IWebElement country in conuntrylist )
            {
                       
                //TestContext.Progress.WriteLine(country.Text);

                if (country.Text.Equals("India"))
                {
                    country.Click();
                }


            }
               //For dynamicaly typed value , you can get tht text by get attribute    
            String valueselected = driver.FindElement(By.XPath("//input[@id='autocomplete']")).GetAttribute("value");
            TestContext.Progress.WriteLine(valueselected);
        }
    }
}

