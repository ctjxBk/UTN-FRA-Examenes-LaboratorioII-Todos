using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaDeClases;
using System;
using System.Text;

namespace Testing
{
    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        [ExpectedException(typeof(DatoErroneoException))]
        public void TestMethod1()
        {
            //arrange
            EmpleadoFreelance empleadoFreelance = new EmpleadoFreelance(1, "", "programador", true);
            SqlManejador sqlManejador = new SqlManejador();
            //act
            sqlManejador.Insertar(empleadoFreelance);
            //assert
            //[ExpectedException(typeof(DatoErroneoException))]
        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            EmpleadoFreelance empleadoFreelance = new EmpleadoFreelance(25000000, "Agustin", "programador", true);
            SqlManejador sqlManejador = new SqlManejador();
            //act
            int cantidadInsertado = sqlManejador.Insertar(empleadoFreelance);
            //assert
            Assert.IsTrue(cantidadInsertado > 0);
        }


        [TestMethod]
        public void TestMethod3()
        {
            //arrange
            Empleado empleado = null;
            SqlManejador sqlManejador = new SqlManejador();
            Puesto puesto = null;
            
            //act
            while(empleado is not EmpleadoFreelance)
            {
                empleado = GeneradorDeDatos.GetEmpleadoAleatorio;
            }
            sqlManejador.Insertar((EmpleadoFreelance)empleado);
            puesto = GeneradorDeDatos.GetUnPuesto;


            //assert
            //Si llegue hasta acá y no tengo ninguna excepcion los datos son validos
            Assert.IsTrue(true);
        }
    }
}
