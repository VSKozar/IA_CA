using NUnit.Framework;
using OpenQA.Selenium;
using IA_CA.Core;
using IA_CA.PageObjects;
using static IA_CA.CustomTypes.CalculatorTypes;
using System;
using System.Threading;

namespace IA_CA
{
    [TestFixture]
    public class IaTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            // LOGGER init
            Logger.InitLogger();

            // driver setup
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
            Logger.Log.Info("IaTests:  Clicked on the Mortgages link");

            // 4. Click the Calculate Your Payments button
            MortgagePaymentCalculatorPage mortgagePaymentCalculatorPage = mortgagePage.ClickOnCalculateYourPaymentsBtn();
            Logger.Log.Info("IaTests:  Clicked Calculate Your Payments button.");

            // 5. Move the Purchase Price Slider to the right
            mortgagePaymentCalculatorPage.SlidePurchasePrice(30);
            Logger.Log.Info("IaTests:  Moved the Purchase Price Slider to the right.");
            Logger.Log.Error("IaTests:  Testing error log!");

            // 6. Validate that the Purchase Price Slider movement works
            StringAssert.AreEqualIgnoringCase("1763766", mortgagePaymentCalculatorPage.GetPurchasePriceValue());
            Logger.Log.Info("IaTests:  Validated that the Purchase Price Slider movement works.");

            // 7. Change the Purchase Price to 500 000 using the + button of the slider
            mortgagePaymentCalculatorPage.CleanPurchasePriceField();
            mortgagePaymentCalculatorPage.ClickPurchasePricePlusBtn(2);
            Logger.Log.Info("IaTests:  Changed the Purchase Price to 500 000.");

            // 8. Change the Down Payment to 40 000 using the + button of the slider
            mortgagePaymentCalculatorPage.ClickDownPaymentPlusBtn(4);
            Logger.Log.Info("IaTests:  Changed the Down Payment to 40 000.");

            // 9. Select 15 years for Amortization
            mortgagePaymentCalculatorPage.SelectAmortization(Amortization.YEARS15);
            Logger.Log.Info("IaTests:  Selected 15 years for Amortization.");

            // 10. Select Weekly for Payment Frequency
            mortgagePaymentCalculatorPage.SelectPaymentFrequency(PaymentFrequency.WEEKLY);
            Logger.Log.Info("IaTests:  Selected Weekly for Payment Frequency.");

            // 11. Change the Interest Rate to 5%
            mortgagePaymentCalculatorPage.SpecifyInterestRate(5.0);
            Logger.Log.Info("IaTests:  Changed the Interest Rate to 5%");

            // 12. Click the Calculate button
            mortgagePaymentCalculatorPage.clickCalculateBtn();
            Logger.Log.Info("IaTests:  Clicked the Calculate button.");

            // Verify that the weekly payments value is 181.59
            Thread.Sleep(3000);
            StringAssert.AreEqualIgnoringCase("181.59", mortgagePaymentCalculatorPage.getPaiementResult());
            Logger.Log.Info("IaTests:  Verified that the weekly payments value is 181.59.");
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }
    }
}
