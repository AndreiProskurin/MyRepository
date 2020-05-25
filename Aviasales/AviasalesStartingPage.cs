using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Tests
{
    class AviasalesStartingPage : Form
    {
        public AviasalesStartingPage() : base(By.XPath("//div[@class='aviasales-app']//div[@class='page_header-form']//div[@class='avia-form__submit']//span[text()='Найти билеты']"), "AviasalesStartingPage")
        {
        }

        AviasalesSearchForm aviasalesSearchForm = new AviasalesSearchForm();

        public void ClickOnSubmit()
        {
            aviasalesSearchForm.ClickOnSubmit();
        }

        public void SetOrigin (string keys)
        {
            aviasalesSearchForm.SetOrigin(keys);
        }

        public void SetDestination(string keys)
        {
            aviasalesSearchForm.SetDestination(keys);
        }

        public void SetDepartureDate(string keys)
        {
            aviasalesSearchForm.SetDepartureDate(keys);
        }

        public void SetReturnDate(string keys)
        {
            aviasalesSearchForm.SetReturnDate(keys);
        }
    }
}
