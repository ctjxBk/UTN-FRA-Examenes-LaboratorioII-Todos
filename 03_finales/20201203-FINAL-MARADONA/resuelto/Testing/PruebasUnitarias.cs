using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Testing
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionPersonalizada))]
        public void TestMethod1()
        {
            //arrange
            GestionarArchivosTextoPlano gestinarTxt = new GestionarArchivosTextoPlano();

            //act
            GestionarArchivosTextoPlano.Ruta += "imposible-que-existe-este-archvo.json.xml.txt.el-retutu-papa";
            gestinarTxt.Leer();

            //assert
            //ExpectedException

        }


        [TestMethod]
        
        public void TestMethod2()
        {
            //arrange
            PictureBox pic3 = new PictureBox();
            pic3.Name = "pic" + "3";

            string loQueEspero = "3";

            //act
            string loRecibido = pic3.UltimoCaracter();

            //assert
            Assert.AreEqual(loQueEspero,loRecibido);

        }
    }
}
