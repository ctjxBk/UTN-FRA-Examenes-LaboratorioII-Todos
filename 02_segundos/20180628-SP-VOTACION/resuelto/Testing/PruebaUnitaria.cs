using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.IO;
using Excepciones;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        [ExpectedException(typeof(ErrorArchivoException))]
        public void TestMethod1()
        {
            //arrange
            Votacion votacion = new Votacion();
            SerializarXML<Votacion> serializarXML = new SerializarXML<Votacion>();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = Path.Combine(ruta, "votacion-20180628-SP!·$$%&/(()///).xml");

            //act
            serializarXML.Guardar(path, votacion);

            //assert
            //ExpectedException
        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            Dictionary<string, Votacion.EVoto> participantes = new Dictionary<string, Votacion.EVoto>();
            participantes.Add("1", Votacion.EVoto.Afirmativo);
            participantes.Add("2", Votacion.EVoto.Negativo);
            Votacion votacion = new Votacion("ley",participantes);

            //act
            votacion.EventoVotoEfectuado += votacion.VerificarEventos;
            votacion.Simular();

            //assert
            Assert.AreEqual(votacion.CantidadDeEventos, participantes.Count);
            //ExpectedException
        }
    }
}
