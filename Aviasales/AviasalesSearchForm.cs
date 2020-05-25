using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests
{
    public class AviasalesSearchForm : Form
    {
        public AviasalesSearchForm() : base(By.XPath("//form[@class='avia-form']"), "AviasalesSearchForm")
        {
        }

        ITextBox origin = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id("origin"), "Origin");
        ITextBox destination = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id("destination"), "Destination");
        IButton departureDate = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//div[@class='trip-duration__input-wrapper --departure']"), "DepartureDate");
        IButton returnDate = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//div[@class='trip-duration__input-wrapper --return']"), "ReturnDate");
        IButton submitButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@type='submit']"), "Origin");

        public void ClickOnSubmit()
        {
            submitButton.Click();
        }

        public void SetOrigin(string keys)
        {
            origin.ClickAndWait();
            origin.SendKeys(keys);
        }

        public void SetDestination(string keys)
        {
            destination.ClickAndWait();
            destination.SendKeys(keys);
        }

        public void SetDepartureDate(string keys)
        {
            departureDate.ClickAndWait();
            SelectElement departureDateSelect = new SelectElement(AqualityServices.Browser.Driver.FindElement(By.ClassName("calendar-caption__select")));
            DateTime departureDatetime = DateTime.ParseExact(keys, "dd/MM/yyyy", null);
            departureDateSelect.SelectByValue(departureDatetime.ToString("yyyy-MM"));
            ITextBox dayDate = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath($"//div[@class='calendar-day']/div[text()='{departureDatetime.Day}']"), "DayDate");
            dayDate.Click();
        }

        public void SetReturnDate(string keys)
        {
            returnDate.ClickAndWait();
            SelectElement departureDateSelect = new SelectElement(AqualityServices.Browser.Driver.FindElement(By.ClassName("calendar-caption__select")));
            DateTime departureDatetime = DateTime.ParseExact(keys, "dd/MM/yyyy", null);
            departureDateSelect.SelectByValue(departureDatetime.ToString("yyyy-MM"));
            ITextBox dayDate = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath($"//div[@class='calendar-day']/div[text()='{departureDatetime.Day}']"), "DayDate");
            dayDate.Click();
        }
    }
}
