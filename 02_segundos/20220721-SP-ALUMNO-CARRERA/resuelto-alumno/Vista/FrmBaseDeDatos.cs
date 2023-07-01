using BibliotecaDeClases;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmBaseDeDatos : Form
    {
        SqlManejador manejador; // no modificar
        public FrmBaseDeDatos()
        {
            InitializeComponent(); // no modificar linea
            manejador = new SqlManejador(); // no modificar linea
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //if(this.ValidarDni(tb_dni.Text)
                //    && this.ValidarNombre(tb_nombre.Text)
                //    && this.ValidarNota(tb_nota1.Text)
                //    && this.ValidarNota(tb_nota2.Text)
                //    )
                //{

                //}
                //Alumno unAlumno = new Alumno(this.ValidarDni(this.tb_dni.Text), this.ValidarNombre(this.tb_nombre.Text), this.ValidarNota(this.tb_nota1.Text), this.ValidarNota(this.tb_nota2.Text));
                Alumno unAlumno = new Alumno(int.Parse(tb_dni.Text), tb_nombre.Text, int.Parse(tb_nota1.Text), int.Parse(tb_nota2.Text));
                // completar

                SqlManejador sqlManejador = new SqlManejador();
                if (sqlManejador.Insertar(unAlumno) > 0)
                {
                    MessageBox.Show("Se ha insertado el alumno correctamente");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //private decimal ValidarDni(string txtDni)
        //{
        //    int dni;
        //    string dniCadena = txtDni.Replace(".", "");
        //    if (int.TryParse(dniCadena, out dni))
        //    {
        //        if (dni > 10000000 && dni < 45000000)
        //        {
        //            return dni;
        //        }
        //    }
        //    throw new Exception("Dni fuera de rango");
        //}

        //private string ValidarNombre(string nombre)
        //{
        //    if (!String.IsNullOrEmpty(nombre))
        //    {
        //        return nombre;
        //    }
        //    throw new Exception("Nombre no puede ser nulo o vacio");
        //}

        //private decimal ValidarNota(string notaParcial)
        //{
        //    decimal nota;
        //    if(decimal.TryParse(notaParcial, out nota))
        //    {
        //        if (nota > 0 && nota < 11)
        //        {
        //            if((int)nota == nota)
        //            {
        //                return (int)nota;
        //            }
        //        }
        //    }
        //    throw new Exception("Nota fuera de rango, con coma o no es numerico");
        //}


    }
}
