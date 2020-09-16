using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject
{

    class ProductPageObject
    {

        // Constructor

        [Obsolete]
        public ProductPageObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        // Constructor
        // // // // //
        // Element tanımlama

        [FindsBy(How = How.ClassName, Using = "productName")]
        public IWebElement ProductsName { get; set; }

        [FindsBy(How = How.ClassName, Using = "plink")]
        public IWebElement GoToProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div/div[3]/div[1]/div[1]/div[2]/div[4]/div[2]/div[2]/a")]
        public IWebElement AddBasket { get; set; }

        [FindsBy(How = How.ClassName, Using = "myBasket")]
        public IWebElement GoBasket { get; set; }

        [FindsBy(How = How.Id, Using = "js-goToPaymentBtn")]
        public IWebElement Payment { get; set; }

        // Element tanımlama
        // // // // //
        // Metot tanımlama

        public void AllProductsNames() // Ürünler sayfasındaki tüm ürünlerin "title"larını alıp konsola yazdırır.
        {
            IReadOnlyCollection<IWebElement> products = Properties.driver.FindElements(By.ClassName("productName"));

            foreach (var item in products)
            {
                var p = item.Text;
                Console.WriteLine(p);
            }
        }

        public void ClickProduct()
        {
            Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            GoToProduct.Click();
        }
        public void AddtoBasket()
        {
            IJavaScriptExecutor js = Properties.driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,350)");
            AddBasket.Click();
            Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void GoToBasket()
        {
            GoBasket.Click();
        }
        public void PaymentProcess()
        {
            IJavaScriptExecutor js = Properties.driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,350)"); // Sayfa "Şifre Değiştir" elemanının görünür olması için aşağı iner.
            Payment.Click();
        }

        // Metot tanımlama
    }
}