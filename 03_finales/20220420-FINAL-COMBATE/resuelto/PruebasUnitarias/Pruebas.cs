using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;

namespace PruebasUnitarias
{
    [TestClass]
    public class Pruebas
    {
        [TestMethod]
        [ExpectedException (typeof(BusinessException))]
        public void TestMethod1()
        {
            //Arrange
            Guerrero guerrero = new Guerrero(1,"hola",1000);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            Personaje guerrero = new Guerrero(1, "testG", 10);

            //Act
            guerrero.RecibirAtaque(10000);
            int vida = 0;

            //Assert
            Assert.AreEqual(vida, guerrero.PuntosDeVida);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            Personaje guerrero = new Guerrero(1, "testG", 10);

            //Act
            int defensa = 100;


            //Assert
            Assert.AreEqual(defensa, guerrero.PuntosDeDefensa);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            Hechizero hechizero = new Hechizero(2, "testH", 11);

            //Act
            int defensa = 100;


            //Assert
            Assert.AreEqual(defensa, hechizero.PuntosDeDefensa);
        }

    }
}
