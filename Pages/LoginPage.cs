using MarsOnboardingIC.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardingIC.Pages
{
    public class LoginPage : CommonDriver
    {
        
        private readonly WebDriverWait wait;

        private readonly By SigninButton = By.XPath("//a[@class='item' and text() ='Sign In']");
        private readonly By Email = By.XPath("//input[@name='email']");
        private readonly By Password = By.XPath("//input[@name='password']");
        private readonly By LoginButton = By.XPath("//button[@class='fluid ui teal button']");
        private readonly By ErrorMessage = By.XPath("//div[@class='ns-box-inner']");
        private readonly By IinvalidEmailID =By.XPath("//div[@class='ui basic red pointing prompt label transition visible'][1]");
        private readonly By InvalidPassword = By.XPath("//input[@name='password']/following-sibling::div[contains(@class,'ui basic red pointing prompt label')]");
        public LoginPage()
        {
            
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }
        
        public void NavigateToLoginPage()
        {
            Driver.Navigate().GoToUrl("http://localhost:5003/Home");
            
        }
        
        public void LoginAction()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SigninButton));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SigninButton));
            Driver.FindElement(SigninButton).Click();
            Driver.FindElement(Email).SendKeys("jeroshirley@gmail.com");
            Driver.FindElement(Password).SendKeys("World!123");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LoginButton));
            Driver.FindElement(LoginButton).Click();
        }
         public void LoginWithValidCredentials(string emailID, string password) 
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SigninButton));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SigninButton));
            Driver.FindElement(SigninButton).Click();
            Driver.FindElement(Email).SendKeys(emailID);
            Driver.FindElement(Password).SendKeys(password);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LoginButton));
            Driver.FindElement(LoginButton).Click();
        }
        public void LoginWithInvalidCredentials(string invalidemailID, string incorrectpassword)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SigninButton));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SigninButton));
            Driver.FindElement(SigninButton).Click();
            Driver.FindElement(Email).SendKeys(invalidemailID);
            Driver.FindElement(Password).SendKeys(incorrectpassword);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LoginButton));
            Driver.FindElement(LoginButton).Click();
        }
        public string GetErrorMessage()
        {
            try
            {
                var errorElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ErrorMessage));
                return errorElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty; 
            }
        }
        public string GetInvalidEmailMessage()
        {
            try
            {
                var invalidEmailElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(IinvalidEmailID));
                return invalidEmailElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty; 
            }
        }

        public string GetInvalidPasswordMessage()
        {
            try
            {
                var invalidPasswordElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(InvalidPassword));
                return invalidPasswordElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty; 
            }
        }
    }

}
