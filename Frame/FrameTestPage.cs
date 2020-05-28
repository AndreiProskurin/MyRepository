using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Tests
{
    class FrameTestPage : Form
    {
        public FrameTestPage() : base(By.XPath("//div[@id='content']/div[@class='example']/h3"), "FrameTestPage")
        {
        }

        ITextBox titleText = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//div[@id='content']/div[@class='example']/h3"), "TitleText");
        IButton boldButton = AqualityServices.Get<IElementFactory>().GetButton(By.Id("mceu_3"), "BoldButton");

        public string GetTitleText()
        {
            return titleText.GetText();
        }

        IWebElement SwitchToFrameTextBox(Browser browser)
        {
            return browser.Driver.SwitchTo().Frame("mce_0_ifr").FindElement(By.TagName("p"));
        }

        public void ClearFrameTextBox (Browser browser)
        {
            SwitchToFrameTextBox(browser).Clear();
            browser.Driver.SwitchTo().DefaultContent();
        }

        public void SendKeysInFrameTextBox (Browser browser, string keys)
        {
            SwitchToFrameTextBox(browser).SendKeys(keys);
            browser.Driver.SwitchTo().DefaultContent();
        }

        public string GetTextFromFrameTextBox (Browser browser)
        {
            string text = SwitchToFrameTextBox(browser).Text;
            browser.Driver.SwitchTo().DefaultContent();
            return text;
        }

        public bool CheckIfTextInFrameStrong(Browser browser, string text)
        {
            return browser.Driver.SwitchTo().Frame("mce_0_ifr").FindElement(By.XPath("//p/strong")).Text.Equals(text);
        }

        public void ClickOnBoldButton()
        {
            boldButton.Click();
        }
    }
}
