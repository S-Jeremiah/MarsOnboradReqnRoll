using System;
using MarsOnboardingIC.Pages;
using MarsOnboardingIC.Utilities;
using NUnit.Framework;
using Reqnroll;

namespace MarsOnboardingIC.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPage;
        HomePage homePage;

        public LoginFeatureStepDefinitions()
        {
           
        }
        [Given("I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {
            loginPage = new LoginPage();
            loginPage.NavigateToLoginPage();

        }


        [When("I enter valid {string} and {string}")]
        public void WhenIEnterValidAnd(string emailID, string password)
        {
            loginPage = new LoginPage();
            loginPage.LoginWithValidCredentials(emailID, password);
        }

        [Then("I should be redirected to the dashboard and see my profile name")]
        public void ThenIShouldBeRedirectedToTheDashboardAndSeeMyProfileName()
        {
           homePage = new HomePage();   
           string username = homePage.GetLoggedInUserName();
            string expectusername = "Hi Shirley";
            Assert.That(username, Is.EqualTo(expectusername),"login was not successfull");
            
        }
        
        [When("I enter correctemail and incorrectpassword")]
        public void WhenIEnterCorrectemailAndIncorrectpassword(DataTable dataTable)
        {
            loginPage = new LoginPage();
            var data = dataTable.Rows[0];
            string email = data["Email"];
            string password = data["password"];
            loginPage.LoginWithInvalidCredentials(email, password);
            
        }

        [Then("I should see an error message indicating invalid password")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidPassword()
        {   
            string errorMessage = loginPage.GetInvalidPasswordMessage();
            string expectedMessage = "Password must be at least 6 characters";
            Assert.That(errorMessage, Is.EqualTo(expectedMessage), "Error message not displayed as expected");

        }
        [When("I enter invalidemail and correctpassword")]
        public void WhenIEnterInvalidemailAndCorrectpassword(DataTable dataTable)
        {
            loginPage = new LoginPage();
            var data = dataTable.Rows[0];
            string email = data["Email"];
            string password = data["password"];
            loginPage.LoginWithInvalidCredentials(email, password);
        }

        [Then("I should see an error message indicating invalid email")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidEmail()
        {
            string errorMessage = loginPage.GetInvalidEmailMessage();
            string expectedMessage = "Please enter a valid email address";
            Assert.That(errorMessage, Is.EqualTo(expectedMessage), "Error message not displayed as expected");
        }
        [When("I enter correct email and wrong password")]
        public void WhenIEnterCorrectEmailAndWrongPassword(DataTable dataTable)
        {
            var data = dataTable.Rows[0];
            string email = data["Email"];
            string password = data["password"];
            loginPage.LoginWithInvalidCredentials(email, password);

        }

        [Then("I should see an error message to check mail")]
        public void ThenIShouldSeeAnErrorMessageToCheckMail()
        {
            string errorMessage = loginPage.GetErrorMessage();
            string expectedMessage = "Confirm your email";
            Assert.That(errorMessage, Is.EqualTo(expectedMessage), "Error message not displayed as expected");
        }
        

    }
}
