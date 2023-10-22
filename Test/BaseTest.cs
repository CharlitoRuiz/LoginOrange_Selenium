using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace LoginOrange.Test
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        public string baseURL = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        public static ExtentTest test;
        public static ExtentReports extent;

        [SetUp]
        public void starBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
        }
        [OneTimeSetUp]
        public void ReportStart()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName;

            string reportFolder = Path.Combine(projectRootDirectory, "Reportes");
            string reportPath = Path.Combine(reportFolder, "index.html");

            extent = new ExtentReports();
            ExtentSparkReporter htmlreporter = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(htmlreporter);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
        }

        [OneTimeTearDown]
        public void closeReporter()
        {
            extent.Flush();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
