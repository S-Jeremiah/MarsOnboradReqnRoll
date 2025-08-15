using MarsOnboardingIC.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardingIC.Pages
{
    public class HomePage
    {

        public void NavigateToLanguage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Languages')]")));
            IWebElement LanguageButton = driver.FindElement(By.XPath("//a[contains(text(),'Languages')]"));
            LanguageButton.Click();
            
        }


        public void NavigateToSkill(IWebDriver driver)
        {
            Wait.WaitToBeClicakable(driver, "XPath", "//a[contains(text(),'Skills')]", 10);
            IWebElement SkillButton = driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
            SkillButton.Click();
           // Thread.Sleep(2000); // Wait for the page to load
        }
    }
}
