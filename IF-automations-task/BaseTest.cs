using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using SeleniumExtras.WaitHelpers;


namespace IF_automations_task.BaseClass
{
    public class BaseTest 
    {
        private WebDriver WebDriver { get; set; } = null!;
        private string DriverPath { get; set; } = @"C:\Data\WebDrivers\Chrome";
        private string BaseUrl { get; set; } = "https://www.if.lv/";
        

        public IWebDriver driver;

        [OneTimeSetUp]
        public void Open()
        {
             driver = new ChromeDriver();
          
            //go to url
            driver.Url = BaseUrl;
            driver.Manage().Window.Maximize();
        }


        [OneTimeTearDown]
        public void Close ()
        {
            driver.Quit();
        }

    }
}