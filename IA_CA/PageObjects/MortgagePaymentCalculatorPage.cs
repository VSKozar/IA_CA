using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using static IA_CA.CustomTypes.CalculatorTypes;

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

        [FindsBy(How = How.XPath, Using = "//button[@id='PrixProprieteMinus']")]
        [CacheLookup]
        private IWebElement purchasePriceMinusBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='row']//button[@id='MiseDeFondMinus']/../*[2]/*/div[@class='slider-handle min-slider-handle custom']")]
        [CacheLookup]
        private IWebElement downPaymentSlider;

        [FindsBy(How = How.XPath, Using = "//*[@id='MiseDeFondPlus']")]
        [CacheLookup]
        private IWebElement downPaymentPlusBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-med-1-2 col-lg-1-3']//b[@class='button']")]
        [CacheLookup]
        private IWebElement amortizationBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='selectric-wrapper selectric-responsive']//b")]
        [CacheLookup]
        private IWebElement paymentFrequencyBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='TauxInteret']")]
        [CacheLookup]
        private IWebElement interestRateField;

        [FindsBy(How = How.XPath, Using = "//*[@id='btn_calculer']")]
        [CacheLookup]
        private IWebElement calculateBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='resultats']")]
        [CacheLookup]
        private IWebElement paiementResult;

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
            for (int item = 0; item < 9; item++)
            {
                purchasePriceMinusBtn.Click();
            }
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

        /// <summary>
        /// This method selects value from Amortization fields. Returns nothing.
        /// </summary>
        /// <param name="amortizationEnum">use Amortization type</param>
        public void SelectAmortization(Amortization amortizationEnum)
        {
            string amortizationPath = "//div[@class='col-med-1-2 col-lg-1-3']//ul//*[";
            amortizationBtn.Click();
            amortizationEnum++;
            int item = (int)amortizationEnum;
            IWebElement amortizationSelect = driver.FindElement(By.XPath(amortizationPath + item + "]"));
            amortizationSelect.Click();

        }

        /// <summary>
        /// This method selects value from Payment Frequency field. Returns nothing.
        /// </summary>
        /// <param name="paymentFrequency">use PaymentFrequency type</param>
        public void SelectPaymentFrequency(PaymentFrequency paymentFrequency)
        {
            string paymentFrequencyPath = "//*[@id='FrequenceVersement']//..//..//div[@class='selectric-scroll']//ul//*[";
            paymentFrequencyBtn.Click();
            paymentFrequency++;
            int item = (int)paymentFrequency;
            IWebElement paymentFrequencySelect = driver.FindElement(By.XPath(paymentFrequencyPath + item + "]"));
            paymentFrequencySelect.Click();

        }

        /// <summary>
        /// This method inserts value to the Interest Rate field. Returns nothing. 
        /// </summary>
        /// <param name="rate">Rate %</param>
        public void SpecifyInterestRate(double rate)
        {
            interestRateField.Clear();
            interestRateField.SendKeys(rate.ToString());
        }

        /// <summary>
        /// Method clicks Calculate button. Returns nothing.
        /// </summary>
        public void clickCalculateBtn()
        {
            calculateBtn.Click();
        }

        /// <summary>
        /// Method returns calculation result.
        /// </summary>
        /// <returns></returns>
        public string getPaiementResult()
        {
            string[] result = paiementResult.Text.Split(' ');
            return result[5];
        }
    }
}
