using AventStack.ExtentReports;
using LoginOrange.Genericos;
using LoginOrange.PageObject.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LoginOrange.Test.Login
{
    public class Tests : BaseTest
    {
        CargarJson logindata = new CargarJson();
        HandleErrors handleError = new HandleErrors();

        [Test]
        public void ValidLogin()
        {
            // Instancias
            LoginPage login = new LoginPage(baseURL, driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            test = extent.CreateTest("Enter login true");
            POJO.LoginData login_object = logindata.login_data();

            // Object
            String user = login_object.username;
            String pass = login_object.password;

            try
            {
                login.enterUsername(user);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(login.set_txtUsername(), user));
                test.Log(Status.Pass, "Enter username credential: " + user);
                login.enterPass(pass);
                test.Log(Status.Pass, "Enter password: " + pass);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(login.set_btnLogin()));
                login.clickLoginButtom();
                Assert.IsTrue(driver.Url.ToUpper().Contains("DASHBOARD/INDEX"));
                test.Log(Status.Pass, "Enter correctly to page");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(login.set_lnkUser()));
                String photo = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(photo);
                login.LogoutUser();
                Assert.IsTrue(driver.Url.ToUpper().Equals("HTTPS://OPENSOURCE-DEMO.ORANGEHRMLIVE.COM/WEB/INDEX.PHP/AUTH/LOGIN"));
            }
            catch (Exception e)
            {
                handleError.CatchError(test, driver, e);
            }

        }
    }
}