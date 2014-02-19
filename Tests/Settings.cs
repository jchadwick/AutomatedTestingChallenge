using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests {
    
    internal sealed partial class Settings {

        public string GetUrl(string path)
        {
            return string.Format("{0}{1}", BaseUrl, path);
        }

        public IWebDriver GetWebDriver()
        {
            return new ChromeDriver();
        }
    }
}
