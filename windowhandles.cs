using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;
using LanguageExt;

namespace SeleniumLearning
{
    class windowhandles
    {
        IWebDriver driver;
        String username="";
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
        public void switchToWindow()
        {

            IWebElement blinkingtext = driver.FindElement(By.XPath("//a[@class='blinkingText']"));
            blinkingtext.Click();
           IList<String> allwindows = driver.WindowHandles;
            String childwindow = allwindows[1];
            String parentwindow = allwindows[0];
            //TestContext.Progress.WriteLine(allwindows.Count);
            driver.SwitchTo().Window(childwindow);
           
            String message = driver.FindElement(By.XPath("//p[@class='im-para red']")).Text;
            //TestContext.Progress.WriteLine(message);
            String[] Arrarymessage = message.Split(" ");
            //TestContext.Progress.WriteLine("email is " + Arrarymessage[5]);
            foreach (String str in Arrarymessage)
            {
               
                if (str .Contains(".com"))
                {
                   username = str;
                }
            }

            driver.SwitchTo().Window(parentwindow);
            driver.FindElement(By.Id("username")).SendKeys(username);

        }
    }
}
