using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace Demo.SeleniumTests
{
    [TestClass]
    public class DotNetSiteTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestGetStarted()
        {
            // Chrome Driver was manually downloaded from https://sites.google.com/a/chromium.org/chromedriver/downloads
            // parameter "." will instruct to look for the chromedriver.exe in the current folder (bin/debug/...)

            // Run Selenium in UI visiable mode
            //using (var driver = new ChromeDriver("."))

            // Run Selenium in UI headless mode
             var options = new ChromeOptions();
             options.AddArgument("headless");
             using (var driver = new ChromeDriver(".", options))
            {
                //Directly navgate the URL
                driver.Navigate().GoToUrl("http://teamsportaldemo.azurewebsites.net/");

                //Navgate the URL form the "webAppUrl" variable from the ".runsettings" file. 
                //driver.Navigate().GoToUrl((string)TestContext.Properties["webAppUrl"]);

                //Put Selenium code here.
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
                driver.FindElement(By.Name("email")).SendKeys("admin@altigen.com");
                driver.FindElement(By.Name("password")).SendKeys("222222");
                driver.FindElement(By.ClassName("MuiButton-label")).Click();

            }
        }

  
    }
}