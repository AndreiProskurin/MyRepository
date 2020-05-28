using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests
{
    public class BasicAuthenticationTest
    {
        Browser browser = AqualityServices.Browser;

        [Test]
        public void BasicAuthenticationTestMethod()
        {
            BrowserUtils.MaximizeAndGoToUrl(browser, $"https://{TestDataManager.GetConfigData("Login")}:{TestDataManager.GetConfigData("Password")}@{TestDataManager.GetConfigData("BasicAuthorizationUrl")}");
            var resultText = AqualityServices.Get<IElementFactory>().GetTextBox(By.CssSelector("pre"), "resultText").GetText();

            Assert.AreEqual(TestDataManager.GetConfigData("ExpectedResult"), resultText, "Expected text is not equal");
        }
    }
}