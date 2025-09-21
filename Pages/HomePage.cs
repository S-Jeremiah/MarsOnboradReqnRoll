using MarsOnboardingIC.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardingIC.Pages
{
    public class HomePage :CommonDriver
    {

        private readonly WebDriverWait wait;
        private By LanguageButton =By.XPath("//a[contains(text(),'Languages')]");
        private By SkillButton = By.XPath("//a[contains(text(),'Skills')]");
        private By loggedInUserName = By.XPath("//div[@class='ui compact menu']//span[contains(@class,'dropdown') and contains(@class,'link')][last()]");
        public HomePage()
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        }
        
        public void NavigateToLanguage()
        {
           
            Wait.WaitToBeClicakable(Driver, "XPath", "//a[contains(text(),'Languages')]", 10);
            Driver.FindElement(LanguageButton).Click();
            
        }


        public void NavigateToSkill()
        {
            Wait.WaitToBeClicakable(Driver, "XPath", "//a[contains(text(),'Skills')]", 10);

            Driver.FindElement(SkillButton).Click();
           
        }
        public string GetLoggedInUserName()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            
    
            IWebElement userElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(loggedInUserName));
            return userElement.Text;  // Returns the displayed username
        }
    }
}
