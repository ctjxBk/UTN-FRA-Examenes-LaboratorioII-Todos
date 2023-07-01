using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.Exceptions;
using Entidades.Files;
using Entidades.Models;

namespace Testing
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        [ExpectedException(typeof(FileManagerException))]
        public void Guardar_CuandoSeGuardaUnaExtensionQueNoEstaRegistrada_LanzarUnaExcepcionFileManagerException()
        {
            //arange
            Ahorcado<Pais> ahorcado = new Ahorcado<Pais>();

            //act
            FileManager.Guardar<Ahorcado<Pais>>(ahorcado, "cualquier-extension.xml");

            //assert
            //exception...
        }

        [TestMethod]
        
        public void CantidadDeAciertos_CuandoSeInicilizaUnJuego_DeberiaSerCeroLaCantidadDeAciertos()
        {
            //arange
            Ahorcado<Pais> ahorcado = new Ahorcado<Pais>();

            //act
            int actual = ahorcado.CantidadDeAciertos;
            int expected = 0;

            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
