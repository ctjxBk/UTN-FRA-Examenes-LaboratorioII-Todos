using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Collections.Generic;
using System.IO;

namespace Testing
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        public void Garantia_GarantiaDeUnTelevisorDe50Pulgadas_UnStringGarantiaDe48Meses()
        {
            //arrange
            Televisor tele = new Televisor("aa", "bb", 50, 1.0f);
            string garantiaEsperada = "Garantía de 48 meses";

            //act
            string garantiaObtenida = tele.Garantia;

            //asser
            Assert.AreEqual(garantiaEsperada, garantiaObtenida);
        }


        [TestMethod]
        public void SobreCargaListaProductosYProducto_IgualarListaDeProductosConUnProducto_RetornarTrue()
        {
            //arrange
            Televisor tele = new Televisor("aa", "bb", 50, 1.0f);
            List<Producto> productos = new List<Producto>();

            //act
            productos.Add(tele);

            //asser
            Assert.IsTrue(productos == tele);
        }

        [TestMethod]
        public void InfoDeLaLista_AgregarDosProductosAUnaListaDeProductos_RetornaLaSumaDeLosToStringDeCadaProducto()
        {
            //arrange
            Televisor tele = new Televisor("aa", "bb", 50, 1.0f);
            Celular celu = new Celular("cc",0.5f,"dd",2,false);
            List<Producto> productos = new List<Producto>();
            string informacionReal = productos.InfoDeLaLista();

            //act
            productos.Add(tele);
            productos.Add(celu);
            string informacionEsperada = $"{tele.ToString()}{Environment.NewLine}{celu.ToString()}{Environment.NewLine}";

            //asser
            Assert.AreEqual(informacionReal, informacionEsperada);
        }

    }
}
