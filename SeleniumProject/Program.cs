using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        [SetUp] // İlk olarak Initialize metodunun çalışmasını sağlar.
        public void Initialize()
        {

            // Firefox Driver oluşturuldu.
            Properties.driver = new FirefoxDriver();

            // n11 sitesine gider.
            Properties.driver.Navigate().GoToUrl("http://www.n11.com");

            // Eğer URL'ye başarılı bir şekilde giriş yapıldıysa konsola yazar.
            Console.WriteLine("Tarayıcı açılıp URL'ye girildi.");
        }

        string oldPassword = "ta24123456"; // Kullanıcının mevcut parolası.
        string newPassword = "ta241237456"; // Kullanıcın TestCaseIV ile değiştirilebilen yeni parolası.

        // ÖNEMLİ!!: TestCaseIV her çalıştırıldığında newPassword değişkeni oldPassword değişkenin yazılmalı ve newPassword
        // değişkenine farklı bir değer atanmalıdır.

        [Test]
        [Obsolete]
        public void TestCase_I()
        {

            // Test Case I

            LoginPageObject login = new LoginPageObject(); // LoginPageObject sınıfından bir nesne oluşturur.

            // FillLoginForm() metodu ile giriş formunu doldurup kullanıcıyı anasayfaya geri yönlendirir.
            HomePageObject pageHP = login.FillLoginForm("tanerrakyaz.15@gmail.com", oldPassword);
            
            pageHP.EnterValue("Samsung"); // "EnterValue" metodunu kullanarak arama kutusuna "Samsung" yazar.

            ProductPageObject product = new ProductPageObject(); // ProductPageObject sınıfından bir nesne oluşturur.
            product.AllProductsNames(); // Ürünlerin listelendiği sayfadaki tüm ürünlerin "title"larını alır ve konsola yazar.
            product.ClickProduct(); // Ürünün üstüne tıklar.
            product.AddtoBasket(); // Ürünü sepete ekler.
            product.GoToBasket(); // Sepete gider.
            product.PaymentProcess(); // Ödeme sayfasına gider.
        }

        [Test]
        [Obsolete]
        public void TestCase_II()
        {

            // TestCase II

            FilterObjectModel filter = new FilterObjectModel();
            filter.VisibleAndClickElement(); // "Kategoriler"i açar ve "Elektroni"k kısmına gelip "Bilgisayarlar"ın üzerine tıklar.
            filter.FilterProducts();
            filter.FilterProductsNames();
            
        }

        [Test]
        [Obsolete]
        public void TestCase_III()
        {

            // TestCase III

            LoginPageObject login = new LoginPageObject();
            HomePageObject pageHP = login.FillLoginForm("tanerrakyaz.15@gmail.com", oldPassword);

            AskTheStoreObject askTheStore = new AskTheStoreObject();
            askTheStore.HoverElement();
            askTheStore.FindAndClickElement("KahveDunyasi");
            askTheStore.FindProduct();
            askTheStore.AskQuestion("Test", "tanerrakyaz.15@gmail.com", "TESTESTESTEST");
        }

        [Test]
        [Obsolete]
        public void TestCase_IV()
        {

            // Test Case IV

            LoginPageObject login = new LoginPageObject();
            HomePageObject pageHP = login.FillLoginForm("tanerrakyaz.15@gmail.com", oldPassword);

            ChangePasswordObject changePassword = new ChangePasswordObject();
            changePassword.ClickMethods("account"); // Anasayfadaki "Hesabım" yazısına tıklar.
            changePassword.ClickMethods("changepassword"); // Açılan pencerede sol sekmedeki "Şifremi Değiştir yazısına tıklar."
            changePassword.FillChangePasswordForm(oldPassword, newPassword, newPassword); // Paroları doldurur.

            Console.WriteLine("Yeni parola: " + newPassword + "\nEski parola: " + oldPassword);
            // Yeni ve eski parolayı konsola yazar.
        }

        [TearDown] // TestCase başarı ile tamamlandı ise bu metota ulaşılıp tarayıcı kapatılır.
        public void CleanUp()
        {
            Properties.driver.Close(); // Tarayıcının kapanmasını sağlar.
            Console.WriteLine("Tarayıcı kapatıldı."); // Konsola yazdırır.
        }
    }
}