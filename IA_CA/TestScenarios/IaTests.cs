using NUnit.Framework;
using OpenQA.Selenium;
using IA_CA.Core;
using IA_CA.PageObjects;

namespace IA_CA
{
    [TestFixture]
    public class IaTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            driver = WebDriverSingletone.Driver;
            driver.Manage().Window.Maximize();
            // 1. Open the www.ia.ca in the Chrome browser
            driver.Navigate().GoToUrl("https://ia.ca/individuals");
        }

        [Test]
        public void TestMethod1()
        {
            // 2. Click LOANS
            // 3. Click the Mortgages link
            IndividualsPage individualsPage = new IndividualsPage(driver);
            MortgagePage mortgagePage = individualsPage.ClickOnTheMortgagesLink();

            // 4. Click the Calculate Your Payments button
            MortgagePaymentCalculatorPage mortgagePaymentCalculatorPage = mortgagePage.ClickOnCalculateYourPaymentsBtn();

            // 5. Move the Purchase Price Slider to the right
            mortgagePaymentCalculatorPage.SlidePurchasePrice(30);

            // 6. Validate that the Purchase Price Slider movement works
            StringAssert.AreEqualIgnoringCase("1763766", mortgagePaymentCalculatorPage.GetPurchasePriceValue());

            // 7. Change the Purchase Price to 500 000 using the + button of the slider
            mortgagePaymentCalculatorPage.CleanPurchasePriceField();
            mortgagePaymentCalculatorPage.ClickPurchasePricePlusBtn(2);

            // 8. Change the Down Payment to 50 000 using the + button of the slider
            mortgagePaymentCalculatorPage.ClickDownPaymentPlusBtn(5);

            // 9. Select 15 years for Amortization
            // TO DO ...

        }

        [TearDown]
        public void AfterTest()
        {
            //driver.Close();
        }
    }
}
