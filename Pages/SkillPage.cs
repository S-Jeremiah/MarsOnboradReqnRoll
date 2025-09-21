using MarsOnboardingIC.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace MarsOnboardingIC.Pages
{
    public class SkillPage : CommonDriver
    {
        private WebDriverWait wait;


        private By skillsTab = By.XPath("//a[@data-tab='second']");
        private By addingNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        private By skillInput = By.XPath("//div[@data-tab='second']//input[@placeholder='Add Skill' and @name='name']");
        private By addSkillButton = By.XPath("//div[@data-tab='second']//input[@type='button' and @value='Add']");
        private By skillRows = By.XPath("//div[@data-tab='second']//table/tbody/tr");
        private By duplicatemsgbtn= By.XPath("//div[@class='ns-box-inner']");
        private By errormessage = By.XPath("//div[@class='ns-box-inner']");
        public SkillPage()
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }
        public void OpenSkillsTab() 
        { 
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(skillsTab)).Click(); 
        }

        // Action Methods
        public void ClickAddNew()
        {
            
            var btn = wait.Until(d => {
                var e = d.FindElement(addingNewButton);
                return (e.Displayed && e.Enabled) ? e : null;
            });
            btn.Click();
        }
        public void EnterSkillName(string skillname) => Driver.FindElement(skillInput).SendKeys(skillname);

        public void SelectSkillLevel(string skilllevel)
        {
            var dropdown = new SelectElement(wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("level"))));
            dropdown.SelectByText(skilllevel);
        }

        public void ClickAddButton() => Driver.FindElement(addSkillButton).Click();

        // Combined actions for tests
        public void AddSkill(string skillname, string skilllevel)
        {
            OpenSkillsTab();
            ClickAddNew();
            EnterSkillName(skillname);
            SelectSkillLevel(skilllevel);
            ClickAddButton();
            wait.Until(d => IsSkillPresent(skillname, skilllevel));
        }
        public void Tryaddskill(string skillname, string skilllevel)
        {
            OpenSkillsTab();
            ClickAddNew();
            EnterSkillName(skillname);
            SelectSkillLevel(skilllevel);
            ClickAddButton();

        }

        public bool IsSkillPresent(string skillname, string skilllevel)
        {
            OpenSkillsTab();
            foreach (var row in Driver.FindElements(skillRows))
            {
                string skill = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                string skillLevel = row.FindElement(By.XPath("./td[2]")).Text.Trim();
                if (skill.Equals(skillname, StringComparison.OrdinalIgnoreCase) &&
                    skillLevel.Equals(skilllevel, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public void Updatingskill(string skillname, string skilllevel, string newskillname, string newskilllevel)
        {
            OpenSkillsTab();
            foreach (var row in Driver.FindElements(skillRows))
            {
                string skill = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                string level = row.FindElement(By.XPath("./td[2]")).Text.Trim();

                if (skill.Equals(skillname, StringComparison.OrdinalIgnoreCase) &&
                    level.Equals(skilllevel, StringComparison.OrdinalIgnoreCase))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]")).Click();
                    var editInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(".//input[@placeholder='Add Skill']")));
                    editInput.Clear();
                    editInput.SendKeys(newskillname);
                    var dropdown = new SelectElement(row.FindElement(By.Name("level")));
                    dropdown.SelectByText(newskilllevel);
                    row.FindElement(By.XPath(".//input[@type='button' and @value='Update']")).Click();
                    wait.Until(d => IsSkillPresent(newskillname, newskilllevel));
                    break;
                }
            }
        }
        public void Addonlyskill(string addskill)
        {
            OpenSkillsTab();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addingNewButton));
            Driver.FindElement(addingNewButton).Click();
            Driver.FindElement(skillInput).SendKeys(addskill);
            Driver.FindElement(addSkillButton).Click();
            Thread.Sleep(2000); 


        }

        public void Deletingskill(string skill)
        {
            OpenSkillsTab();
            foreach (var row in Driver.FindElements(skillRows))
            {
                string existingskill = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (existingskill.Equals(skill, StringComparison.OrdinalIgnoreCase))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'remove icon')]")).Click();
                    wait.Until(d => IsSkilldeleted(skill));
                    break;
                }
            }
        }
        /*public void Deletingskill(string skill)
        {
            OpenSkillsTab();
            bool skillFound = false;

            foreach (var row in Driver.FindElements(skillRows))
            {
                string existingskill = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (existingskill.Equals(skill, StringComparison.OrdinalIgnoreCase))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'remove icon')]")).Click();
                    wait.Until(d => IsSkilldeleted(skill));
                    skillFound = true;
                    break;
                }
            }

            if (!skillFound)
            {
                throw new NoSuchElementException($"The skill '{skill}' does not exist, so it cannot be deleted.");
            }
        }*/
        public bool IsSkilldeleted(string skill)
        {
            OpenSkillsTab();
            foreach (var row in Driver.FindElements(skillRows))
            {
                string delskill = row.FindElement(By.XPath("./td[1]")).Text.Trim();
                if (delskill.Equals(skill, StringComparison.OrdinalIgnoreCase))
                    return false;
            }
            return true;
        }
        public string GetDuplicateSkillMessage()
        {
            try
            {
                var messageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(duplicatemsgbtn));
                return messageElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty; 
            }
        }
        public string GetBlankSkillMessage()
        {
            try
            {
                var messageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(errormessage));
                return messageElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty; 
            }
        }
    }
}