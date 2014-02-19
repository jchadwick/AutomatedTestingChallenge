using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class ClientListPage
    {
        private static IWebDriver driver;


        [FindsBy(How = How.CssSelector, Using = ".col-md-4")]
        private IList<IWebElement> clientElements;

        public int ClientCount
        {
            get { return clientElements.Count; }
        }


        public static ClientListPage NavigateTo(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl(Settings.Default.GetUrl(""));
            var searchPage = new ClientListPage();
            PageFactory.InitElements(driver, searchPage);
            return searchPage;
        }
    }
}
