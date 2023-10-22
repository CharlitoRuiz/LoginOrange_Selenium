using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginOrange.PageObject.Login
{
    public class LoginPage :  BasePage
    {
        // Constructor
        public LoginPage(string url, IWebDriver driver) : base(url, driver) { }

        // Localizadores
        private By txtUsername = By.CssSelector("input[name='username']");
        private By txtPassword = By.CssSelector("input[type='password']");
        private By btnLogin = RelativeBy.WithLocator(By.TagName("button")).Below(By.Name("password"));
        private By lnkUser = By.CssSelector("i.oxd-userdropdown-icon");
        private By btnLogout = By.CssSelector("a[href='/web/index.php/auth/logout']");

        // Set
        public IWebElement set_txtUsername() { return _webDriver.FindElement(this.txtUsername); }
        public IWebElement set_txtPassword() { return _webDriver.FindElement(this.txtPassword); }
        public IWebElement set_btnLogin() { return _webDriver.FindElement(this.btnLogin); }
        public IWebElement set_lnkUser() { return _webDriver.FindElement(this.lnkUser); }
        public IWebElement set_btnLogout() { return _webDriver.FindElement(this.btnLogout); }

        // Metodos
        public void enterUsername(string pass)
        {
            set_txtUsername().SendKeys(pass);
        }
        public void enterPass(string pass)
        {
            set_txtPassword().SendKeys(pass);
        }

        public void clickLoginButtom()
        {
            set_btnLogin().Click();
        }
        public void LogoutUser()
        {
            set_lnkUser().Click();
            set_btnLogout().Click();
        }
    }
}
