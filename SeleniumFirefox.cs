using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirefox
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            //IWebDriver ---> Is an Interface 
            //geckoDriver.exe. on chrome browser
            //WebDriverManager -(
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
           
        }

        [Test]
        public void openUrl()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.Manage().Window.Maximize();
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
        }
       

        
        [TearDown] public void TearDown() 
        {
            driver.Close();
        }

    }
}