using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IA_CA.Core
{
    public class WebDriverSingletone
    {
        private static IWebDriver driver;

        private WebDriverSingletone() { }

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                }
                return driver;
            }
        }
    }
}
