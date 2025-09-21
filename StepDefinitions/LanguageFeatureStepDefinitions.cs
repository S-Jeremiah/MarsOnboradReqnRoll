using MarsOnboardingIC.Features;
using MarsOnboardingIC.Hooks;
using MarsOnboardingIC.Pages;
using MarsOnboardingIC.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Log;
using Reqnroll;
using System;
using Assert = NUnit.Framework.Assert; 

namespace MarsOnboardingIC.StepDefinitions 
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        
       
        LoginPage loginPage;
        HomePage homePage;
        LanguagePage languagePage;


        public LanguageFeatureStepDefinitions()
        {
            
        }

        [Given("I logged in as a user")]
        public void GivenILoggedInAsAUser()
        {
            loginPage= new LoginPage();
            loginPage.NavigateToLoginPage();
            loginPage.LoginAction();
            //LoginPage loginPageObj = new LoginPage();
            //loginPageObj.LoginAction(driver);

        }

        [When("I navigate to the language management page")]
        public void WhenINavigateToTheLanguageManagementPage()
        {

            homePage = new HomePage();
            homePage.NavigateToLanguage();
            
        }

        

        [When("I add {string} and {string} to the list")]
        public void WhenIAddAndToTheList(string language, string level)
        {
            languagePage = new LanguagePage();
            languagePage.AddLanguage(language, level);

            Hooks1.TrackAddedLanguage(language);

        }


       /*8 [Then("I should see the new {string} and {string} in the list")]
        public void ThenIShouldSeeTheNewAndLanguagelevelInTheList(string newlanguage,string languagelevel)
        {
            languagePage = new LanguagePage();
            string newLanguage = languagePage.GetLanguage();
            Assert.That(newLanguage == newlanguage, "Language not added successfully");
            string newlanglevel = languagePage.GetLanguageLevel();
            Assert.That(newlanglevel == languagelevel, "Language level not added successfully");
           
        }*/

        [Then("I should see the new {string} and {string} in the list")]
        public void ThenIShouldSeeTheNewAndLanguagelevelInTheList(string language, string level)
        {
            languagePage = new LanguagePage();
            Assert.That(languagePage.IsLanguagePresent(language,level), Is.True, "Language not added successfully");

        }

        [When("I update the{string} to {string}  and {string} to {string} in the language list")]
        public void WhenIUpdateTheToAndToInTheLanguageList(string existingLanguage, string newLanguage, string existingLevel, string newLevel)
        {
            languagePage= new LanguagePage();
            languagePage.UpdateLanguage(existingLanguage, newLanguage, existingLevel, newLevel);
            Hooks1.TrackAddedLanguage(newLanguage);
        }

        [Then("I should see the language {string} and {string}  in the list")]
        public void ThenIShouldSeeTheLanguageAndInTheList(string newLanguage, string newLevel)
        {
            languagePage = new LanguagePage();
            Assert.That(languagePage.IsLanguagePresent(newLanguage, newLevel), Is.True, "Language not updated successfully");
        }


        [When("I add {string} to the list")]
        public void WhenIAddToTheList(string language)
        {
           languagePage = new LanguagePage();
            languagePage.AddonlyLanguage(language);

            Hooks1.TrackAddedLanguage(language);
        }


        [When("I delete the language {string} from the list")]
        public void WhenIDeleteTheLanguageFromTheList(string language)
        {
            languagePage = new LanguagePage();
            languagePage.DeleteLanguage(language);
         

        }

        [Then("I should not see the language {string} in the list")]
        public void ThenIShouldNotSeeTheLanguageInTheList(string deletelanguage)
        {
            languagePage = new LanguagePage();
            Thread.Sleep(1000); // Wait for the language to be deleted
            Assert.That(languagePage.IsLanguageDeleted(deletelanguage), Is.True, "Language not deleted successfully");
            
        }
        [When("I add blank{string} and {string} to the list")]
        public void WhenIAddBlankAndToTheList(string language, string level)
        {
            languagePage = new LanguagePage();
            languagePage.TryAddLanguage(language, level);
        }


        [Then("I should see an error message indicating that the language name is required")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatTheLanguageNameIsRequired()
        {
            languagePage = new LanguagePage();
            string errorMessage = languagePage.GetErrorMessage();
            string expectedMessage = "Please enter language and level";
            Assert.That(errorMessage, Is.EqualTo(expectedMessage), "Error message not displayed as expected");  
        }

        
        [When("I ensure {string} with {string} exists in the list")]
        public void WhenIEnsureWithExistsInTheList(string language, string level)
        {
            languagePage = new LanguagePage();
            if(!languagePage.IsLanguagePresent(language, level))
            {
                languagePage.AddLanguage(language, level);
            }
        }

        [When("I add duplicate entry of {string} and {string} to the list")]
        public void WhenIAddDuplicateEntryOfAndToTheList(string language, string level)
        {
            languagePage = new LanguagePage();
            languagePage.AddLanguage(language, level);
        }


        [Then("I should see an error message indicating that the language already exists")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatTheLanguageAlreadyExists()
        {
            string errorMessage = languagePage.GetDuplicateErrorMessage();
            string expectedMessage = "This language is already exist in your language list.";
            Assert.That(errorMessage, Is.EqualTo(expectedMessage), "Error message not displayed as expected");
        }


    }
}
