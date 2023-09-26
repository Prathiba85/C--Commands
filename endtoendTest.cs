using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    class endtoendTest
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
        public void EndToEndFlow()
        {
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//input[@id='terms']")).Click();
            driver.FindElement(By.XPath("//input[@id='signInBtn']")).Click();
            IWebElement checkout= driver.FindElement(By.XPath("//a[@class='nav-link btn btn-primary']"));
            WebDriverWait wc = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wc.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            //send products list

            String[] products = { "iphone X", "Blackberry" };
           IList<IWebElement> cards = driver.FindElements(By.TagName("app-card"));

            foreach(IWebElement product in cards)
            {
                String producttitle = product.FindElement(By.CssSelector(".card-title a")).Text;
               

                TestContext.Progress.WriteLine(producttitle);
                /*
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Equals(producttitle))
                    {
                        product.FindElement(By.CssSelector(".card-footer button")).Click();
                        break;
                    }

                }*/
                
                if (products.Contains(producttitle))
                {
                    //click cart
                  //  product.FindElement(By.XPath("//button[@class='btn btn-info']")).Click();
                   product.FindElement(By.CssSelector(".card-footer button")).Click() ;

                }

                

              
            }
            checkout.Click();

        }

    }
}
