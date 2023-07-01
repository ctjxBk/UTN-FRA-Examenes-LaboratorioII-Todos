using System;
using System.Threading.Tasks;
using Entidades;
using Excepciones;

namespace _20180626_SP_Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Torneo torneo1 = new Torneo("Rusia 2018");
            Console.Title = "Copa Mundial Rusia 2018";

            try
            {
                Grupo grupoA = new Grupo(Letras.A, Torneo.MAX_EQUIPOS_GRUPO);
                grupoA.Leer();
                torneo1.Grupos.Add(grupoA);
            }
            catch (Exception ex)//podríar ser GrupoLlenoException o ExcepcionPersonalizada
            {
                Console.WriteLine(ex.Message);
            }

            try 
            { 
                Grupo grupoB = new Grupo(Letras.B, Torneo.MAX_EQUIPOS_GRUPO);
                grupoB.Leer();
                torneo1.Grupos.Add(grupoB);
            }
            catch (Exception ex)//podríar ser GrupoLlenoException o ExcepcionPersonalizada
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Grupo grupoC = new Grupo(Letras.C, Torneo.MAX_EQUIPOS_GRUPO);
                grupoC.Leer();
                torneo1.Grupos.Add(grupoC);
            }
            catch (Exception ex)//podríar ser GrupoLlenoException o ExcepcionPersonalizada
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Grupo grupoD = new Grupo(Letras.D, Torneo.MAX_EQUIPOS_GRUPO);
                grupoD.Leer();
                torneo1.Grupos.Add(grupoD);
            }
            catch (Exception ex)//podríar ser GrupoLlenoException o ExcepcionPersonalizada
            {
                Console.WriteLine(ex.Message);
            }


            foreach (Grupo grupo in torneo1.Grupos)
            {
                Program.ImprimirResultados(grupo);
            }

            // Agregar Thread
            Task.Run(() =>
            {
                foreach (Grupo grupo in torneo1.Grupos)
                {
                    grupo.Simular();
                }
                try
                {
                    torneo1.Guardar();
                }
                catch (ExcepcionPersonalizada ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            // **************
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Torneo torneo2 = new Torneo("Rusia 2018");
            torneo2.Leer();
            Task tarea = Task.Run(() =>
            {
                foreach (Grupo grupo in torneo2.Grupos)
                {
                    grupo.Simular();
                }
            });

            tarea.Wait();
            foreach (Grupo grupo in torneo2.Grupos)
            {
                Program.ImprimirResultados(grupo);
            }

            Console.WriteLine("\nTermino el programa");
            Console.ReadKey();
        }

        static void ImprimirResultados(Grupo grupo)
        {
            Console.WriteLine(grupo.MostrarTabla());
        }
    }
}
