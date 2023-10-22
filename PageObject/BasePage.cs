using OpenQA.Selenium;

namespace LoginOrange.PageObject
{
    public class BasePage
    {
        public IWebDriver _webDriver;
        public string baseURL;

        public BasePage(string url, IWebDriver driver)
        {
            this._webDriver = driver;
            this.baseURL = url;
        }
    }
}
