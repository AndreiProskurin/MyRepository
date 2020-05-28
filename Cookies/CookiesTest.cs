using Aquality.Selenium.Browsers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Tests
{
    public class CookiesTest
    {
        Browser browser = AqualityServices.Browser;

        [Test]
        public void CookiesTestMethod()
        {
            BrowserUtils.MaximizeAndGoToUrl(browser, TestDataManager.GetConfigData("CookiesUrl"));
            var Cookies = browser.Driver.Manage().Cookies;
            Cookie[] cookies = new Cookie[]
            {
                new Cookie(TestDataManager.GetConfigData("Cookie1Name"), TestDataManager.GetConfigData("Cookie1Value")),
                new Cookie(TestDataManager.GetConfigData("Cookie2Name"), TestDataManager.GetConfigData("Cookie2Value")),
                new Cookie(TestDataManager.GetConfigData("Cookie3Name"), TestDataManager.GetConfigData("Cookie3Value"))
            };
            BrowserUtils.AddCookies(browser, cookies);

            Assert.IsFalse(BrowserUtils.CheckIfCookieExists(browser, cookies).Contains(false), "Not all cookies added");

            Cookies.DeleteCookieNamed(TestDataManager.GetConfigData("Cookie1Name"));

            Assert.IsNull(Cookies.GetCookieNamed(TestDataManager.GetConfigData("Cookie1Name")), "Chosen cookie is not deleted");

            BrowserUtils.AddCookies(browser, new Cookie(TestDataManager.GetConfigData("Cookie3Name"), TestDataManager.GetConfigData("Cookie3NewValue")));

            Assert.AreEqual(TestDataManager.GetConfigData("Cookie3NewValue"), Cookies.GetCookieNamed(TestDataManager.GetConfigData("Cookie3Name")).Value, "Cookie value is not correct");

            Cookies.DeleteAllCookies();

            Assert.AreEqual(Int32.Parse(TestDataManager.GetConfigData("FinalAmmountOfCookies")), Cookies.AllCookies.Count, "Page should not contain any cookie");
        }
    }
}