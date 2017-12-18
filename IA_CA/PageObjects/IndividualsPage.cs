using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace IA_CA.PageObjects
{
    class IndividualsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@href='/mortgage' and @data-utag-name='mortgage_loan']")]
        [CacheLookup]
        private IWebElement mortgagesLink;

        [FindsBy(How = How.XPath, Using = "//li[@class='dropdown Pret three-items ']")]
        [CacheLookup]
        private IWebElement loans;

        public IndividualsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// This method clicks LOANS and clicks Mortgages link. Returns nothing. 
        /// </summary>
        public MortgagePage ClickOnTheMortgagesLink()
        {
            loans.Click();
            mortgagesLink.Click();
            return new MortgagePage(driver);
        }
    }
}
