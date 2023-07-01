using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;

namespace Pruebas
{
    [TestClass]
    public class ExtensionPruebas
    {
        [TestMethod]
        public void CalcularSegundos_DeberiaRetornarLaDiferenciaEnSegundos()
        {
            //Arrange
            DateTime inicio = DateTime.Now;
            DateTime fin = inicio.AddSeconds(90);
            
            double valorEsperado = 90;

            //Act
            double resultado = inicio.CalcularSegundos(fin);


            //Assert
            Assert.AreEqual(resultado, valorEsperado);

            //DateTime inicio = new DateTime(2021, 11, 16, 12, 00, 00);
            //DateTime fin = new DateTime(2021, 11, 16, 12, 01, 30);
            //double valorEsperado = 90;

            //// Act
            //double resultado = inicio.CalcularSegundos(fin);

            //// Assert
            //Assert.AreEqual(valorEsperado, resultado);
        }
    }
}
