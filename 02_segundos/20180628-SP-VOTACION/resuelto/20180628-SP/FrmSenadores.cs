﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace _20180628_SP
{
    public partial class FrmSenadores : Form
    {
        Votacion votacion;
        Dictionary<string, Votacion.EVoto> participantes;
        List<PictureBox> graficos;

        public FrmSenadores()
        {
            InitializeComponent();
            // Instancio el Diccionario de Senadores y sus votos
            this.participantes = new Dictionary<string, Votacion.EVoto>();

            // Creo las Bancas y sus Senadores
            this.graficos = new List<PictureBox>();
            int x = 20;
            int y = 20;
            for (int i = 1; i <= 72; i++)
            {
                this.participantes.Add(i.ToString(), Votacion.EVoto.Esperando);
                PictureBox p = new PictureBox();
                p.BackColor = Color.White;
                p.Size = new Size(20, 20);
                p.Location = new Point(x, y);
                x += 25;
                if (x > 595)
                {
                    x = 20;
                    y += 25;
                }

                this.gpbSenado.Controls.Add(p);
                this.graficos.Add(p);
            }

            
        }

        public void ManejadorVoto(string senador, Votacion.EVoto voto)
        {
            if (this.groupBox2.InvokeRequired)
            {
                Votacion.Voto recall = new Votacion.Voto(this.ManejadorVoto);
                this.Invoke(recall, new object[] { senador, voto });
            }
            else
            {
                // Leo la banca del Senador actual
                //PictureBox p = this.graficos.ElementAt(int.Parse(senador) - 1);
                PictureBox p = this.graficos.ElementAt(int.Parse(senador) - 1);
                switch (voto)
                {
                    case Votacion.EVoto.Afirmativo:
                        // Sumo votantes al Label correspondiente
                        lblAfirmativo.Text = (int.Parse(lblAfirmativo.Text) + 1).ToString();
                        // Marco la banca con color Verde
                        p.BackColor = Color.Green;
                        break;
                    case Votacion.EVoto.Negativo:
                        // Sumo votantes al Label correspondiente
                        lblNegativo.Text = (int.Parse(lblNegativo.Text) + 1).ToString();
                        // Marco la banca con color Rojo
                        p.BackColor = Color.Red;
                        break;
                    case Votacion.EVoto.Abstencion:
                        // Sumo votantes al Label correspondiente
                        lblAbstenciones.Text = (int.Parse(lblAbstenciones.Text) + 1).ToString();
                        // Marco la banca con color Amarillo
                        p.BackColor = Color.Yellow;
                        break;
                }
                // Quito un Senador de los que un no votaron, para marcar cuando termina la votación
                int aux = int.Parse(lblEsperando.Text) - 1;
                lblEsperando.Text = aux.ToString();
                // Si finaliza la votación, muestro si Es Ley o No Es Ley
                if (aux == 0)
                {
                    MessageBox.Show((int.Parse(lblAfirmativo.Text) - int.Parse(lblNegativo.Text)) > 0 ? "Es Ley" : "No es Ley", txtLeyNombre.Text);
                    // Guardar resultados
                    try
                    {
                        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                        string path = Path.Combine(ruta, "votacion-20180628-SP.xml");
                        SerializarXML<Votacion> serializador = new SerializarXML<Votacion>();
                        serializador.Guardar(path, this.votacion);
                    }
                    catch (ErrorArchivoException ex)
                    {
                        MensajeError(ex);
                    }

                    try
                    {
                        Dao<Votacion> dao = new Dao<Votacion>();
                        dao.Guardar("no-es-necesario", this.votacion);
                    }
                    catch (Exception ex)
                    {
                        MensajeError(ex);
                    }
                }
            }
        }

        private void MensajeError(Exception ex)
        {
            if (this.InvokeRequired)
            {
                Action<Exception> metodo = MensajeError;
                object[] parametros = new object[] { ex };
                this.Invoke(metodo, parametros);
            }
            else
            {
                string mensaje = ex.Message;
                if (ex.InnerException is not null)
                {
                    mensaje += $"{Environment.NewLine}{ex.InnerException.Message}";
                }
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            // Creo una nueva votación
            this.votacion = new Votacion(txtLeyNombre.Text, this.participantes);
            // Mostrar Quorum
            lblEsperando.Text = this.participantes.Count.ToString();

            // Reseteo de la votación
            foreach (PictureBox p in this.graficos)
                p.BackColor = Color.White;
            lblAfirmativo.Text = "0";
            lblNegativo.Text = "0";
            lblAbstenciones.Text = "0";

            // EVENTO
            //this.votacion.EventoVotoEfectuado += ManejadorVoto;
            this.votacion.EventoVotoEfectuado += votacion.VerificarEventos;


            // THREAD
            Task.Run(() =>
            {
                this.votacion.Simular();
            });
        }
    }
}
