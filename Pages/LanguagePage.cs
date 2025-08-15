using MarsOnboardingIC.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardingIC.Pages
{
    public class LanguagePage
    {
        public void AddLanguage(IWebDriver driver,string newlanguage, string languagelevel)
        {
            Wait.WaitToBeClicakable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 10);
            IWebElement addnewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addnewButton.Click();

            IWebElement languageInput = driver.FindElement(By.XPath(" //input[@placeholder='Add Language']"));
            languageInput.SendKeys(newlanguage);

            Wait.WaitToBeVisible(driver, "XPath", "//select[@name='level']", 10);
            SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
            languageLevelDropdown.SelectByText(languagelevel);  

            

            IWebElement addButton = driver.FindElement(By.XPath("//div[@class='six wide field']//input[@type='button' and @value='Add']"));
            addButton.Click();
            Thread.Sleep(2000); // Wait for the language to be added


        }
        public string GetLanguage(IWebDriver driver)
        {
            IWebElement newlanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return newlanguage.Text;
        }

        public string GetLanguageLevel(IWebDriver driver)
        {
            IWebElement newlanglevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return newlanglevel.Text;

        }
        public void UpdateLanguage(IWebDriver driver, string languageName, string updatedlanguageName)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));

            foreach (IWebElement row in rows)
            {
                string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                //string level = row.FindElement(By.XPath("./td[2]")).Text.Trim();

                if (lang.Equals(languageName, StringComparison.OrdinalIgnoreCase))
                    
                {
                    // Click edit icon in this row
                    IWebElement edit = row.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]"));
                    edit.Click();
                    IWebElement editLanguage = driver.FindElement(By.XPath(" //input[@placeholder='Add Language']"));
                    editLanguage.Clear();
                  
                    editLanguage.SendKeys(updatedlanguageName);
                    IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
                    updateButton.Click();
                    Thread.Sleep(2000); // Wait for the language to be updated  
                    break;
                }
            }

        }
        public void UpdateLanguageLevel(IWebDriver driver,string languagelevel,string updatedlanguagelevel)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                //string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                string level = row.FindElement(By.XPath("./td[2]")).Text.Trim();

                if (level.Equals(languagelevel, StringComparison.OrdinalIgnoreCase))

                {
                    // Click edit icon in this row
                    IWebElement edit = row.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]"));
                    edit.Click();
                    SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
                    languageLevelDropdown.SelectByText(updatedlanguagelevel);
                    IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
                    updateButton.Click();
                    Thread.Sleep(2000); // Wait for the language to be updated  
                    break;
                }
            }

        }
        
       
        public bool IsLanguagePresent(IWebDriver driver, string updatedlanguageName)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']//table/tbody/tr"));

            foreach (IWebElement row in rows)
            {
                string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (lang.Equals(updatedlanguageName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsLanguageLevelPresent(IWebDriver driver, string updatedlanguagelevel)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']//table/tbody/tr"));

            foreach (IWebElement row in rows)
            {
                string level = row.FindElement(By.XPath("./td[2]")).Text.Trim();
                if (level.Equals(updatedlanguagelevel, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteLanguage(IWebDriver driver, string deletelanguage)
        {
            
            Thread.Sleep(1000); // Wait for the delete confirmation dialog to appear
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));

            foreach (IWebElement row in rows)
            {
                string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                //string level = row.FindElement(By.XPath("./td[2]")).Text.Trim();

                if (lang.Equals(deletelanguage, StringComparison.OrdinalIgnoreCase))

                {
                    // Click edit icon in this row
                    IWebElement deletebtn = row.FindElement(By.XPath(".//i[contains(@class,'remove icon')]"));
                    deletebtn.Click();
            
                    
                    break;
                }
                Thread.Sleep(2000); // Wait for the language to be updated  
            }

        }
        public bool IsLanguagedeleted(IWebDriver driver, string deletelanguage)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']//table/tbody/tr"));

            foreach (IWebElement row in rows)
            {
                string dellang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (dellang.Equals(deletelanguage, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }


    }



}



