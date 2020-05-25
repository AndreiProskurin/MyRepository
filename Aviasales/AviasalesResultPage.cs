using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Tests
{
    class AviasalesResultPage : Form
    {
        public AviasalesResultPage() : base(By.XPath("//div[@class='aviasales-app__explosion-wrap']//div[@class='prediction-advice']"), "AviasalesResultPage")
        {
        }

        ITextBox originFilter = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//span[@class='filter__route-origin']"), "OriginFilter");
        ITextBox destinationFilter = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//span[@class='filter__route-destination']"), "DestinationFilter");
        ITextBox dateFilter = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//div[@class='minimized-calendar-matrix__item is-current']//div[@class='calendar-matrix-dates']"),"Dates");
        ITextBox fastestRoutesLabel = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//span[@class='sorting__title-wrap' and text()='Самый быстрый']"), "FastestRoutesLabel");
        ITextBox flightDurationFilter = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//div[@class='filters__item filter --flight-duration']"), "FlightDurationFilter");
        AviasalesSearchForm aviasalesSearchForm = new AviasalesSearchForm();

        public void WaitForResults()
        {
            WebDriverWait wait = new WebDriverWait(AqualityServices.Browser.Driver, TimeSpan.FromSeconds(25));
            wait.PollingInterval = TimeSpan.FromMilliseconds(150);
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='loader__stripes --animation-finished --blue']")));
        }

        public bool CheckParameters(string origin, string destination, string outDate, string comebackDate)
        {
            List<bool> results = new List<bool>();
            results.Add(originFilter.Text.Equals(origin));
            results.Add(destinationFilter.Text.Equals(destination));
            results.Add(dateFilter.Text.Contains(DateTime.ParseExact(TestDataManager.GetConfigData("AviasalesDateOut"), "dd/MM/yyyy", null).ToString("dd MMM")));
            results.Add(dateFilter.Text.Contains(DateTime.ParseExact(TestDataManager.GetConfigData("AviasalesDateBack"), "dd/MM/yyyy", null).ToString("dd MMM")));
            return results.Contains(false);
        }

        public void GoFoFastestRoutes()
        {
            fastestRoutesLabel.ClickAndWait();
            flightDurationFilter.ClickAndWait();
            List<string> fastestDurationsList = new List<string>();
            IList<ITextBox> fastestFlightsDurations = AqualityServices.Get<IElementFactory>().FindElements<ITextBox>(
                By.XPath("//div[@class='filters__item filter --flight-duration is-opened']//div[@class='slider-range__label --min']"));
            foreach (ITextBox textBox in fastestFlightsDurations)
            {
                fastestDurationsList.Add(textBox.Text.Substring(3).TrimStart('0').TrimStart('0').TrimStart('ч'));
            }
            ITextBox fastestFlightFromOrigin = AqualityServices.Get<IElementFactory>().GetTextBox(
                By.XPath($"//div[@class='segment-route__duration' and contains(text(),'{fastestDurationsList[0]}')]/parent::div/preceding-sibling::div/div[@class='segment-route__city']/preceding-sibling::div[@class='segment-route__time']"), "FastestFlightFromOrigin");
            ITextBox fastestFlightToOrigin = AqualityServices.Get<IElementFactory>().GetTextBox(
                By.XPath($"//div[@class='segment-route__duration' and contains(text(),'{fastestDurationsList[1]}')]/parent::div/preceding-sibling::div/div[@class='segment-route__city']/preceding-sibling::div[@class='segment-route__time']"), "FastestFlightToOrigin");
            // Receiving time of the shortest flights.
            string outTimeOfLeaving = fastestFlightFromOrigin.Text;
            string backTimeOfLeaving = fastestFlightToOrigin.Text;
        }
    }
}
