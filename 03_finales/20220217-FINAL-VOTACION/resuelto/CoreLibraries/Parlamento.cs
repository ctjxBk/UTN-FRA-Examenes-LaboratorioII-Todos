using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoreLibraries
{
    public delegate void FinalizaRegistro();

    //[XmlInclude(typeof(Senador))]
    public class Parlamento<T> //: IParlamento where T : Senador
        where T : IParlamento
    {
        private List<T> bancas;
        private bool estadoSesion;
        private T presidente;
        public delegate void InformarCambioEstado(T banca);
        public event FinalizaRegistro FinVotacion;
        public event InformarCambioEstado OcupaBanca;
        public event FinalizaRegistro ParlamentariosRegistrados;
        public event InformarCambioEstado VotoEmitido;
        private CancellationTokenSource cancelarVotacion;
        public event Action<Exception> MostrarError;
        private int votosAfirmativos;
        private int votosNegativos;
        private int votosAbstenciones;

        public List<T> Bancas { get => bancas; set => bancas = value; }
        public bool EstadioSesion
        {
            set
            {
                this.estadoSesion = value;
                Task.Run(() =>
                {
                    foreach(T banca in bancas)
                    {
                        banca.AperturaSesion = this.estadoSesion;
                        this.OcupaBanca?.Invoke(banca);
                        Thread.Sleep(10);
                    }
                    this.ParlamentariosRegistrados?.Invoke();
                });
            }
        }
        public T Presidente { get => presidente;}

        public int VotosAbstenciones
        {
            get
            {
                if(this.votosAbstenciones != 0)
                {
                    return this.votosAbstenciones;
                }
                else
                {
                    this.votosAbstenciones = this.ContarVotos(Evoto.Abstencion);
                    return this.votosAbstenciones;
                }
            }
            set
            {
                this.votosAbstenciones = value;
            }
        }

        public int VotosAfirmativos
        {
            get
            {
                if (this.votosAfirmativos != 0)
                {
                    return this.votosAfirmativos;
                }
                else
                {
                    this.votosAfirmativos = this.ContarVotos(Evoto.Positivo);
                    return this.votosAfirmativos;
                }
            }
            set
            {
                this.votosAfirmativos = value;
            }

            //get => this.ContarVotos(Evoto.Positivo);
            //set
            //{
            //    throw new NotImplementedException();
            //}
        }
        public int VotosNegativos
        {
            get
            {
                if (this.votosNegativos != 0)
                {
                    return this.votosNegativos;
                }
                else
                {
                    this.votosNegativos = this.ContarVotos(Evoto.Negativo);
                    return this.votosNegativos;
                }
            }
            set
            {
                this.votosNegativos = value;
            }
            //get => this.ContarVotos(Evoto.Negativo);
            //set
            //{
            //    throw new NotImplementedException();
            //}
        }

        #region interfaz
        [System.Text.Json.Serialization.JsonIgnore]
        public bool AperturaSesion { set => throw new NotImplementedException(); }
        [System.Text.Json.Serialization.JsonIgnore]
        public bool Presentismo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [System.Text.Json.Serialization.JsonIgnore]
        public Evoto Voto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void EmitirVoto()
        {
            throw new NotImplementedException();
        }
        #endregion

        public void CancelarVotacion()
        {
            this.cancelarVotacion?.Cancel();
        }

        private int ContarVotos(Evoto voto)
        {
            int contador = 0;
            foreach(T banca in this.bancas)
            {
                if(banca.Voto == voto)
                {
                    contador++;
                }
            }
            return contador;
        }

        public void DesempatePresidente()
        {
            if(this.VotosAfirmativos != this.VotosNegativos)
            {
                throw new NoNecesitaDesempateException();
            }
            else
            {
                presidente.EmitirVoto();
                this.VotoEmitido?.Invoke(presidente);
            }
        }

        public void IniciarVotacion()
        {
            this.cancelarVotacion = new CancellationTokenSource();
            Task.Run(() =>
            {
                foreach(T banca in this.bancas)
                {
                    if (this.cancelarVotacion.IsCancellationRequested)
                    {
                        return;
                    }
                    if (banca.Presentismo)
                    {
                        banca.EmitirVoto();
                        this.VotoEmitido?.Invoke(banca);
                        // para que vaya mas rápido
                        Thread.Sleep(50);
                        //Thread.Sleep(new Random().Next(400,1001));
                    }
                }
                try
                {
                    this.DesempatePresidente();
                }
                catch (NoNecesitaDesempateException ex)
                {
                    this.MostrarError?.Invoke(ex);
                }
                
                this.FinVotacion?.Invoke();
                try
                {
                    string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string path = Path.Combine(ruta, "parlamento.json");
                    JsonManager<Parlamento<T>>.Guardar(path,this);
                    //Parlamento<T> parla = JsonManager<Parlamento<T>>.Leer(path);

                }
                catch (FilesException ex)
                {
                    this.MostrarError?.Invoke(ex);
                }
                catch(Exception ex)
                {
                    this.MostrarError?.Invoke(ex);
                }

                try
                {
                    this.Guardar();
                }
                catch (Exception ex)
                {
                    this.MostrarError?.Invoke(ex);
                }
                
            });
        }
        
        public Parlamento(T presidente)
        {
            this.presidente = presidente;
            this.bancas = new List<T>();
        }

        //public static implicit operator Parlamento<T>(T presidente)
        //{
        //    return new Parlamento<T>(presidente); 
        //}


        private bool Guardar()
        {
            try
            {
                string tabla = "resultados";
                string connectionString = @"Server = .\; Database = votacion-finales-202112; Trusted_Connection = True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"INSERT INTO {tabla} (fecha, positivos, negativos, abstenciones, alumno)" +
                        " VALUES (@fecha, @positivos, @negativos, @abstenciones, @alumno)";
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("fecha", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("positivos", this.VotosAfirmativos);
                    command.Parameters.AddWithValue("negativos", this.VotosNegativos);
                    command.Parameters.AddWithValue("abstenciones", this.VotosAbstenciones);
                    command.Parameters.AddWithValue("alumno", "agustin c");

                    bool retorno = command.ExecuteNonQuery() > 0 ? true : false;
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al Guardar en la BBDD", ex);
            }
        }
    }
}
