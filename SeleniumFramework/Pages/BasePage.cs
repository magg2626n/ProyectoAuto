using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ClassLibrary3.Pages
{
    public class BasePage
    {
        public RemoteWebDriver webDriver;
        public string baseUrl;

        public BasePage()
        {
            webDriver = (RemoteWebDriver)ScenarioContext.Current["webDriver"];
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public string GetElementText(By element)
        {
            string title = webDriver.FindElement(element).Text;
            return title;
        }

        public IReadOnlyCollection<IWebElement> getElementsByCss(string cssSel)
        {
            return webDriver.FindElementsByCssSelector(cssSel);
        }

        public IWebElement getElementById(string id)
        {
            return webDriver.FindElementById(id);
        }

        public IWebElement getElement(By element)
        {
            return webDriver.FindElement(element);
        }

        public IReadOnlyCollection<IWebElement> getElements(By element)
        {
            return webDriver.FindElements(element);
        }

        public void waitForLocator(By locator)
        {

        }

        public void SubmitForm(By locator)
        {
            webDriver.FindElement(locator).Submit();
        }

        public void selectComboboxText(By locator, String location)
        {
            webDriver.FindElement(locator).Click();
            new Actions(webDriver).SendKeys(location).Perform();
            new Actions(webDriver).SendKeys(Keys.Enter).Perform();
            //webDriver.FindElement(SearchLocator).SendKeys(location);
            //webDriver.FindElement(locatorResult).Click();

        }

        public void Navigate(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            baseUrl = url;
        }

        public void ClickOn(By locator)
        {
            webDriver.FindElement(locator).Click();
        }

        public void SendKeysOn(By locator, String text)
        {
            webDriver.FindElement(locator).SendKeys(text);
        }

        public string GetTitle()
        {
            string title = webDriver.Title;
            return title;
        }

        public void CompareElementToString(By element, string text)
        {
            string elementText = GetElementText(element);
            Assert.AreEqual(elementText, text);
        }

        public void ComparePageTitleToString(string title, string text)
        {
            Assert.AreEqual(title, text);
        }
    }
}
