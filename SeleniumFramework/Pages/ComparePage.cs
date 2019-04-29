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
    public class ComparePage: BasePage
    {
        private By txtProductNAme = By.ClassName("product-name");
        private By txtProductPrice = By.ClassName("price product-price");
        private By btnAddToCart = By.ClassName("ajax_add_to_cart_button");
        private By btnContinueShopping = By.ClassName("button lnk_view btn btn-default");

        internal bool ResultSelectProduct(Product firstProd, Product secondProd)
        {
            //Primero obtengo el segundo porque según la cola es el primero que fue agregado (first product)
            var firstProduct = GetProductWindowCompare(2);
            var secondProduct = GetProductWindowCompare(1);

            if (firstProduct.Description.Equals(firstProd.Description)
                && firstProduct.Price == firstProd.Price)
            {
                if (secondProduct.Description.Equals(secondProd.Description)
                && secondProduct.Price == secondProd.Price)
                {
                    return true;
                }
            }
            return false;
        }

        internal Product GetProductCompare(int position = 0)
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
                    var elementName = item.FindElement(txtProductNAme);
                    //var elementPrice = item.FindElement(txtProductPrice);
                    var elementPrice = item.FindElement(By.CssSelector(".right-block-content>.content_price>.price.product-price"));
                    product = new Product(elementName.Text, elementPrice.Text);
                    break;
                }
                c++;
            }

            return product;
        }

        internal void ClickOnButtonAddToCart()
        {
            //Primero, obtengo la tabla donde se muestran los productos a comparar
            var table = getElement(By.Id("product_comparison"));
            //Segundo, obtengo las filas (tr) de dicha tabla
            var rows = table.FindElements(By.TagName("tr"));
            
            //Tercero, recorro las filas (tr) de la tabla
            foreach (var row in rows)
            {
                //Cuarto, obtengo las columnas (td) de la primera fila
                var rowTds = row.FindElements(By.TagName("td"));

                //Obtengo el primer producto, está ubicado en la columna 1
                //------------------------------------------
                //La columna 0 solo muestra títulos
                var primerProducto = rowTds[1].FindElement(By.ClassName("button-container"));
                //De la columna 1, obtengo todos los elementos "a" (links) 
                var aLinks = primerProducto.FindElements(By.TagName("a"));
                //Para todos los casos, existen dos elementos "a" (links) 
                // el primero, es el botón "Add To Cart", el segundo es el botón "View"
                // por tal motivo, selecciono solo el primer botón "Add To Cart" dándole el índice 0
                aLinks[0].Click();

                /* SI NECESITAS AÑADIR EL OTRO PRODUCTO TAMBIEN, BORRA ESTA LINEA
                //Obtengo el segundo producto, está ubicado en la columna 1
                //------------------------------------------
                ClickOnButtonContinueShopping();
                //La columna 0 solo muestra títulos
                var segundoProducto = rowTds[2].FindElement(By.ClassName("button-container"));
                //De la columna 1, obtengo todos los elementos "a" (links) 
                aLinks = primerProducto.FindElements(By.TagName("a"));
                //Para todos los casos, existen dos elementos "a" (links) 
                // el primero, es el botón "Add To Cart", el segundo es el botón "View"
                // por tal motivo, selecciono solo el primer botón "Add To Cart" dándole el índice 0
                aLinks[0].Click();

                SI NECESITAS AÑADIR EL OTRO PRODUCTO TAMBIEn, BORRA ESTA LINEA */

                //Detengo el hilo por 3 segundos por si se tiene que esperar la respuesta del servidor
                Thread.Sleep(3000);
                
                //Como los botones se sitúan en la primera fila, no me interesan las demás y salgo del bucle
                break;
            }
        }

        private Product GetProductWindowCompare(int position = 0)
        {
            var product = new Product();
            var table = getElement(By.Id("product_comparison"));
            var rows = table.FindElements(By.TagName("tr"));
            int c = 0;
            foreach (var row in rows)
            {
                var rowTds = row.FindElements(By.TagName("td"));
                foreach (var td in rowTds)
                {
                    if (c == position && position > 0)
                    {
                        //Obtener la descripción del producto
                        var h5Title = td.FindElement(By.TagName("h5"));
                        var aTitle = h5Title.FindElement(By.TagName("a"));
                        product.Description = aTitle.Text;

                        //Obtener el precio del producto
                        var divPrice = td.FindElement(By.ClassName("prices-container"));
                        var spanPrice = divPrice.FindElement(By.TagName("span"));
                        product.Price = spanPrice.Text;

                        break;
                    }
                    c++;
                }
                break;
            }

            return product;
        }

        internal void ClickOnButtonContinueShopping()
        {
            var div = getElement(By.ClassName("button-container"));
            var span = div.FindElement(By.TagName("span"));
            span.Click();
            //ClickOn(btnContinueShopping);
        }
    }
}
