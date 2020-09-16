using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject
{
    class FilterObjectModel
    {
        // Constructor

        [Obsolete]
        public FilterObjectModel()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        // Constructor
        // // // // //
        // Element tanımlama

        [FindsBy(How = How.ClassName, Using = "iconElektro")]
        public IWebElement HoverElekctro { get; set; }
        [FindsBy(How = How.CssSelector, Using = "a[title='Bilgisayar']")]
        public IWebElement Computer { get; set; }

        [FindsBy(How = How.Id, Using = "brand-iss-Windows-10")]
        public IWebElement SelectW10Element { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div/div/div[2]/section[5]/span[2]")]
        public IWebElement MoreBrandItem { get; set; }

        [FindsBy(How = How.Id, Using = "brand-m-Lenovo")]
        public IWebElement SelectLenovoElement { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div/div/div[2]/section[6]/span[2]")]
        public IWebElement MoreProcessorItem { get; set; }

        [FindsBy(How=How.Id, Using = "brand-isr-Intel-Celeron")]
        public IWebElement SelectProcessorElement { get; set; }
        // Element tanımlama
        // // // // //
        // Metot tanımlama

        [Obsolete]
        public void VisibleAndClickElement()
        {
            WebDriverWait wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(10)); // 10 saniyeye kadar bekleme.
            var hoverElement = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("iconElektro"))); // Üzerine gelinecek olan element.
            Actions action = new Actions(Properties.driver); // Referans oluşturma.
            action.MoveToElement(hoverElement).Perform(); // Belirtilen olan elementin üzerine gelir.
            System.Threading.Thread.Sleep(4000); // Menü aktif olana kadar bekler.
            Computer.Click(); // title özelliği "Bilgisayar" olan elemana tıklar.
        }

        public void FilterProducts()
        {
            IJavaScriptExecutor js = Properties.driver as IJavaScriptExecutor; // JavaScript özelliklerinin kullanılabileceği referansı oluşturur.
            js.ExecuteScript("window.scrollBy(0,650)"); // Scroll çubuğunu Y ekseninde 650 birim aşağı çeker.
            SelectW10Element.Click(); // Windows 10 checkbox'ına tıklar.
            Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3); // Sayfanın yüklenmesi için bekler.
            js.ExecuteScript("window.scrollBy(0,650)"); // Scroll çubuğunu Y ekseninde 650 birim aşağı çeker.
            MoreBrandItem.Click(); // Daha fazla göster'e tıklar.
            js.ExecuteScript("window.scrollBy(650,680)"); // Scroll çubuğunu Y ekseninde 150 birim aşağı çeker.
            SelectLenovoElement.Click(); // Lenovo checkbox'ına tıklar.
            js.ExecuteScript("window.scrollBy(0,750)"); // Scroll çubuğunu Y ekseninde 650 birim aşağı çeker.
            MoreProcessorItem.Click(); // Daha fazla göster'e tıklar.
            SelectProcessorElement.Click(); // Intel Celeron işlemci checkbox'ına tıklar.
        }
        public void FilterProductsNames() // Ürünler sayfasındaki tüm ürünlerin "title"larını alıp konsola yazdırır.
        {
            IReadOnlyCollection<IWebElement> products = Properties.driver.FindElements(By.ClassName("productName"));

            foreach (var item in products)
            {
                var p = item.Text;
                Console.WriteLine(p);
            }
        }
        // Metot tanımlama
    }
}
