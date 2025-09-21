using MarsOnboardingIC.Hooks;
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
    public class SkillFeatureStepDefinitions : CommonDriver
    {
        
        LoginPage loginPage;
        HomePage homePage;
        SkillPage skillPage;
        public SkillFeatureStepDefinitions()
        {

          
        }

        [Given("I logged in as a register user")]
        public void GivenILoggedInAsARegisterUser()
        {
           loginPage = new LoginPage();
            loginPage.NavigateToLoginPage();
            loginPage.LoginAction();
            //LoginPage loginPageObj = new LoginPage();
            //loginPageObj.LoginAction(driver);
        }




        [When("I add {string} and {string} to the list of skills")]
        public void WhenIAddAndToTheListOfSkills(string skillname, string skilllevel)
        {
            skillPage = new SkillPage();
            skillPage.AddSkill(skillname, skilllevel);
            Hooks1.TrackAddedSkill(skillname);
        }


        [Then("I should see the new {string} and {string} in the list below")]
        public void ThenIShouldSeeTheNewAndInTheListBelow(string skillname, string skilllevel)
        {
            skillPage = new SkillPage();
            Assert.That(skillPage.IsSkillPresent(skillname, skilllevel), Is.True, "New skill not added successfully");

        }
        


        [When("I add the {string} to the list")]
        public void WhenIAddToTheList(string skill)
        {
            skillPage = new SkillPage();
            skillPage.Addonlyskill(skill);

            Hooks1.TrackAddedSkill(skill);
        }

        [When("I delete the Skill {string} from the list")]
        public void WhenIDeleteTheSkillFromTheList(string skill)
        {
           skillPage = new SkillPage();
            skillPage.Deletingskill(skill);
        }

        [Then("I should not see the Skill {string} in the list")]
        public void ThenIShouldNotSeeTheSkillInTheList(string skill)
        {
           skillPage = new SkillPage();
            Assert.That(skillPage.IsSkilldeleted(skill), Is.True, "Skill not deleted successfully");

        }

        [Given("I logged in as a register user in the portal")]
        public void GivenILoggedInAsARegisterUserInThePortal()
        {
            
            loginPage=new LoginPage();
            loginPage.NavigateToLoginPage();
            loginPage.LoginAction();
        }
        
        [When("I add {string} and {string} to the table")]
        public void WhenIAddAndToTheTable(string skillname, string skilllevel)
        {
            skillPage = new SkillPage();
            skillPage.AddSkill(skillname, skilllevel);
            Hooks1.TrackAddedSkill(skillname);
        }

        [When("I try to update the {string} {string} to {string} {string} in the table")]
        public void WhenITryToUpdateTheToInTheTable(string skillname, string skilllevel, string newskillname, string newskilllevel)
        {
            skillPage = new SkillPage();
            skillPage.Updatingskill(skillname, skilllevel, newskillname, newskilllevel);
            Hooks1.TrackAddedSkill(newskillname);

        }

        [When("I should see updated {string} and {string} in the table")]
        public void WhenIShouldSeeUpdatedAndInTheTable(string newskillname, string newskilllevel)
        {
            skillPage = new SkillPage();
            skillPage.IsSkillPresent(newskillname, newskilllevel);
            Assert.That(skillPage.IsSkillPresent(newskillname, newskilllevel), Is.True, "Skill not updated successfully");
        }

        [When("I ensure {string} and {string} are in list")]
        public void WhenIEnsureAndAreInList(string skillname, string skilllevel)
        {
           skillPage= new SkillPage();
            if(!skillPage.IsSkillPresent(skillname, skilllevel))
            {
                skillPage.AddSkill(skillname, skilllevel);
            }
        }

        [Then("I add duplicate entry of {string} and {string}")]
        public void ThenIAddDuplicateEntryOfAnd(string skillname, string skilllevel)
        {
            skillPage=new SkillPage();
            skillPage.AddSkill(skillname, skilllevel);
        }

        [Then("I should see error message indicating skill is already exists")]
        public void ThenIShouldSeeErrorMessageIndicatingSkillIsAlreadyExists()
        {
            skillPage = new SkillPage();
            string errorMessage = skillPage.GetDuplicateSkillMessage();
            string expectedMessage = "This skill is already exist in your skill list.";
            Assert.That(errorMessage, Is.EqualTo(expectedMessage), "Error message not displayed as expected");
        }

        [When("I try to add skill {string} with blank space and {string}")]
        public void WhenITryToAddSkillWithBlankSpaceAnd(string skillname, string skilllevel)
        {
            skillPage = new SkillPage();
            skillPage.Tryaddskill(skillname, skilllevel);
        }


        [Then("I should see the error message saying please enter skill and level.")]
        public void ThenIShouldSeeTheErrorMessageSayingPleaseEnterSkillAndLevel_()
        {
            skillPage = new SkillPage();
            string errorMessage = skillPage.GetBlankSkillMessage();
            string expectedMessage = "Please enter skill and experience level";
            Assert.That(errorMessage, Is.EqualTo(expectedMessage), "Error message not displayed as expected");
        }
        [When("I try to delete a non-existing skill {string}")]
        public void WhenITryToDeleteANon_ExistingSkill(string skill)
        {
            skillPage = new SkillPage();
            skillPage.Deletingskill(skill);
        }

        /*[Then("I should see an error message indicating the skill does not exist")]
        public void ThenIShouldSeeAnErrorMessageIndicatingTheSkillDoesNotExist()
        {
            
        }*/
        [Then("I should see a message indicating that the skill {string} does not exist")]
        public void ThenIShouldSeeAMessageIndicatingThatTheSkillDoesNotExist(string sQL)
        {
            
        }






    }
}
