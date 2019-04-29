using ClassLibrary3.models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary3.Pages
{
    public class SelectProductPage : BasePage
    {
        private By txtresult = By.ClassName("right-block");
        private By txtbuttonView = By.Id("list");
        private By txtButtonProduct = By.ClassName("add_to_compare");
        private By txtButtonCompareProduct = By.ClassName("compare-form");
        private By txtProductNAme = By.ClassName("product-name");
        private By txtProductPrice = By.ClassName("price product-price");

        internal string getResult()
        {
            return GetElementText(txtresult);
        }

        internal void ClickOnSearcView()
        {
            ClickOn(txtbuttonView);
        }

        internal Product ClickOnProductCompare(int position = 0)
        {
            Product product = null;
            string name = string.Empty;
            //ClickOn(txtButtonFirstProduct);
            var elemns = getElementsByCss(".product-container");
            int c = 0;
            foreach (var item in elemns)
            {
                if (c == position)
                {
                    //name = item.GetAttribute("href");
                    var elementAddToCompare = item.FindElement(txtButtonProduct);
                    var elementName = item.FindElement(txtProductNAme);
                    //var elementPrice = item.FindElement(txtProductPrice);
                    var elementPrice = item.FindElement(By.CssSelector(".right-block-content>.content_price>.price.product-price"));
                    product = new Product(elementName.Text, elementPrice.Text);
                    elementAddToCompare.Click();
                    Thread.Sleep(3000);
                    break;
                }
                c++;
            }

            return product;
        }

        internal void ClickOnButtonCompare()
        {
            SubmitForm(txtButtonCompareProduct);
        }
    }
}
