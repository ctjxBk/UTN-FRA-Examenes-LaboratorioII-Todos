using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            Covid19 enfermedad = new("Covid-19");

            //act
            long indiceDeContagiosReales = enfermedad.IndiceDeContagios;
            long indiceDeContagiosEsperados = 5;

            //assert
            Assert.AreEqual(indiceDeContagiosReales, indiceDeContagiosEsperados);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            Gripe enfermedad = new Gripe("Gripe",Microorganismo.ETipo.Virus,Microorganismo.EContagiosidad.Moderada);

            //act
            long indiceDeContagiosReales = enfermedad.IndiceDeContagios;
            long indiceDeContagiosEsperados = 2;

            //assert
            Assert.AreEqual(indiceDeContagiosReales, indiceDeContagiosEsperados);
        }
    }
}
