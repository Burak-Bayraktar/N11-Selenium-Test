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
    class AskTheStoreObject
    {
        // Constructor

        [Obsolete]
        public AskTheStoreObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        // Constructor
        // // // // //
        // Element tanımlama
        [FindsBy(How = How.CssSelector, Using = ("span[title='Mağazalar']"))]
        public IWebElement Stores { get; set; }

        [FindsBy(How = How.CssSelector, Using = (".hBotMenuItem > div:nth-child(2) > div:nth-child(1) > a:nth-child(1)"))]
        public IWebElement SeeStores { get; set; }

        [FindsBy(How = How.CssSelector, Using = ("[placeholder=\"Sonuçlar içinde ara\"]"))]
        public IWebElement SearchResult { get; set; }

        [FindsBy(How = How.XPath, Using = ("/html/body/div[1]/div[2]/div/div[2]/div/div[2]/div[4]/div[1]/span[13]"))]
        public IWebElement K { get; set; }

        [FindsBy(How = How.Id, Using = ("allFilterSearchBtn"))]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("/html/body/div[1]/div[2]/div/div[2]/div/div[2]/div[4]/div[2]/ul/li[27]/a"))]
        public IWebElement KahveDunyasi { get; set; }

        [FindsBy(How = How.ClassName, Using = ("column"))]
        public IWebElement SelectProduct { get; set; }

        [FindsBy(How = How.Id, Using = ("askQuestion"))]
        public IWebElement Ask { get; set; }

        [FindsBy(How = How.Id, Using = ("askSellerBtn"))]
        public IWebElement AskSeller { get; set; }

        [FindsBy (How = How.ClassName, Using = ("errorText"))]
        public IWebElement ErrorText { get; set; }

        [FindsBy(How = How.Id, Using =("questionType"))]
        public IWebElement DDL { get; set; }

        [FindsBy(How = How.XPath, Using =("//*[@id=\"questionType\"]/option[4]"))]
        public IWebElement Subject { get; set; }

        [FindsBy(How = How.Id, Using = ("questionTitle"))]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.Id, Using = ("questionEmail"))]
        public IWebElement EMail { get; set; }

        [FindsBy(How = How.Id, Using = ("questionContent"))]
        public IWebElement Content { get; set; }

        [FindsBy(How = How.Id, Using = ("askQuestionBtn"))]
        public IWebElement AskQuestionButton { get; set; }


        // Element tanımlama
        // // // //
        // Metot tanımlama
        [Obsolete]
        public void HoverElement()
        {
            WebDriverWait wait = new WebDriverWait(Properties.driver, TimeSpan.FromSeconds(10)); // 10 saniyeye kadar bekleme.
            var hoverElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span[title=\"Mağazalar\"]"))); // Üzerine gelinecek olan element.
            Actions action = new Actions(Properties.driver); // Referans oluşturma.
            action.MoveToElement(hoverElement).Perform(); // Belirtilen olan elementin üzerine gelir.
            System.Threading.Thread.Sleep(4000); // Menü aktif olana kadar bekler.
            SeeStores.Click(); // title özelliği "Mağazaları Gör" olan elemana tıklar.

        }

        public void FindAndClickElement(string value)
        {
            IJavaScriptExecutor js = Properties.driver as IJavaScriptExecutor; // Javascript'e etki edecek referans.
            js.ExecuteScript("window.scrollBy(0,1300)"); // Kaydırma çubuğu Y ekseninde 1300 birim aşağı hareket eder.
            K.Click(); // K harfine tıklanır.
            SearchResult.SendKeys(value); // Parametre ile gelecek değer beklenir.
            System.Threading.Thread.Sleep(4000); // İçerik aktif olana kadar bekler.
            KahveDunyasi.Click(); // Parametre ile gelen değere tıklanır.
        }

        public void FindProduct()
        {
            IJavaScriptExecutor js = Properties.driver as IJavaScriptExecutor; // Javascript'e etki edecek referans.
            js.ExecuteScript("window.scrollBy(0,500)"); // Kaydırma çubuğu Y ekseninde 1300 birim aşağı hareket eder.
            SelectProduct.Click(); // İlgili ürüne tıklanır.
            System.Threading.Thread.Sleep(4000); // İçerik aktif olana kadar bekler.
            js.ExecuteScript("window.scrollBy(0,200)"); // Kaydırma çubuğu Y ekseninde 1300 birim aşağı hareket eder.
            Ask.Click(); // Mağazaya soru sor butonuna tıklanır ve otomatik olarak kaydırma çubuğu aşağı iner.
            System.Threading.Thread.Sleep(2000); // İçerik aktif olana kadar bekler.
            AskSeller.Click(); // Tekrardan mağazaya soru sor butonuna tıklanır.
            System.Threading.Thread.Sleep(2000); // İçerik aktif olana kadar bekler.

        }

        public void AskQuestion(string title, string mail, string content)
        {
            DDL.Click(); // Açılır menüye tıklar.
            System.Threading.Thread.Sleep(2000); // İçerik aktif olana kadar bekler.
            Subject.Click(); // Konuyu seçer.
            Title.SendKeys(title); // Konu başlığı yazar.
            EMail.SendKeys(mail); // E-mail'i yazar.
            Content.SendKeys(content); // Mesaj içeriğini yazar.
            //AskQuestionButton.Click(); // Bu butona tıklanırsa mağazaya soru gönderilir, o yüzden yorum satırına alınmıştır.
        }
        // Metot tanımlama
    }
}