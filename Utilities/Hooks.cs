using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace MarsOnboardingIC.Utilities
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

    }
}
