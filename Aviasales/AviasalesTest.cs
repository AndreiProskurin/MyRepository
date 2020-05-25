using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace Tests
{
    class AviasalesTest
    {
        Browser browser = AqualityServices.Browser;

        [SetUp]
        public void SetupBeforeTest()
        {
            BrowserUtils.MaximizeAndGoToUrl(browser, TestDataManager.GetConfigData("AviasalesUrl"));
        }

        [Test]
        public void AviasalesTestMethod()
        {
            AviasalesStartingPage aviasalesStartingPage = new AviasalesStartingPage();
            aviasalesStartingPage.SetOrigin(TestDataManager.GetConfigData("AviasalesOrigin"));
            aviasalesStartingPage.SetDestination(TestDataManager.GetConfigData("AviasalesDestination"));
            aviasalesStartingPage.SetDepartureDate(TestDataManager.GetConfigData("AviasalesDateOut"));
            aviasalesStartingPage.SetReturnDate(TestDataManager.GetConfigData("AviasalesDateBack"));
            aviasalesStartingPage.ClickOnSubmit();
            AviasalesResultPage aviasalesResultPage = new AviasalesResultPage();
            browser.Driver.SwitchTo().Window(browser.Driver.WindowHandles[1]);
            aviasalesResultPage.WaitForResults();

            Assert.IsFalse( aviasalesResultPage.CheckParameters(
                TestDataManager.GetConfigData("AviasalesOrigin"), 
                TestDataManager.GetConfigData("AviasalesDestination"),
                TestDataManager.GetConfigData("AviasalesDateOut"), 
                TestDataManager.GetConfigData("AviasalesDateBack")),"Search parameters are not correct");

            aviasalesResultPage.GoFoFastestRoutes();
        }
    }
}
