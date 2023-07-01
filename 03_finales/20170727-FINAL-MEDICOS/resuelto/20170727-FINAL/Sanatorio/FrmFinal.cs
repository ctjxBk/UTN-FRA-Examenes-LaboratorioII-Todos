using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Entidades;

namespace Sanatorio
{
    //11:20 - 12:30 y 13:00 a 13:00 completo, se agrego un getter para solucionar un bug
    //mirar la propiedad "AtenderA" en Medico.cs
    public partial class FrmFinal : Form
    {

        private MEspecialista medicoEspecialista;
        private MGeneral medicoGeneral;
        private Task mocker;
        private Queue<Paciente> pacientesEnEspera;
        private Queue<Paciente> pacientes;
        private CancellationTokenSource cancelarMocker;

        public FrmFinal()
        {
            InitializeComponent();

            this.medicoGeneral = new MGeneral("Luis", "Salinas");
            this.medicoGeneral.AtencionFinalizada += this.FinAtencion;
            
            this.medicoEspecialista = new MEspecialista("Jorge", "Iglesias", MEspecialista.Especialidad.Traumatologo);
            this.medicoEspecialista.AtencionFinalizada += this.FinAtencion;

            this.pacientesEnEspera = new Queue<Paciente>();
            this.pacientes = new Queue<Paciente>();
        }

        private void AtenderPacientes(IMedico iMedico)
        {
            if(this.pacientesEnEspera.Count > 0)
            {
                Paciente paciente = this.pacientesEnEspera.Dequeue();
                if(paciente is not null)
                {
                    if (iMedico is MGeneral)
                    {
                        if(((MGeneral)iMedico).AtenderA is null)
                        {
                            iMedico.IniciarAtencion(paciente);
                        }
                        else
                        {
                            MessageBox.Show($"El medico {((Medico)iMedico).Nombre} esta atendiendo ahora", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } 
                    else if(iMedico is MEspecialista)
                    {
                        if(((MEspecialista)iMedico).AtenderA is null)
                        {
                            iMedico.IniciarAtencion(paciente);
                        }
                        else
                        {
                            MessageBox.Show($"El medico {((Medico)iMedico).Nombre}  esta atendiendo ahora", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Al momento de sacar un paciente de la cola","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                if(this.pacientes.Count > 0)
                {
                    MessageBox.Show("Espere a que vengan más pacientes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ya no hay mas pacientes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        

        private void FinAtencion(Paciente p, Medico m)
        {
            MessageBox.Show($"Finalizó la atención de {p.Nombre} por {m.Nombre}{Environment.NewLine}Paciente:{p.ToString()}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MockPacientes()
        {
            while (!this.cancelarMocker.IsCancellationRequested 
                &&  (this.pacientesEnEspera.Count != 0 || this.pacientes.Count != 0)
                )
            {
                if(this.pacientes.Count == 0)
                {
                    break;
                }
                this.pacientesEnEspera.Enqueue(this.pacientes.Dequeue());
                Thread.Sleep(5000);
            }
            if(this.pacientesEnEspera.Count == 0)
            {
                MessageBox.Show("Por el día de HOY no abra mas pacientes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(this.cancelarMocker.IsCancellationRequested) 
            {
                MessageBox.Show("Se cancelo la TASK", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmFinal_Load(object sender, EventArgs e)
        {
            this.pacientes.Enqueue(new Paciente("Cosme", "Fulano"));
            this.pacientes.Enqueue(new Paciente("Ricky", "Ricon"));
            this.pacientes.Enqueue(new Paciente("Cafe", "Martinez", 40));
            this.pacientes.Enqueue(new Paciente("Ricardo", "Ford"));
            this.pacientes.Enqueue(new Paciente("Peter", "El Anguila", 70));
            this.pacientes.Enqueue(new Paciente("El Retutu", "Papa"));
            this.pacientes.Enqueue(new Paciente("Pingüino", "Martinez"));

            //CARGA ALMENOS 1 PACIENTE... IMPORTANTE
            this.pacientesEnEspera.Enqueue(this.pacientes.Dequeue());

            this.mocker = new Task(() =>
            {
                this.cancelarMocker = new CancellationTokenSource();
                this.MockPacientes();
            });
            this.mocker.Start();
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            this.AtenderPacientes(this.medicoGeneral);
        }

        private void btnEspecialista_Click(object sender, EventArgs e)
        {
            this.AtenderPacientes(this.medicoEspecialista);
        }

        private void FrmFinal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.mocker is not null 
                &&
                (this.mocker.Status == TaskStatus.Running
                || this.mocker.Status == TaskStatus.WaitingForActivation
                || this.mocker.Status == TaskStatus.WaitingToRun)
                && this.cancelarMocker is not null
                )
            {
                this.cancelarMocker.Cancel();
            }
        }
    }
}
