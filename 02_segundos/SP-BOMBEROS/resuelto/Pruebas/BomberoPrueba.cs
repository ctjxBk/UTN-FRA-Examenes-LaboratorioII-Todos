using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;

namespace Pruebas
{
    [TestClass]
    public class BomberoPrueba
    {
        [TestMethod]
        public void Leer_DeberiaRetornarElBomberoSerializado()
        {
            //Arrange
            Bombero bombero = new Bombero("Prueba");

            //Act
            bombero.Guardar(bombero);

            //Assert
            Bombero bomberoDeserializado = bombero.Leer();
            Assert.AreEqual(bombero.Nombre, bomberoDeserializado.Nombre);
        }
    }
}
