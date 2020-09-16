using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject
{
    class LoginPageObject
    {

        // Constructor

        [Obsolete]
        public LoginPageObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        // Constructor
        // // // // //
        // Element tanımlama

        [FindsBy(How = How.ClassName, Using = "btnSignIn")]
        public IWebElement SignInButton { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "rememberMe")]
        public IWebElement RememberMe { get; set; }

        [FindsBy(How = How.Id, Using = "loginButton")]
        public IWebElement LogInButton { get; set; }

        // Element tanımlama
        // // // // //
        // Metot tanımlama

        [Obsolete]
        public HomePageObject FillLoginForm(string email, string password)
        {
            SignInButton.Click(); // Anasayfadaki giriş yap butonuna tıklar.
            EmailInput.SendKeys(email); // Kullanıcı girişi formunda email'i doldurur.
            PasswordInput.SendKeys(password); // Kullanıcı girişi formunda parolayı doldurur.
            RememberMe.Click(); // Kullanıcının daha sonradan hatırlanması için beni hatırla butonuna tıklar.
            LogInButton.Click(); // Siteye üye girişi yapılması için giriş yap butonuna tıklar.

            return new HomePageObject(); // Kullanıcıyı anasayfaya geri döndürür.
        }

        // Metot tanımlama
    }
}
