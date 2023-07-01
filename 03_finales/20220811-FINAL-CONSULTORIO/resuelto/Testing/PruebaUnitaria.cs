using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.Exceptions;
using Entidades.Files;
using Entidades.Models;

namespace Testing
{
    /*
    a. Forzar, mediante el código la ejecución de FileManagerException,
    validar que suceda de forma correcta.
    b.Al instanciar un nuevo consultorio, se espera que 
    el tiempo medio de atención sea igual a 0 (cero).
    */

    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        [ExpectedException(typeof(FileManagerException))] 
        public void Guardar_CuandoNoExisteUnaExtensionValida_LanzaLaExcepcionFileManagerException()
        {
            //arrange
            //act
            FileManager.Guardar<string>("hola mundo", "no-existe-formato.css.html.js");

            //Assert
            //[ExpectedException(typeof(FileManagerException))]
        }

        [TestMethod]
        
        public void TiempoMedioDeAtencion_CuandoNoSeAtiendeANingunPaciente_DeberiaSerCero()
        {
            //arrange
            //act
            Consultorio<Paciente> consultorio = new Consultorio<Paciente>("24 hs");
            double tiempoEsperado = 0;
            
            //Assert
            Assert.AreEqual(consultorio.TiempoMedioDeAtencion, tiempoEsperado);
        }
    }
}
