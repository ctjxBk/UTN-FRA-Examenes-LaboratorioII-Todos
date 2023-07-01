using BibliotecaDeClases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectoTestUnitarios
{
    [TestClass]
    public class ClaseTesteo
    {
        [ExpectedException(typeof(DatosNoValidosException))]
        [TestMethod]
        public void Test_DatosNoValidosException()
        {
            SqlManejador sql = new SqlManejador();

            sql.Insertar(new Alumno(2, null, -1, -1));
        }

        [TestMethod]
        public void Test_InsertFuncionando()
        {
            SqlManejador sql = new SqlManejador();

            Assert.IsTrue(sql.Insertar(new Alumno(34123455, "pepe1", 2, 5)) == 1);
        }
    }
}
