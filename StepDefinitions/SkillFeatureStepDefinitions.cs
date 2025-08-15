using MarsOnboardingIC.Pages;
using MarsOnboardingIC.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System;
using Assert = NUnit.Framework.Assert;

namespace MarsOnboardingIC.StepDefinitions
{
    [Binding]
    public class SkillFeatureStepDefinitions
    {
        public IWebDriver driver;
        public SkillFeatureStepDefinitions()
        {
            // Get driver instance from Hooks
            driver = Hooks.driver;
        }
        [Given("I logged in as a register user")]
        public void GivenILoggedInAsARegisterUser()
        {

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginAction(driver);
        }


        [When("I navigate to the Skill management page")]
        public void WhenINavigateToTheSkillManagementPage()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToSkill(driver);
        }

        [When("I add {string} and {string} to the list of skills")]
        public void WhenIAddAndToTheListOfSkills(string newSkill, string Skilllevel)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.AddSkill(driver, newSkill, Skilllevel);
        }

        [Then("I should see the new {string} and {string} in the list below")]
        public void ThenIShouldSeeTheNewAndInTheListBelow(string newSkill, string Skilllevel)
        {
            SkillPage skillPageObj = new SkillPage();
            string newSkillName = skillPageObj.GetSkill(driver);
            Assert.That(newSkillName == newSkill, "Skill not added successfully");
            string newSkillLevel = skillPageObj.GetSkillLevel(driver);
            Assert.That(newSkillLevel == Skilllevel, "Skill level not added successfully");

        }

        [When("I update the{string} to {string} in the skill list")]
        public void WhenIUpdateTheToInTheSkillList(string SkillName, string updatedSkillName)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.UpdateSkill(driver, SkillName, updatedSkillName);

        }

      

        [When("I update{string} to {string} in the skill list")]
        public void WhenIUpdateToInTheSkillList(string Skilllevel, string updatedSkilllevel)
        {
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.UpdateSkillLevel(driver, Skilllevel, updatedSkilllevel);
        }


        [Then("I should see the Skill {string} in the list")]
        public void ThenIShouldSeeTheSkillInTheList(string updatedSkillName)
        {
            SkillPage skillPageObj = new SkillPage();   
            
            Assert.That(skillPageObj.IsSkillPresent(driver, updatedSkillName),Is.True, "Skill not updated successfully");
        }

        [Then("the Skill level should be {string}")]
        public void ThenTheSkillLevelShouldBe(string updatedSkilllevel)
        {
            SkillPage skillPageObj = new SkillPage();            
            Assert.That(skillPageObj.IsSkillLevelPresent(driver, updatedSkilllevel),Is.True, "Skill Level not updated successfully");
        }

        [When("I delete the Skill {string} from the list")]
        public void WhenIDeleteTheSkillFromTheList(string deleteSkill)
        {
            SkillPage skillPageObj = new SkillPage();   
            skillPageObj.DeleteSkill(driver, deleteSkill);
        }

        [Then("I should not see the Skill {string} in the list")]
        public void ThenIShouldNotSeeTheSkillInTheList(string deleteSkill)
        {
           SkillPage skillsPageObj = new SkillPage();
            Assert.That(skillsPageObj.IsSkillDeleted(driver, deleteSkill), Is.True, "Skill not deleted successfully");

        }





    }
}
