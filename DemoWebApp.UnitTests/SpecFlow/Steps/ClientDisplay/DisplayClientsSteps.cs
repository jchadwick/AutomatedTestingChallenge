using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoWebApp.UnitTests
{
    [Binding]
    public class ClientDataDisplayedSteps
    {
        private DemoWebAppPage demoPage;
        private IWebDriver driver;
        private IEnumerable<Model2.Client> _clients;

        [BeforeScenario()]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [AfterScenario()]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"There are clients defined as")]
        public void GivenThatIHaveClientsDefined(Table table)
        {
            _clients = table.CreateSet<Model2.Client>();
        }
            
        [When(@"I load the page")]
        public void WhenILoadThePage()
        {
            demoPage = DemoWebAppPage.NavigateTo(driver);
        }

        [Then(@"all clients should be displayed with their name, address, and account summaries")]
        public void ThenClientsShouldBeDisplayedOnTheScreen()
        {
            var expectedClientCount = _clients.Count();
            var results = driver.FindElements(By.ClassName("col-md-4"));
            
            Assert.IsTrue(results.Count == expectedClientCount);
            
            Assert.IsTrue(results[0].FindElement(By.TagName("h2")).Text == "Client #1");
            Assert.IsTrue(results[1].FindElement(By.TagName("h2")).Text == "Client #2");
            
            Assert.IsTrue(results[0].FindElements(By.TagName("p"))[1].FindElement(By.TagName("span")).Text == "123 Test St., Testington, NJ 08615");
            Assert.IsTrue(results[1].FindElements(By.TagName("p"))[1].FindElement(By.TagName("span")).Text == "453 Test St., Testington, NJ 08615");
            
            Assert.IsTrue(results[0].FindElement(By.TagName("ul")).FindElements(By.TagName("li")).Count == 2);
            Assert.IsTrue(results[1].FindElement(By.TagName("ul")).FindElements(By.TagName("li")).Count == 2);
        }
    }
}
