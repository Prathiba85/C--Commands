using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using AngleSharp.Dom;

namespace SeleniumLearning
{
    class GreenkartWebTable
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
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";

            //global implicit wait -Wait 5 seconds after every line
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


        }
        [Test]
        public void compareSortedList()
        {
            
            
            IWebElement dropdown = driver.FindElement(By.XPath("//select[@id='page-menu']"));
            SelectElement sc = new SelectElement(dropdown);
              sc.SelectByValue("20");

           IList <IWebElement> fruitname = driver.FindElements(By.XPath("//tbody/tr//td[1]"));
            ArrayList al = new ArrayList();
            foreach (IWebElement element in fruitname)
            {
                al.Add(element.Text);

                TestContext.Progress.WriteLine(element.Text);
              
            }
            
            al.Sort();

            driver.FindElement(By.XPath("//span[text()='Veg/fruit name']")).Click();
            IList<IWebElement> fruitnamesorted = driver.FindElements(By.XPath("//tbody/tr//td[1]"));
            ArrayList sortedlist = new ArrayList();
            TestContext.Progress.WriteLine("*****************Sorted List **********************");
            foreach (IWebElement element in fruitnamesorted)
            {
                sortedlist.Add(element.Text);

                TestContext.Progress.WriteLine(element.Text);

            }

            Assert.AreEqual(sortedlist, al);

        }

    }
}
