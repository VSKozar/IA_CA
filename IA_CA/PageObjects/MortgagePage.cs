using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IA_CA.PageObjects
{
    class MortgagePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@href='/mortgage-payment-calculator' and @class='btn-full']")]
        [CacheLookup]
        private IWebElement calculateYourPayments;

        public MortgagePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// This method clicks the Calculate Your Payments button. Returns nothing.
        /// </summary>
        /// <returns></returns>
        public MortgagePaymentCalculatorPage ClickOnCalculateYourPaymentsBtn()
        {
            calculateYourPayments.Click();
            return new MortgagePaymentCalculatorPage(driver);
        }
    }
}
