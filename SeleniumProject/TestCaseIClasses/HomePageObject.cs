using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject
{
    class HomePageObject
    {

        // Constructor

        [Obsolete]
        public HomePageObject()
        {
            // Sayfa çalıştığında aşağıda belirtilen özelliklerin yüklenmesini sağlar.
            PageFactory.InitElements(Properties.driver,this);
        }

        // Constructor
        // // // // //
        // Element tanımlama

        [FindsBy(How = How.Id, Using = "searchData")]
        public IWebElement SearchData { get; set; }

        [FindsBy(How = How.ClassName, Using = "searchBtn")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href=\"https://www.n11.com/televizyon-ve-ses-sistemleri/televizyon?q=samsung\"]")]
        public IWebElement Link { get; set; }

        // Element tanımlama
        // // // // //
        // Metot tanımlama

        [Obsolete]
        public ProductPageObject EnterValue(string value)
        {
            SearchData.SendKeys(value);
            Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Link.Click();

            return new ProductPageObject();
        }

        // Metot tanımlama
    }
}
