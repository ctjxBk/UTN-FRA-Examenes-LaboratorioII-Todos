using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Circo : Form
    {
        private PayasoMalvado payaso;
        private Serializadora serializadora;
        private List<PictureBox> globos;

        public Circo()
        {
            InitializeComponent();

            globos = new List<PictureBox>();
            payaso = new PayasoMalvado("Pennywise", new DateTime(2021,5,12),"payaso.xml");
            serializadora = new Serializadora();

            globos.Add(balloon1);
            globos.Add(balloon2);
            globos.Add(balloon3);
            globos.Add(balloon4);
            globos.Add(balloon5);

        }
        private void RegalarGlobos()
        {
          //Inicio y arranco la Task
        }

        private void MostrarGlobos(int index, bool estado)
        {
            
        }

        private void Circo_Load(object sender, EventArgs e)
        {
            //Asocio el evento

        }

        private void btnFlotar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
          
        }

    }
}
