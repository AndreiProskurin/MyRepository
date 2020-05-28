using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Browsers;

namespace Tests
{
    public class AlertsPage : Form
    {
        public AlertsPage() : base(By.XPath("//div[@class='example']/p[text()='Here are some examples of different JavaScript alerts which can be troublesome for automation']"), "AlertsPage")
        {
        }

        IButton alertButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[text()='Click for JS Alert']"), "JsAlert");
        IButton confirmButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[text()='Click for JS Confirm']"), "JsConfirm");
        IButton promtButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[text()='Click for JS Prompt']"), "JsPromt");
        ITextBox resultTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id("result"), "Result");

        public void AlertButtonClick()
        {
            alertButton.Click();
        }

        public void ConfirmButtonClick()
        {
            confirmButton.Click();
        }

        public void PromtButtonClick()
        {
            promtButton.Click();
        }

        public string GetResult()
        {
            return resultTextBox.Text;
        }
    }
}
