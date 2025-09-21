using MarsOnboardingIC.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace MarsOnboardingIC.Pages
{
    public class LanguagePage : CommonDriver
    {
        private WebDriverWait wait;

        // Scope all elements inside the Language tab using data-tab='first'
        private By languageTab = By.XPath("//a[@data-tab='first']");
        private By addNewButton = By.XPath("//div[@data-tab='first']//div[contains(@class,'ui teal button') and text()='Add New']");
        private By languageInput = By.XPath("//div[@data-tab='first']//input[@placeholder='Add Language']");
        private By languageLevelDropdown = By.XPath("//div[@data-tab='first']//select[@name='level']");
        private By addButton = By.XPath("//div[@data-tab='first']//input[@type='button' and @value='Add']");
        private By languageRows = By.XPath("//div[@data-tab='first']//table/tbody/tr");
        private By errorblankmessage=By.XPath("//div[@class='ns-box-inner']");
        private By duplicateerrorbtn=By.XPath("//div[@class='ns-box-inner']");
        public LanguagePage()
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        // Open the Language tab
        public void OpenLanguageTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(languageTab)).Click();
        }

        // Add a new language
        public void AddLanguage(string language, string level)
        {
            OpenLanguageTab();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addNewButton)).Click();
            Driver.FindElement(languageInput).SendKeys(language);
            var dropdown = new SelectElement(wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(languageLevelDropdown)));
            dropdown.SelectByText(level);
            Driver.FindElement(addButton).Click();
            wait.Until(d => IsLanguagePresent(language, level));
        }
        public void TryAddLanguage(string language, string level)
        {
            OpenLanguageTab();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addNewButton));
            Driver.FindElement(addNewButton).Click();
            Driver.FindElement(languageInput).SendKeys(language);
            var dropdown = new SelectElement(wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(languageLevelDropdown)));
            dropdown.SelectByText(level);
            Driver.FindElement(addButton).Click();
            
        }
        // Check if language exists
        public bool IsLanguagePresent(string language, string level)
        {
            OpenLanguageTab();
            foreach (var row in Driver.FindElements(languageRows))
            {
                string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                string langLevel = row.FindElement(By.XPath("./td[2]")).Text.Trim();
                if (lang.Equals(language, StringComparison.OrdinalIgnoreCase) &&
                    langLevel.Equals(level, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        // Update language and level
        public void UpdateLanguage(string existingLanguage, string newLanguage, string existingLevel, string newLevel)
        {
            OpenLanguageTab();
            foreach (var row in Driver.FindElements(languageRows))
            {
                string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                string lvl = row.FindElement(By.XPath("./td[2]")).Text.Trim();

                if (lang.Equals(existingLanguage, StringComparison.OrdinalIgnoreCase) &&
                    lvl.Equals(existingLevel, StringComparison.OrdinalIgnoreCase))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]")).Click();
                    var editInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(languageInput));
                    editInput.Clear();
                    editInput.SendKeys(newLanguage);
                    var dropdown = new SelectElement(row.FindElement(languageLevelDropdown));
                    dropdown.SelectByText(newLevel);
                    row.FindElement(By.XPath(".//input[@type='button' and @value='Update']")).Click();
                    wait.Until(d => IsLanguagePresent(newLanguage, newLevel));
                    break;
                }
            }
        }
        public void AddonlyLanguage(string language)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addNewButton));
            Driver.FindElement(addNewButton).Click();
            Driver.FindElement(languageInput).SendKeys(language);
            Driver.FindElement(addButton).Click();
            Thread.Sleep(2000); // Wait for the language to be added


        }

        // Delete language
        public void DeleteLanguage(string language )
        {
            OpenLanguageTab();
            foreach (var row in Driver.FindElements(languageRows))
            {
                string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (lang.Equals(language, StringComparison.OrdinalIgnoreCase))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'remove icon')]")).Click();
                    wait.Until(d => IsLanguageDeleted(language));
                    break;
                }
            }
        }

        // Check if language deleted
        public bool IsLanguageDeleted(string language)
        {
            OpenLanguageTab();
            foreach (var row in Driver.FindElements(languageRows))
            {
                string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (lang.Equals(language, StringComparison.OrdinalIgnoreCase))
                    return false;
            }
            return true;
        }
        public string GetErrorMessage()
        {
            try
            {
                var errorElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errorblankmessage));
                return errorElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty; // No error message found within the timeout
            }
        }
        public string GetDuplicateErrorMessage()
        {
            try
            {
                var errorElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(duplicateerrorbtn));
                return errorElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty; // No error message found within the timeout
            }
        }
    }


}