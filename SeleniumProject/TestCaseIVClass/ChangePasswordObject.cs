using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject
{
    class ChangePasswordObject
    {

        // Constructor

        [Obsolete]
        public ChangePasswordObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        // Constructor
        // // // // //
        // Element tanımlama

        [FindsBy(How = How.CssSelector, Using = "a[title=\"Hesabım\"]")]
        public IWebElement GoAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div/div[2]/div[1]/div[1]/div[2]/ul/li[10]/a")]
        public IWebElement ClickCP { get; set; }

        [FindsBy(How = How.Id, Using = "oldPassword")]
        public IWebElement OldPassword { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement NewPassword { get; set; }

        [FindsBy(How = How.Id, Using = "passwordRetype")]
        public IWebElement RetypeNewPassword { get; set; }

        [FindsBy(How = How.Id, Using = "changePasswordButton")]
        public IWebElement ChangeButton { get; set; }

        // Element tanımlama
        // // // // //
        // Metot tanımlama

        public void ClickMethods(string value)
        {
            if (value == "account")
                GoAccount.Click();

            if (value == "changepassword")
            {
                Properties.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Sayfa açıldıktan sonra tüm elementlerin yüklenmesi için 10 sn'ye kadar bekler.
                IJavaScriptExecutor js = Properties.driver as IJavaScriptExecutor;
                js.ExecuteScript("window.scrollBy(0,150)"); // Sayfa "Şifre Değiştir" elemanının görünür olması için aşağı iner.
                ClickCP.Click(); // "Şifre Değiştir" elemanına tıklar.
            }
        }

        public void FillChangePasswordForm(string oldPassword, string newPassword, string retypeNewPassword)
        {
            OldPassword.SendKeys(oldPassword); // Eski parolayı doldurur.
            NewPassword.SendKeys(newPassword); // Yeni parolayı doldurur.
            RetypeNewPassword.SendKeys(retypeNewPassword); // Yeni parolayı tekrar doldurur.
            ChangeButton.Click(); // "Şifre Değiştir" butonuna tıklar.
        }

        // Metot tanımlama
    }
}