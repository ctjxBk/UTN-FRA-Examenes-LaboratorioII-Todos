using BibliotecaDeClases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectoTestUnitarios
{
    [TestClass]
    public class ClaseTesteo
    {
        [TestMethod]
        [ExpectedException(typeof(DatosNoValidosException))]
        public void TestMethod_1()
        {
            //arrange
            SqlManejador sqlManejador = new SqlManejador();
            Alumno alumno = new Alumno(1, "a", -1, -1);

            //act
            sqlManejador.Insertar(alumno);

            //assert
            //ExpectedException
        }

        [TestMethod]
        public void TestMethod_2()
        {
            //arrange
            SqlManejador sqlManejador = new SqlManejador();
            Alumno alumno = new Alumno(12345678, "Batman", 10, 10);
            int valorEsperado = 1;

            //act
            int valorObtenido = sqlManejador.Insertar(alumno);

            //assert
            Assert.AreEqual(valorEsperado, valorObtenido);
        }


        [TestMethod]
        public void TestMethod_3()
        {
            //arrange
            Alumno alumno = GeneradorDeDatos.GetUnAlumno;
            int retornoEsperadoAlumno = 1;

            //act
            //dentro del sqlManajador.Insertar estan las validaciones de un Alumno,
            //caso contrario deberia levantar una excepcion
            SqlManejador sqlManejador = new SqlManejador();
            int retornoObtenidoAlumno = sqlManejador.Insertar(alumno);


            //assert
            Assert.AreEqual(retornoObtenidoAlumno, retornoEsperadoAlumno);
        }

    }
}
