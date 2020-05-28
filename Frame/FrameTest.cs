using Aquality.Selenium.Browsers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Tests
{
    public class FrameTestProject
    {
        Browser browser = AqualityServices.Browser;

        [Test]
        public void FrameTestMethod()
        {
            BrowserUtils.MaximizeAndGoToUrl(browser, TestDataManager.GetConfigData("FrameTestPageUrl"));
            FrameTestPage frameTestPage = new FrameTestPage();

            Assert.AreEqual("An iFrame containing the TinyMCE WYSIWYG Editor", frameTestPage.GetTitleText(), "Required text is not found");

            frameTestPage.ClearFrameTextBox(browser);
            string randomString = Utils.GetRandomString(Int32.Parse(TestDataManager.GetConfigData("RandomStringLengthForFrame")));
            frameTestPage.SendKeysInFrameTextBox(browser, randomString);

            Assert.AreEqual(randomString, frameTestPage.GetTextFromFrameTextBox(browser), "Displayed text is incorrect");

            frameTestPage.SendKeysInFrameTextBox(browser, Keys.Control + "a");
            frameTestPage.ClickOnBoldButton();

            Assert.IsTrue(frameTestPage.CheckIfTextInFrameStrong(browser,randomString), "Chosen text is not bold");
        }
    }
}