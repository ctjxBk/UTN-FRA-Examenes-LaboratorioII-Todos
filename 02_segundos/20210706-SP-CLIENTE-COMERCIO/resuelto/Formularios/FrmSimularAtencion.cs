using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FrmSimularAtencion : Form
    {
        Comercio comercio;
        public static event Action ActualizarBD;
       
        public FrmSimularAtencion(Comercio comercio)
        {
            InitializeComponent();
            this.comercio = comercio;
            new Simular(comercio);
            Simular.ActualizarCliente += ActualizarLabel;
            Simular.FinalizarAtencion += Cerrar;
           
        }

        private void FrmSimularAtencion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void Cerrar()
        {
            if (this.InvokeRequired)
            {
               

                this.Invoke(new Action(Cerrar));
            }
            else
            {
                this.Close();
            }
        }

        public void ActualizarLabel(Object o)
        {
            if (lblCliente.InvokeRequired)
            {
                Delegado d = new Delegado(ActualizarLabel);
                Object[] obj = new Object[] { o };
                lblCliente.Invoke(d, obj);
            }
            else
            {
                lblCliente.Text = ((Cliente)o).Numero + " " + ((Cliente)o).Nombre ;
            }
        }
        
       
        private void FrmSimularAtencion_FormClosing(object sender, FormClosingEventArgs e)
        {
                
            Simular.Cerrar();
            ActualizarBD.Invoke();
        }
    }
}
