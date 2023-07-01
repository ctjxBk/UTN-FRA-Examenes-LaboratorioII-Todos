using System;
using Entidades;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Equipo elGlobo = new Equipo("Huracan de San Rafael", new DirectorTecnico("Jorge", "Habberger"), Equipo.Deportes.Futbol);
            elGlobo += new Jugador("Fernando", "Pandolfi", 11, false);
            elGlobo += new Jugador("Julio", "Marchant", 8, false);
            elGlobo += new Jugador("Ezequiel", "Medran", 12, false);
            elGlobo += new Jugador("José", "Pereda", 24, false);
            elGlobo += new Jugador("Hernán", "Florentin", 6, false);
            elGlobo += new Jugador("Fernando", "Navas", 10, true);
            Console.WriteLine((string)elGlobo);
            Console.ReadKey();
        }
    }
}
