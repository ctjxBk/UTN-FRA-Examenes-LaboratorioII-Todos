using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.IO;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Serializadora s = new Serializadora();
            Payaso p = new Payaso("Agustin", DateTime.Now, "payaso.json");
            bool retorno;
            
            //Act
            retorno = s.IGuardar(p);
            
            //Assert
            //Assert.IsTrue(retorno);
            Assert.AreEqual(retorno,File.Exists(Payaso.rutaArchivo));
        }

        [TestMethod]
        [ExpectedException(typeof(DatosException))]
        public void TestMethod2()
        {
            //Arrange
            Serializadora s = new Serializadora();
            

            //Act
            bool retorno = s.IGuardar(null); 
        }


        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            DateTime fecha = new DateTime(2022,06,12);
            int cantidadDeDias = 10;
            
            //Act
            int diferenciaEndias = fecha.CalcularDiferenciaEnDias();
            

            //Assert
            Assert.AreEqual(cantidadDeDias, diferenciaEndias);
        }



    }
}
