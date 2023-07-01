using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.IO;

namespace Testing
{
    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            PersonalMedico medico = new PersonalMedico("cosme", "fulano", DateTime.Now, false);
            Paciente paciente1 = new Paciente("ricky", "fort", DateTime.Now, "Quilmes");
            Paciente paciente2 = new Paciente("marta", "fort", DateTime.Now, "Avellaneda");
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = Path.Combine(ruta, "agustin-c.xml");
            //Consulta consulta1 = new Consulta(DateTime.Now, paciente1);
            //Consulta consulta2 = new Consulta(DateTime.Now, paciente2);

            //act
            Consulta consulta = medico + paciente1;
            consulta = medico + paciente2;
            Serializador<PersonalMedico, PersonalMedico> serializador = new Serializador<PersonalMedico, PersonalMedico>();
            serializador.Guardar(medico, path);

            PersonalMedico medicoLeido = serializador.Leer(path);

            //assert
            Assert.IsTrue(medico.Nombre == medicoLeido.Nombre && medico.Apellido == medicoLeido.Apellido && medico.Consultas.Count == medicoLeido.Consultas.Count);

        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            PacienteDao pacienteDao = new PacienteDao();

            //act
            pacienteDao.Leer(null);

            //assert
            //si no tiro ningun error , la conexion se establecio correctamente
            Assert.IsTrue(true);
        }


        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]  
        public void TestMethod3()
        {
            //arrange
            PacienteDao pacienteDao = new PacienteDao();

            //act
            pacienteDao.Guardar(null, null);

            //assert
            //ExpectedException
        }


        [TestMethod]
        
        public void TestMethod4()
        {
            //arrange
            PersonalMedico medico = new PersonalMedico("cosme", "fulano", DateTime.Now, false);
            Paciente paciente1 = new Paciente("ricky", "fort", DateTime.Now, "Quilmes");
            Paciente paciente2 = new Paciente("marta", "fort", DateTime.Now, "Avellaneda");
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = Path.Combine(ruta, "agustin-c.xml");
            //Consulta consulta1 = new Consulta(DateTime.Now, paciente1);
            //Consulta consulta2 = new Consulta(DateTime.Now, paciente2);

            //act
            Consulta consulta = medico + paciente1;
            consulta = medico + paciente2;
            Serializador<PersonalMedico, PersonalMedico> serializador = new Serializador<PersonalMedico, PersonalMedico>();
            serializador.Guardar(medico, path);

            PersonalMedico medicoLeido = serializador.Leer(path);

            //assert
            Assert.IsTrue(medico.Nombre == medicoLeido.Nombre && medico.Apellido == medicoLeido.Apellido && medico.Consultas.Count == medicoLeido.Consultas.Count);
            Assert.IsTrue(File.Exists(path));
            serializador.BorrarMedico(path);
            Assert.IsTrue(!File.Exists(path));
        }
    }
}

