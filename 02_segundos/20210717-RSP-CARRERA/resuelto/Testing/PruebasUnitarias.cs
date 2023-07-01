using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Testing
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arange
            Carrera carrera = new Carrera(100);
            AutoF1 a1 = new AutoF1("Ferrari", 10, 1);
            AutoF1 a2 = new AutoF1("Renault", 12, 1);
            GestorDeArchivos gestorDeArchivos = new GestorDeArchivos("test-carreras.xml");
            Carrera carreraLeida = null;

            //act
            carrera += a1;
            carrera += a2;
            gestorDeArchivos.Guardar(carrera);
            carreraLeida = gestorDeArchivos.LeerXML();

            //assert
            Assert.AreEqual(carrera.Autos.Count, carreraLeida.Autos.Count);

            for(int i = 0; i < carrera.Autos.Count; i++)
            {
                Assert.AreEqual(carrera.Autos[i].Escuderia,carreraLeida.Autos[i].Escuderia);
                Assert.AreEqual(carrera.Autos[i].Posicion, carreraLeida.Autos[i].Posicion);
                Assert.AreEqual(carrera.Autos[i].Velocidad, carreraLeida.Autos[i].Velocidad);
                Assert.AreEqual(carrera.Autos[i].UbicacionEnPista, carreraLeida.Autos[i].UbicacionEnPista);
            }

            Assert.AreEqual(carrera.Kms, carreraLeida.Kms);
        }


        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void TestMethod2()
        {
            //arange
            GestorDeArchivos gestorDeArchivos = new GestorDeArchivos("test-carreras.json");

            Carrera carreraLeida = gestorDeArchivos.LeerXML();

            //assert
            //ExpectedException
        }
    }
}
