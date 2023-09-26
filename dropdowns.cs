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
    public class dropdown
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
        public void dropdownprogram()
        {
           
            //drop downs
           IWebElement dropdown=  driver.FindElement(By.XPath("//select[@class='form-control']"));
            SelectElement   sc = new SelectElement(dropdown);
            sc.SelectByText("Teacher");
            sc.SelectByValue("consult");
            sc.SelectByIndex(1);
        }
    }
}
