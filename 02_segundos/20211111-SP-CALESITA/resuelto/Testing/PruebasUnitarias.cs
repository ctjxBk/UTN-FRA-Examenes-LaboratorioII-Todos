using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.IO;

namespace Testing
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Intentar guardar y leer un archivo correctamente, comprobando que los datos guardados sean
            //iguales a los recuperados

            //Arrange
            Juego juego = new Juego(180, new object());
            Juego juegoRecuparado = null;
            JsonFiler<Juego> json = new JsonFiler<Juego>();

            //Act
            json.Guardar("test.json",juego);
            json.Leer("test.json", out juegoRecuparado);


            //Assert
            Assert.AreEqual(juego.Ubicacion == juegoRecuparado.Ubicacion, juego.Velocidad == juegoRecuparado.Velocidad);
        }

        [TestMethod]
        [ExpectedException(typeof(ErrorArchivosException))]
        public void TestMethod2()
        {
            //Intentar guardar un archivo en una ruta inválida(una ruta vacía o con caracteres inválidos servirá
            //para dicho plan), comprobando que se lance la excepción ErrorArchivosException.

            //Arrange
            Juego juego = new Juego(180, new object());
            
            JsonFiler<Juego> json = new JsonFiler<Juego>();

            //Act
            //nombre bien fue para que tire error
            json.Guardar("test'&%~\\#.-/$@.json", juego);


            //Assert
            //ExpectedException
        }


        [TestMethod]
        
        public void TestMethod3()
        {
            //Para obtener la sortija y ganarte otra vuelta: Hacer un test más, original, probando alguna
            //funcionalidad compleja del sistema.

            //Arrange
            JsonFiler<Juego> json = new JsonFiler<Juego>();
            string archivo = "test-para-obtener-la-sortija-y-ganarme-otra-vuelta.txt";
            string path = json.GenerarRutacompleta + archivo;

            //Act
            FileStream fs = File.Create(path);
            fs.Close();
            bool existe = json.ExisteArchivo(archivo);
            File.Delete(path);
            
            //Assert
            Assert.IsTrue(existe);
        }
    }
}
