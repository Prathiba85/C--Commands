using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class radiobuttons
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
        public void radiobuttonProgram()
        {

            //drop downs
            IList<IWebElement> radiobuttons = driver.FindElements(By.XPath("//input[@type='radio']"));
            //radiobuttons[1].Click();

            foreach (IWebElement radiobutton in radiobuttons)
            {
                if (radiobutton.GetAttribute("value").Equals("user"))
                {
                    radiobutton.Click();
                    break;
                }
            }
            WebDriverWait wc = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wc.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean result = driver.FindElement(By.Id("usertype")).Selected;
            Assert.That(result, Is.True);
        }
    }
}
