using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace Testing
{
    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        public void ConstructoresPaciente()
        {
            //arrange
            Paciente p1 = new Paciente("Nombre", "Apellido");
            Paciente p2 = new Paciente("Nombre", "Apellido", 5);
            Paciente p3 = new Paciente("Nombre", "Apellido");
            int valorEsperadoUltimoTurno = 6;

            //act
            int ultimoTurno = p3.Turno;

            //assert
            Assert.AreEqual(ultimoTurno, valorEsperadoUltimoTurno);
        }
    }
}
