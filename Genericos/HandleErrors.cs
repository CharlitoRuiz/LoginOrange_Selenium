using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginOrange.Genericos
{
    public class HandleErrors
    {  
        public void CatchError(ExtentTest test, IWebDriver driver, Exception e)
        {
            String error = Convert.ToString(e);
            SaveScreenshoot(test, driver, error);
            Assert.Fail(error);
        }

        private string SaveScreenshoot(ExtentTest test, IWebDriver driver, String error)
        {
            string file = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            test.Log(Status.Fail, "Prueba fallida: " + error);
            test.AddScreenCaptureFromBase64String(file);
            return file;
        }
    }
}
