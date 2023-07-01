using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComiqueriaLogic;
using System;
using System.IO;

namespace Testing
{
    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        [ExpectedException(typeof(ComiqueriaException))]
        public void SerializarXML_CuandoSeSerializaUnPathInexistente_TiraUnaExcepcionDelTipoComiqueriaException()
        {
            //arrange
            Producto p = new Producto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = Path.Combine(ruta, "$%6//-456qweqasdq4ajklsdkjhqw55qweqwe74.txt.xml.json.html.el-retutu-papa");//imposible que esa ruta exista...

            //act
            Serializador<Producto>.SerializarXML(p, path);

            //assert
            //ExpectedException
        }
    }
}
