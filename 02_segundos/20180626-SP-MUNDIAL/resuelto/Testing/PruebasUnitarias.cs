using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using Excepciones;
using System.IO;

namespace Testing
{
    [TestClass]
    public class PruebasUnitarias
    {
        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void TestMethod1()
        {   
            //arrange
            Grupo grupo = new Grupo(Letras.A, 4);

            //act
            grupo.Guardar();

            //assert
            //ExpectedException
        }

        
        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            Grupo grupo = new Grupo(Letras.A, 4);
            Torneo torneo = new Torneo("Rusia 2018");

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = Path.Combine(ruta, $"grupo-{grupo.GrupoLetra}.xml");

            //act
            torneo.Grupos.Add(grupo);
            torneo.Guardar();

            //assert
            Assert.IsTrue(File.Exists(path));
            
        }

        [TestMethod]
        [ExpectedException(typeof(GrupoLlenoException))]
        public void TestMethod3()
        {
            //arrange
            Grupo grupo = new Grupo(Letras.A, 0);
            Equipo equipo = new Equipo(1, "Argentina");

            //act
            grupo = grupo + equipo;

            //assert
            //ExpectedException

        }
    }
}
