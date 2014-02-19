using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class ClientListPage
    {
        private static IWebDriver driver;


        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = ".col-md-4")]
        private IList<IWebElement> clientElements;

        public int ClientCount
        {
            get { return clientElements.Count; }
        }

        public IEnumerable<ClientSummaryElement> ClientSummaries
        {
            get { return clientElements.Select(ClientSummaryElement.Create); }
        }

        public static ClientListPage NavigateTo(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl(Settings.Default.GetUrl(""));
            var searchPage = new ClientListPage();
            PageFactory.InitElements(driver, searchPage);
            return searchPage;
        }


        public class ClientSummaryElement
        {
            private readonly IWebElement _element;

            public ClientSummaryElement(IWebElement element)
            {
                _element = element;
            }

            public string Name
            {
                get { return _element.FindElement(By.TagName("h2")).Text; }
            }
            public string Address
            {
                get { return _element.FindElement(By.ClassName("address")).Text; }
            }

            public static ClientSummaryElement Create(IWebElement element)
            {
                return new ClientSummaryElement(element);
            }
        }
    }
}
