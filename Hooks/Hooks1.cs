using MarsOnboardingIC.Pages;
using MarsOnboardingIC.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using Reqnroll.BoDi;
using WebDriverManager.DriverConfigs.Impl;

namespace MarsOnboardingIC.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        
        private static List<string> AddedLanguages = new();
        private static List<string> AddedSkills = new();

        [BeforeScenario]
        public static void BeforeScenario()
        {
            CommonDriver commonDriver = new CommonDriver();
            commonDriver.Initialise(); // Starts the browser once

            IWebDriver driver = CommonDriver.Driver;

            driver.Navigate().GoToUrl("http://localhost:5003/Home");


            IWebElement SigninButton = driver.FindElement(By.XPath("//a[@class='item' and text() ='Sign In']"));
            SigninButton.Click();
            IWebElement Email = driver.FindElement(By.XPath("//input[@name='email']"));
            Email.SendKeys("jeroshirley@gmail.com");

            IWebElement password = driver.FindElement(By.XPath("//input[@name='password']"));
            password.SendKeys("World!123");
            Wait.WaitToBeClicakable(driver, "XPath", "//button[@class='fluid ui teal button']", 10);
            IWebElement LoginButton =driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
            LoginButton.Click();


        } 

        [AfterScenario]
        public static void AfterScenario()
        {
            if (CommonDriver.driver != null) 
            {
                IWebDriver driver = CommonDriver.Driver;
                
                if (AddedLanguages.Any()) 
                
                    driver.FindElement(By.XPath("//a[contains(text(),'Languages')]")).Click();

                foreach (var lang in AddedLanguages)
                {
                    try
                    {
                        var row = driver.FindElement(By.XPath($"//td[text()='{lang}']/.."));
                        var deleteBtn = row.FindElement(By.XPath(".//i[@class='remove icon']"));
                        deleteBtn.Click();

                        new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(d => d.FindElements(By.XPath($"//td[text()='{lang}']")).Count == 0);
                    }
                    catch
                    {
                        // Ignore if not found
                    }
                }
                if (AddedSkills.Any())
                    driver.FindElement(By.XPath("//a[contains(text(),'Skills')]")).Click();

                foreach (var skill in AddedSkills)
                {
                    try
                    {
                        var row = driver.FindElement(By.XPath($"//td[text()='{skill}']/.."));
                        var deleteBtn = row.FindElement(By.XPath(".//i[@class='remove icon']"));
                        deleteBtn.Click();

                        new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                            .Until(d => d.FindElements(By.XPath($"//td[text()='{skill}']")).Count == 0);
                    }
                    catch
                    {
                        // Ignore if not found
                    }
                }

                driver.Quit();
                CommonDriver.driver = null;
                AddedLanguages.Clear();
                AddedSkills.Clear();
            }
        }
        public static void TrackAddedLanguage(string language)
        {
            if (!AddedLanguages.Contains(language))
                AddedLanguages.Add(language);
        }
        public static void TrackAddedSkill(string skill)
        {
            if (!AddedSkills.Contains(skill))
                AddedSkills.Add(skill);
        }
    }

}
    

