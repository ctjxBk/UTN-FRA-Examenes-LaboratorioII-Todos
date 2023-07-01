using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Archivos;
using System.Threading;
using Patentes;

namespace _20181122_SP
{
    public partial class FrmPpal : Form
    {
        private Queue<Patente> cola;
        private CancellationTokenSource cancelarTareas;
        private List<Task> tareas;

        public FrmPpal()
        {
            InitializeComponent();

            this.cola = new Queue<Patente>();
            this.tareas = new List<Task>();
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            vistaPatente1.FinExposicion += this.ProximaPatente;
            vistaPatente2.FinExposicion += this.ProximaPatente;
        }

        private void ProximaPatente(object patente)
        {
            if (this.cola.Count > 0)
            {
                VistaPatente vista = patente as VistaPatente;
                if(vista != null)
                {
                    Task tarea = new Task(() =>
                    {
                        try
                        {
                            ((VistaPatente)patente).MostrarPatente(this.cola.Dequeue());
                        }
                        catch (Exception ex)
                        {
                            VistaPatente.MostrarError(ex);
                        }
                    });
                    this.tareas.Add(tarea);
                    tarea.Start();
                }
                
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FinalizarSimulacion();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                Xml<Queue<Patente>> xml = new Xml<Queue<Patente>>();
                xml.Leer("patentes.xml", out cola);
            }
            catch (PatenteInvalidaException ex)
            {
                VistaPatente.MostrarError(ex);
            }
            this.IniciarSimulacion();
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                Texto texto = new Texto();
                texto.Leer("patentes.txt", out cola);
            }
            catch (PatenteInvalidaException ex)
            {
                VistaPatente.MostrarError(ex);
            }
            this.IniciarSimulacion();
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            try
            {
                Sql sql = new Sql();
                sql.Leer("Patentes",out cola);
            }
            catch (PatenteInvalidaException ex)
            {
                VistaPatente.MostrarError(ex);
            }
            this.IniciarSimulacion();
        }

        private void FinalizarSimulacion()
        {
            this.cancelarTareas?.Cancel();
            this.tareas.Clear();
        }

        private void IniciarSimulacion()
        {
            this.FinalizarSimulacion();
            
            this.cancelarTareas = new CancellationTokenSource();
            this.vistaPatente1.CancelarTarea = this.cancelarTareas;
            this.vistaPatente2.CancelarTarea = this.cancelarTareas;

            if (cola.Count > 0)
            {
                this.ProximaPatente(this.vistaPatente1);
                this.ProximaPatente(this.vistaPatente2);
            }
        }



    }
}
