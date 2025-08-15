using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboardingIC.Pages
{
    public class LoginPage
    {
        public void LoginAction(IWebDriver driver)
        {
           driver.Navigate().GoToUrl("http://localhost:5003/Home");
            IWebElement SigninButton = driver.FindElement(By.XPath("//a[@class='item']"));
            SigninButton.Click();

            IWebElement Email =driver.FindElement(By.XPath("//input[@name='email']"));
            Email.SendKeys("jeroshirley@gmail.com");    

            IWebElement Password = driver.FindElement(By.XPath("//input[@name='password']"));
            Password.SendKeys("World!123");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='fluid ui teal button']")));
            IWebElement LoginButton = driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
            LoginButton.Click();
            Thread.Sleep(2000); // Wait for the page to load after login



        }


    }
}
