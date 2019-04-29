using ClassLibrary3.models;
using ClassLibrary3.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ClassLibrary3.StepDefinitons
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        //1ero crear instancias que permiten llamar a las paginas
        // Borrar todo lo que esta entre llaves luego de crear las intancias -> "ScenarioContext.Current.Pending();"

        SearchPage SearchPage = new SearchPage();
        SelectProductPage SelectProductPage = new SelectProductPage();
        ComparePage ComparePage = new ComparePage();

        //string nameFirstProduct = string.Empty, nameSecondProduct = string.Empty;
        Product FirstProduct = null, SecondProduct = null;

        [Given(@"El usuario ingresa a la url ""(.*)""")]
        public void GivenElUsuarioIngresaALaUrl(string url)
        {

            //3ero ingresar intancia de la primera pagina

            SearchPage.NavigateT(url);
        }

        [When(@"Usuario digita palabra ""(.*)"" en caja de texto superior")]
        public void WhenUsuarioDigitaPalabraEnCajaDeTextoSuperior(string texto)
        {
            SearchPage.imputSearchText(texto);
        }

        [When(@"click en Buscar")]
        public void WhenClickEnBuscar()
        {
            SearchPage.ClickOnSearckButton();
        }

        [When(@"sistema muestra pagina de resultados")]
        public void WhenSistemaMuestraPaginaDeResultados()
        {
            //5to no agregar metodo 
        }


        [When(@"validar que los resultados contengan la palabra ""(.*)""")]
        public void WhenValidarQueLosResultadosContenganLaPalabra(string Text_Compare)
        {

            //7mo Contains te devuelve un true o false si es que contiene lo que estas enviando como parametro  " Text Comapre " 
            // lUEGO AGREGAR ANTES DE "SelectProductPage.getResult().Contains(Text_Compare) ", agregar el "Assert.IsTrue()" que permite realizar la validacion , donde si sale false el sistem  a se caera 
            Assert.IsTrue(SelectProductPage.getResult().ToLower().Contains(Text_Compare.ToLower()));
        }


        [When(@"Cambiar tipo de vista")]
        public void WhenCambiarTipoDeVista()
        {
            SelectProductPage.ClickOnSearcView();
        }

        [When(@"click en el boton Add to Compare del primer vestido")]
        public void WhenClickEnElBotonAddToCompareDelPrimerVestido()
        {
            //nameFirstProduct = SelectProductPage.ClickOnProductCompare();
            FirstProduct = SelectProductPage.ClickOnProductCompare(0);
        }

        [When(@"click en el boton Add to compare del segundo vestido")]
        public void WhenClickEnElBotonAddToCompareDelSegundoVestido()
        {
            //nameSecondProduct = SelectProductPage.ClickOnSecondProductCompare();
            SecondProduct = SelectProductPage.ClickOnProductCompare(1);
        }

        [When(@"click en el boton Compare que se encuentra en la parte superiror derecha")]
        public void WhenClickEnElBotonCompareQueSeEncuentraEnLaParteSuperirorDerecha()
        {
            SelectProductPage.ClickOnButtonCompare();
        }

        [When(@"click en el boton add to cart")]
        public void WhenClickEnElBotonAddToCart()
        {
            ComparePage.ClickOnButtonAddToCart();
        }

        [When(@"click en el boton Continue shopping")]
        public void WhenClickEnElBotonContinueShopping()
        {
            ComparePage.ClickOnButtonContinueShopping();
        }

        [Then(@"validar que los valores de nombres y precios de los Drees sean iguales a los mostrados en la pagina anterior")]
        public void ThenValidarQueLosValoresDeNombresYPreciosDeLosDreesSeanIgualesALosMostradosEnLaPaginaAnterior()
        {
            Assert.IsTrue(ComparePage.ResultSelectProduct(FirstProduct, SecondProduct));
        }
    }
}
