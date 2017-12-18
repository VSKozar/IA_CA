using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace IA_CA.PageObjects
{
    class MortgagePaymentCalculatorPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='row']//button[@id='PrixProprieteMinus']/../*[2]/*/div[@class='slider-handle min-slider-handle custom']")]
        [CacheLookup]
        private IWebElement purchasePriceSlider;

        [FindsBy(How = How.XPath, Using = "//*[@id='PrixPropriete']")]
        [CacheLookup]
        private IWebElement purchasePriceInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='PrixProprietePlus']")]
        [CacheLookup]
        private IWebElement purchasePricePlusBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='row']//button[@id='MiseDeFondMinus']/../*[2]/*/div[@class='slider-handle min-slider-handle custom']")]
        [CacheLookup]
        private IWebElement downPaymentSlider;

        [FindsBy(How = How.XPath, Using = "//*[@id='MiseDeFondPlus']")]
        [CacheLookup]
        private IWebElement downPaymentPlusBtn;

        /// <summary>
        /// This method clicks the Calculate Your Payments button. Returns nothing.
        /// </summary>
        /// <param name="driver"></param>
        public MortgagePaymentCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// This method moves the Purchase Price slider to the right. Returns nothing.
        /// </summary>
        /// <param name="sliderWidth">Offset X</param>
        public void SlidePurchasePrice(int sliderWidth)
        {
            int xCoord = purchasePriceSlider.Location.X;
            Actions builder = new Actions(driver);
            builder.MoveToElement(purchasePriceSlider)
                   .Click()
                   .DragAndDropToOffset(purchasePriceSlider, xCoord + sliderWidth, 0)
                   .Build()
                   .Perform();
        }

        /// <summary>
        /// This method gets value of Purchase price field.
        /// </summary>
        /// <returns>string</returns>
        public string GetPurchasePriceValue()
        {
            return purchasePriceInput.GetAttribute("value");
        }

        /// <summary>
        /// This method cleans Purchase price field. Returns nothing.
        /// </summary>
        public void CleanPurchasePriceField()
        {
            purchasePriceInput.SendKeys("");
        }

        /// <summary>
        /// This method click on the "+" button of the Purchase Price slider. Returns nothing.
        /// </summary>
        /// <param name="times">Times to run.</param>
        public void ClickPurchasePricePlusBtn(int times)
        {
            for (int item = 1; item <= times; item++)
            {
                purchasePricePlusBtn.Click();
            }
        }

        /// <summary>
        /// This method click on the "+" button of the Down Payment slider. Returns nothing. 
        /// </summary>
        /// <param name="times">Times to run.</param>
        public void ClickDownPaymentPlusBtn(int times)
        {
            for (int item = 1; item <= times; item++)
            {
                downPaymentPlusBtn.Click();
            }
        }

        public void SelectAmortization()
        {
            // TO DO
        }
    }
}
