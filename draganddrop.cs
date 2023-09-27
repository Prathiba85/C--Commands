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
    class draganddrop  
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
            driver.Url = "https://demoqa.com/droppable";

            //global implicit wait -Wait 5 seconds after every line
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


        }
        [Test] 
        public void dragdropped () {

            IWebElement Dragme = driver.FindElement(By.XPath("//div[@id='draggable']"));
            IWebElement Dropped = driver.FindElement(By.XPath("//div[@id='droppable'][1]"));
            Actions ac = new Actions(driver);
            ac.DragAndDrop(Dragme, Dropped).Build().Perform();

        }
    }
}
