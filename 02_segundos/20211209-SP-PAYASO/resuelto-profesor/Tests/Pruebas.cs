using Entidades;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Tests
{
    [TestClass]
    public class Pruebas
    {
        [TestMethod]
        public void Serializadora_Guardar()
        {
            //Arrange
            Serializadora serializadora = new Serializadora();
            Payaso payaso = new Payaso("Pennywise",DateTime.Now, "prueba.json");

            //Act
            serializadora.Guardar(payaso);

            //Assert
            Assert.IsTrue(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/prueba.json "));
        }

        [TestMethod]
        public void Extensora_CalcularDiferenciaEnDias()
        {
            // Arrange
            DateTime fecha = new DateTime(2021, 12, 1);
            double valorEsperado = 7;

            // Act
            int resultado = fecha.CalcularDiferenciaEnDias();

            // Assert
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(DatosException))]
        public void DatosException_Excepcion()
        {
            //Arrange
            Serializadora serializadora = new Serializadora();

            //Act
            serializadora.Guardar(null);
        }
    }
}
