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
    public class LanguageFeatureStepDefinitions 
    {
        public IWebDriver driver;

        public LanguageFeatureStepDefinitions()
        {
            // Get driver instance from Hooks
            driver = Hooks.driver;
        }

        [Given("I logged in as a user")]
        public void GivenILoggedInAsAUser()
        {

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginAction(driver);

        }

        [When("I navigate to the language management page")]
        public void WhenINavigateToTheLanguageManagementPage()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToLanguage(driver);
        }

        

        [When("I add {string} and {string} to the list")]
        public void WhenIAddAndToTheList(string newlanguage, string languagelevel)
        {

            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.AddLanguage(driver, newlanguage,languagelevel);
        }

     


        [Then("I should see the new {string} and {string} in the list")]
        public void ThenIShouldSeeTheNewAndLanguagelevelInTheList(string newlanguage,string languagelevel)
        {
            LanguagePage languagePageObj = new LanguagePage();
            string newLanguage = languagePageObj.GetLanguage(driver);
            Assert.That(newLanguage == newlanguage, "Language not added successfully");
            string newlanglevel = languagePageObj.GetLanguageLevel(driver);
            Assert.That(newlanglevel == languagelevel, "Language level not added successfully");
        }



         [When("I update the{string} to {string} in the language list")]
        public void WhenIUpdateTheToInTheLanguageList(string languageName, string updatedlanguageName)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.UpdateLanguage(driver, languageName, updatedlanguageName);
        }

        [When("I update{string} to {string}")]
        public void WhenIUpdateTo(string languagelevel, string updaupdatedlanguagelevel)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.UpdateLanguageLevel(driver, languagelevel, updaupdatedlanguagelevel);
        }

        
        [Then("I should see the language {string} in the list")]
        public void ThenIShouldSeeTheLanguageInTheList(string updatedlanguageName)
        {
            LanguagePage languagePageObj = new LanguagePage();
            Thread.Sleep(2000); // Wait for the language to be updated
            Assert.That(languagePageObj.IsLanguagePresent(driver, updatedlanguageName), Is.True, "Language not updated successfully");
        }

        [Then("the language level should be {string} in the list")]
        public void ThenTheLanguageLevelShouldBeInTheList(string updatedlanguagelevel)
        {
            LanguagePage languagePageObj = new LanguagePage();
            Thread.Sleep(2000); // Wait for the language level to be updated
            Assert.That(languagePageObj.IsLanguageLevelPresent(driver, updatedlanguagelevel), Is.True, "Language level not updated successfully");
        }


        [When("I delete the language {string} from the list")]
        public void WhenIDeleteTheLanguageFromTheList(string deletelanguage)
        {
            LanguagePage languagePageObj = new LanguagePage();  
            languagePageObj.DeleteLanguage(driver, deletelanguage);

        }

        [Then("I should not see the language {string} in the list")]
        public void ThenIShouldNotSeeTheLanguageInTheList(string deletelanguage)
        {
            LanguagePage languagePageObj = new LanguagePage();
            Thread.Sleep(1000); // Wait for the language to be deleted
            Assert.That(languagePageObj.IsLanguagedeleted(driver, deletelanguage), Is.False, "Language not deleted successfully");
        }





    }
}
