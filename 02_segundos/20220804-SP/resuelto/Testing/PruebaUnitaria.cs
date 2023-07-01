using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaDeClases;
using System;

namespace Testing
{
    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        [ExpectedException(typeof(DatoErroneoException))]
        public void Insertar_IngresarDatosErroneos_LevantaLaExcepcionDatoErroneoException()
        {
            //arrange
            Empleado empleado = new Empleado(0, "", "Programador", true);
            SqlManejador manejador = new SqlManejador();

            //act
            manejador.Insertar(empleado);

            //assert
            //[ExpectedException(typeof(DatoErroneoException))]
        }


        [TestMethod]
        public void Insertar_IngresarCorrectamente_RetornaLaCantidadDeFilasIngresadas()
        {
            //arrange
            Empleado empleado = new Empleado(23456789, "Agustin", "Programador", true);
            SqlManejador manejador = new SqlManejador();

            //act
            int retorno = manejador.Insertar(empleado);

            //assert
            Assert.IsTrue(retorno > 0);
        }


        [TestMethod]
        public void GetEmpleadoGetUnPuesto_GenerarClasesCorrectamente_RetornanUnEmpleadoYUnPuesto()
        {
            //arrange
            Empleado empleado = GeneradorDeDatos.GetEmpleado;
            SqlManejador manejador = new SqlManejador();
            Puesto puesto = GeneradorDeDatos.GetUnPuesto;

            //act
            int retornoEmpleado = manejador.Insertar(empleado);

            //assert
            Assert.IsTrue(retornoEmpleado > 0);
            Assert.IsTrue(!String.IsNullOrEmpty(puesto.Posicion));
        }


    }
}
