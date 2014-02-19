using System.Linq;
using DemoWebApp.Model;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.Pages;
using Xunit;

namespace Tests.Steps
{
    [Binding]
    public class ClientListSteps
    {
        private IWebDriver driver;
        private ClientListPage _clientListPage;
        private int _clientCount;

        [BeforeScenario()]
        public void Setup()
        {
            driver = Settings.Default.GetWebDriver();
        }

        [AfterScenario()]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"I have clients defined in the system")]
        public void GivenIHaveClientsDefinedInTheSystem()
        {
            using (var db = new ClientDataContext())
            {
                _clientCount = db.Clients.Count();
            }
        }

        [When(@"I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            _clientListPage = ClientListPage.NavigateTo(driver);
        }

        [Then(@"I should see summaries for all of the clients defined in the system")]
        public void ThenIShouldSeeSummariesOfEachClient()
        {
            Assert.Equal(_clientCount, _clientListPage.ClientCount);
        }

        [Then(@"they should contain the following data:")]
        public void ThenTheyShouldContainTheFollowingData(Table table)
        {
            var clients = _clientListPage.ClientSummaries;

            foreach (var row in table.Rows)
            {
                Assert.Contains(row["Name"], clients.Select(x => x.Name));
                Assert.Contains(row["Address"], clients.Select(x => x.Address));
            }
        }

    }
}
