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
    public class SkillPage
    {
        public void AddSkill(IWebDriver driver, string newSkill, string skillLevel)
        {
            Wait.WaitToBeClicakable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 10);
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement skillInput = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            skillInput.SendKeys(newSkill);

            Wait.WaitToBeClicakable(driver, "XPath", "//select[@name='level']", 10);
            SelectElement skillLevelDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='level']")));
            skillLevelDropdown.SelectByText(skillLevel);

            Wait.WaitToBeClicakable(driver, "XPath", "//input[@type='button' and @value='Add']", 10);
            IWebElement addButton = driver.FindElement(By.XPath("//input[@type='button' and @value='Add']"));
            addButton.Click();
            Thread.Sleep(2000); // Wait for the skill to be added
        }

        public string GetSkill(IWebDriver driver)
        {
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return newSkill.Text;
        }

        public string GetSkillLevel(IWebDriver driver)
        {
            IWebElement newSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return newSkillLevel.Text;
        }

        public void UpdateSkill(IWebDriver driver, string skillName, string updatedSkillName)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                string skill = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (skill.Equals(skillName, StringComparison.OrdinalIgnoreCase))
                {
                    // Click edit icon in this row
                    IWebElement editIcon = row.FindElement(By.XPath(".//i[@class='outline write icon']"));
                    editIcon.Click();
                    // Update the skill name
                    IWebElement skillInput = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                    skillInput.Clear();
                    skillInput.SendKeys(updatedSkillName);
                    // Click update button
                    IWebElement updateButton = driver.FindElement(By.XPath("//input[@type='button' and @value='Update']"));
                    updateButton.Click();
                    Thread.Sleep(2000); // Wait for the skill to be updated
                    break;
                }
            }
        }

        public void UpdateSkillLevel(IWebDriver driver, string Skilllevel, string updatedSkilllevel)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                //string lang = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                string level = row.FindElement(By.XPath("./td[2]")).Text.Trim();

                if (level.Equals(Skilllevel, StringComparison.OrdinalIgnoreCase))

                {
                    // Click edit icon in this row
                    IWebElement edit = row.FindElement(By.XPath(".//i[@class='outline write icon']"));
                    edit.Click();
                    SelectElement languageLevelDropdown = new SelectElement(driver.FindElement(By.Name("level")));
                    languageLevelDropdown.SelectByText(updatedSkilllevel);
                    IWebElement updateButton = driver.FindElement(By.XPath("//input[@type='button' and @value='Update']"));
                    updateButton.Click();
                    Thread.Sleep(2000); // Wait for the language to be updated  
                    break;
                }
            }

        }
        public bool IsSkillPresent(IWebDriver driver, string skillName)

        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                string skill = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (skill.Equals(skillName, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Skill found
                }
            }
            return false; // Skill not found


        }
        public bool IsSkillLevelPresent(IWebDriver driver, string skillLevel)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                string level = row.FindElement(By.XPath("./td[2]")).Text.Trim();
                if (level.Equals(skillLevel, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Skill level found
                }
            }
            return false; // Skill level not found

        }

        public void DeleteSkill(IWebDriver driver, string deleteSkill)
        {
            Thread.Sleep(1000); // Wait for the page to load
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                string skill = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (skill.Equals(deleteSkill, StringComparison.OrdinalIgnoreCase))
                {
                    // Click delete icon in this row
                    IWebElement deleteIcon = row.FindElement(By.XPath(".//i[@class='remove icon']"));
                    deleteIcon.Click();
                     // Wait for the skill to be deleted
                    break;
                }
                Thread.Sleep(2000);
            }
        }
        public bool IsSkillDeleted(IWebDriver driver, string deleteSkill)
        {
            Thread.Sleep(1000); // Wait for the page to load after deletion
            
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]//table/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                string skillname = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (skillname.Equals(deleteSkill, StringComparison.OrdinalIgnoreCase))
                {
                    return false; 
                }
            }
            return true; 
        }
    }
}
