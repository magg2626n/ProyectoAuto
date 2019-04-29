Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Chrome
Scenario: Comparar precios y nombres de vestidos seleccionados 
	Given El usuario ingresa a la url "http://automationpractice.com/index.php"
	When Usuario digita palabra "Dress" en caja de texto superior
	And click en Buscar
	And sistema muestra pagina de resultados 
	And validar que los resultados contengan la palabra "Dress"	
	And Cambiar tipo de vista 
	And click en el boton Add to Compare del primer vestido 
	And click en el boton Add to compare del segundo vestido  
	And click en el boton Compare que se encuentra en la parte superiror derecha 
	And click en el boton add to cart 
	And click en el boton Continue shopping 
	Then validar que los valores de nombres y precios de los Drees sean iguales a los mostrados en la pagina anterior 