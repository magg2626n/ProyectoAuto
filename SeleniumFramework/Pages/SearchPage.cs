using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3.Pages
{
    public class SearchPage : BasePage
    {
        #region Base Page Configuration
        RemoteWebDriver _webDriver;
        public SearchPage()
        {
            _webDriver = base.webDriver;
        }
        #endregion

        By TXT_BuscarTexto = By.Id("search_query_top");
        By ButtonBuscar = By.Name("submit_search");

        internal void NavigateT(string url)
        {
            Navigate(url);
        }

        internal void imputSearchText(string texto)
        {
            SendKeysOn(TXT_BuscarTexto, texto);
        }

        internal void ClickOnSearckButton()
        {
            ClickOn(ButtonBuscar);
        }
    }
}
