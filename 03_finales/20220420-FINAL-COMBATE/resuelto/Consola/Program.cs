using System;
using System.IO;
using System.Threading;
using Entidades;

namespace Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "log.txt");
            Logger logger = new Logger(path);

            Personaje personaje1 = null;
            try
            {
                personaje1 = PersonajeDAO.ObtenerPersonajePorId(1);
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Guardar(ex.Message);
            }

            Personaje personaje2 = null;

            try
            {
                personaje2 = PersonajeDAO.ObtenerPersonajePorId(2);
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Guardar(ex.Message);
            }

            Combate combate = new Combate(personaje1, personaje2);
            personaje1.AtaqueLanzado += MostrarAtaqueLanzado;
            personaje1.AtaqueRecibido += MostrarAtaqueRecibido;

            personaje2.AtaqueLanzado += MostrarAtaqueLanzado;
            personaje2.AtaqueRecibido += MostrarAtaqueRecibido;

            combate.RondaIniciada += IniciarRonda;
            combate.CombateFinalizado += FinalizarCombate;

            Console.WriteLine("¡FIGHT!");

            combate.IniciarCombate().Wait();
        }

        static void IniciarRonda(IJugador atacante, IJugador atacado)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"¡{atacante} ataca a {atacado}!");
        }

        static void FinalizarCombate(IJugador ganador)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Combate finalizado. El ganador es {ganador}.");
            Console.ReadKey();
        }

        static void MostrarAtaqueLanzado(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{personaje} lanzó un ataque de {puntosDeAtaque} puntos.");
        }

        static void MostrarAtaqueRecibido(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{personaje} recibió un ataque por {puntosDeAtaque} puntos. Le quedan {personaje.PuntosDeVida} puntos de vida.");
        }
    }
}
