using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class AwsLogginer
    {
        public void PutAccountAttrsToLoginForm(RemoteWebDriver driver)
        {
            IWebElement emailInput = driver.FindElementById("ap_email");
            IWebElement passInput = driver.FindElementById("ap_password");
            IWebElement signInButton = driver.FindElementById("signInSubmit");

            string awsEmail = AccountRepository.CurrentAccount.Email;
            string awsPass = AccountRepository.CurrentAccount.Password;


            emailInput.SendKeys(awsEmail);
            passInput.SendKeys(awsPass);
            signInButton.Click();
        }



        public void PutCodeToLoginForm(RemoteWebDriver driver,  string code)
        {
            IWebElement otpCode = driver.FindElementById("auth-mfa-otpcode");
            IWebElement mfaSubmit = driver.FindElementById("auth-signin-button");

            otpCode.SendKeys(code);
            mfaSubmit.Click();
        }
    }
}
