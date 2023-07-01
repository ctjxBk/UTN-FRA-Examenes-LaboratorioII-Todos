using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Entidades;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException (typeof(SinClientesException))]
        public void TestMethod1()
        {
            Comercio comercio = new Comercio();

            comercio.LlamarCliente();
        }

        [TestMethod]
        
        public void TestMethod2()
        {
            Comercio comercio = new Comercio();
            Cliente cliente = new Cliente("Agustin");
            bool loAgrego = comercio + cliente;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comercio.xml");
            
            comercio.SaveBackup(path);
            Comercio comercioLectura = new Comercio();
            comercioLectura.LoadBackup(path);

            Assert.AreEqual(comercio.Clientes[0].Nombre,comercioLectura.Clientes[0].Nombre);
        }

        [TestMethod]

        public void TestMethod3()
        {
            Comercio comercio = new Comercio();
            Cliente cliente = new Cliente("Agustin");
            bool loAgrego = comercio + cliente;

            bool loAgregoVerificacion = comercio.Clientes.Count == 1 ? true : false;

            Assert.AreEqual(loAgrego,loAgregoVerificacion);
        }

    }
}
