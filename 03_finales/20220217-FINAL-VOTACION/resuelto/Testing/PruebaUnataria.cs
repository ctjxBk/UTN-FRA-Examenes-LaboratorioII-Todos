using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLibraries;
using System;
using System.IO;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            //string ruta = AppDomain.CurrentDomain.BaseDirectory;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = Path.Combine(ruta, "votacion.json");
            
            
            //acta
            Parlamento<Senador> parlamento = JsonManager<Parlamento<Senador>>.Leer(path);

            //assert
            Assert.AreEqual(parlamento.VotosAfirmativos,12);
            Assert.AreEqual(parlamento.VotosNegativos,10);
            Assert.AreEqual(parlamento.VotosAbstenciones,13);
        }

        [TestMethod]
        [ExpectedException(typeof(NoNecesitaDesempateException))]
        public void TestMethod2()
        {
            //arrange
            //string ruta = AppDomain.CurrentDomain.BaseDirectory;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = Path.Combine(ruta, "votacion.json");

            //act
            Parlamento<Senador> parlamento = JsonManager<Parlamento<Senador>>.Leer(path);
            parlamento.VotosAfirmativos = 12;
            parlamento.VotosNegativos = 10;

            parlamento.DesempatePresidente();

            //assert
            //[ExpectedException(typeof(NoNecesitaDesempateException))]
        }

        [TestMethod]
        public void TestMethod3()
        {
            //arrange
            Senador presidente = new Senador("presidente", null);
            Senador senador1 = new Senador("1", null);
            Senador senador2 = new Senador("2", null);
            Parlamento<Senador> parlamento = new Parlamento<Senador>(presidente);
            parlamento.Bancas = new List<Senador>() { senador1, senador2 };

            //act
            parlamento.VotosAfirmativos = 1;
            parlamento.VotosNegativos = 1;

            parlamento.DesempatePresidente();

            //assert
            //si llega hasta acá significa que el presidente emitio su voto y no fue necesario
            //lanzar la excepcion NoNecesitaDesempateException
            Assert.IsTrue(true);
        }
    }
}
