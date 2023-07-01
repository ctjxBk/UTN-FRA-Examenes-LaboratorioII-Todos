using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Mock
    {
        public static event Action OnActualizarPacientes;
        public static event Action OnFinalizo;
        public static event Action<Exception> OnMostrarError;
        private static Random random;

        static Mock()
        {
            random = new Random();
        }
        
        public static void Mocking(List<Paciente> pacientes)
        {
            Task.Run(() =>
            {
                List<Paciente> baseDeDatos = new List<Paciente>();
                try
                {
                    PacienteDao pacienteDao = new PacienteDao();
                    baseDeDatos = pacienteDao.Leer(null);
                }
                catch (ExcepcionPersonalizada ex)
                {
                    OnMostrarError?.Invoke(ex);
                }
                foreach (Paciente paciente in baseDeDatos)
                {
                    pacientes.Add(paciente);
                    OnActualizarPacientes?.Invoke();
                    //puse menos tiempo para no demorar tanto
                    Thread.Sleep(random.Next(100, 501));
                }
                OnFinalizo?.Invoke();
            });
        }

        
    }
}
