using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public delegate void DelegadoCombateDosJugadores(IJugador jugador1, IJugador jugador2);
    public delegate void DelegadoCombateUnJugador(IJugador jugador);
    public sealed class  Combate
    {
        private IJugador atacado;
        private IJugador atacante;
        private static Random random;

        public event DelegadoCombateDosJugadores RondaIniciada;
        public event DelegadoCombateUnJugador CombateFinalizado;

        
        static Combate()
        {
            random = new Random();
        }

        public Combate(IJugador jugador1, IJugador jugador2)
        {
            this.atacante = this.SeleccionarPrimerAtacante(jugador1, jugador2);
            if(this.atacante == jugador1)
            {
                this.atacado = jugador2;
            }
            else
            {
                this.atacado = jugador1;
            }
        }

        private void Combatir()
        {
            IJugador ganador;
            do
            {
                this.IniciarRonda();
                ganador = this.EvaluarGanador();
            } while(ganador is null);
            this.CombateFinalizado?.Invoke(ganador);
            ResultadoCombate resultado;
            resultado = new ResultadoCombate(atacante.ToString(), atacado.ToString(), DateTime.Now);
            this.Guardar(resultado);
        }
        

        private void Guardar(ResultadoCombate resultado)
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "Combate.xml");
            try
            {

            }
            catch (Exception ex)
            {

            }
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ResultadoCombate));
                xmlSerializer.Serialize(streamWriter, resultado);
            }
        }



        private IJugador EvaluarGanador()
        {
            if(this.atacado.PuntosDeVida == 0)
            {
                return this.atacante;
            }
            //else
            //{
                IJugador jugadorExtra = this.atacante;
                this.atacante = this.atacado;
                this.atacado = jugadorExtra;
                return null;
            //}
        }

        public Task IniciarCombate()
        {
            

            return Task.Run(() =>
            {
                this.Combatir();
            });
        }

        private void IniciarRonda()
        {
            this.RondaIniciada?.Invoke(this.atacante,this.atacado);
            this.atacado.RecibirAtaque(this.atacante.Atacar());
        }

        private IJugador SeleccionarJugadorAleatoriamente(IJugador jugador1, IJugador jugador2)
        {
            if(random.TirarUnaModeda() == LadosMoneda.Cara)
            {
                return jugador1;
            }
            //else if(random.TirarUnaModeda() == LadosMoneda.Ceca)
            //{
            return jugador2;
            //}
        }

        private IJugador SeleccionarPrimerAtacante(IJugador jugador1, IJugador jugador2)
        {
            if(jugador1.Nivel > jugador2.Nivel)
            {
                return jugador2;
            }
            else if(jugador1.Nivel < jugador2.Nivel)
            {
                return jugador1;
            }
            else
            {
                return this.SeleccionarJugadorAleatoriamente(jugador1, jugador2);
            }
        }


    }
}
