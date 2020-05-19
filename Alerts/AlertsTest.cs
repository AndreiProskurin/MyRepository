using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;

namespace Tests
{
    public class AlertsTest
    {
        Browser browser = AqualityServices.Browser;

        [Test]
        public void AlertsTestMethod()
        {
            BrowserUtils.MaximizeAndGoToUrl(browser, TestDataManager.GetConfigData("AlertsPageUrl"));
            var alertsPage = new AlertsPage();
            alertsPage.AlertButtonClick();

            Assert.AreEqual("I am a JS Alert", browser.Driver.SwitchTo().Alert().Text, "Incorrect alert executed");

            browser.HandleAlert(AlertAction.Accept);

            Assert.AreEqual("You successfuly clicked an alert", alertsPage.GetResult(), "Alert message is not correct");

            alertsPage.ConfirmButtonClick();

            Assert.AreEqual("I am a JS Confirm", browser.Driver.SwitchTo().Alert().Text, "Incorrect alert executed");

            browser.HandleAlert(AlertAction.Accept);

            Assert.AreEqual("You clicked: Ok", alertsPage.GetResult(), "Alert message is not correct");

            alertsPage.PromtButtonClick();

            Assert.AreEqual("I am a JS prompt", browser.Driver.SwitchTo().Alert().Text, "Incorrect alert executed");

            string randomString = Utils.GetRandomString(Int32.Parse(TestDataManager.GetConfigData("RandomStringLengthForAlerts")));
            browser.HandleAlert(AlertAction.Accept, randomString);

            Assert.AreEqual($"You entered: {randomString}", alertsPage.GetResult(), "Alert message is not correct");
        }
    }
}