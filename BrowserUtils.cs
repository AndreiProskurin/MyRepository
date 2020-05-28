using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Tests
{
    static class BrowserUtils
    {
        public static void MaximizeAndGoToUrl (Browser browser, string url)
        {
            browser.Maximize();
            try
            {
                browser.GoTo(url);
            }
            catch (WebDriverTimeoutException) { }
        }

        public static void AddCookies (Browser browser, params Cookie[] cookies)
        {
            foreach (Cookie cookie in cookies)
            {
                browser.Driver.Manage().Cookies.AddCookie(cookie);
            }
        }

        public static List<bool> CheckIfCookieExists (Browser browser, params Cookie[] cookies)
        {
            List<bool> results = new List<bool>();
            foreach (Cookie cookie in cookies)
            {
                bool result = browser.Driver.Manage().Cookies.AllCookies.Contains(cookie);
                results.Add(result);
                
            }
            return results;
        }
    }
}
