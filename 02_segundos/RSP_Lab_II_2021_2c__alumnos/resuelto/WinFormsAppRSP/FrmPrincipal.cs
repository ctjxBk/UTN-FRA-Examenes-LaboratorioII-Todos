using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WinFormsAppRSP
{
    ///Agregar manejo de excepciones en TODOS los lugares críticos!!!

    public partial class FrmPrincipal : Form
    {
        ///Crear en un proyecto de tipo class library (EntidadesRSP), las clases:
        ///Persona
        ///Atributos (todos privados)
        ///dni : int
        ///apellido : string
        ///nombre : string
        ///Propiedades públicas de lectura y escritura para todos sus atributos.
        ///Constructor que reciba parámetros para cada atributo
        ///Polimorfismo sobre ToString
        ///
        ///Alumno (deriva de Persona)
        ///Atributo
        ///nota : double
        ///Propiedad pública de lectura y escritura para su atributo.
        ///Constructor que reciba parámetro para cada atributo
        ///Polimorfismo sobre ToString
        ///Eventos (diseñados según convenciones vistas)
        ///Aprobar
        ///NoAprobar
        ///Promocionar
        ///Método de instancia (público)
        ///Clasificar() : void
        ///Si el atributo nota es menor a 4, lanzará el evento NoAprobar.
        ///Si el atributo nota es menor a 6 (y mayor o igual a 4), lanzará el evento Aprobar.
        ///Si el atributo nota es mayor o igual a 6, lanzará el evento Promocionar.
        ///
        ///AlumnoADO (hereda de Alumno)
        ///Atributos (estáticos)
        ///conexion : string
        ///connection : SqlConnection
        ///command : SqlCommand
        ///Constructor de clase que inicialice todos sus atributos
        ///Constructor que recibe un objeto de tipo Alumno cómo parámetro
        ///Métodos de instancia (públicos):
        ///ObtenerTodos() : List<Alumno> 
        ///Agregar() : bool
        ///Modificar() : bool -> se modifica a partir del dni
        ///Eliminar() : bool -> se elimina a partir del dni

        ///BASE DE DATOS
        ///Crear la BASE de DATOS utn_fra_alumnos y ejecutar el siguiente script:
        ///USE [utn_fra_alumnos]
        ///GO
        ///CREATE TABLE [dbo].[alumnos]
        ///(
        ///[dni] [int] NOT NULL,
        ///[apellido] [varchar](50) NOT NULL,
        ///[nombre] [varchar](50) NOT NULL,
        ///[nota] [float] NOT NULL,
        ///) ON[PRIMARY]
        ///GO
        ///

        private List<EntidadesRSP.Alumno> alumnos;
        public FrmPrincipal()
        {
            InitializeComponent();

            //this.Text = "Cambiar por su apellido y nombre";
            //MessageBox.Show(this.Text);

            this.CargarListados();

            ///Agregar los manejadores de eventos para: 
            ///btnAgregar, btnEliminar, btnModificar, btnSerializar, btnDeserializar y btnHilos
            ///
            this.btnAgregar.Click += this.ManejadorAgregar;
            this.btnEliminar.Click += this.ManejadorEliminar;
            this.btnModificar.Click += this.ManejadorModificar;
            this.btnSerializar.Click += this.ManejadorSerializar;
            this.btnDeserializar.Click += this.ManejadorDeserializar;
            this.btnHilos.Click += this.ManejadorHilos;
        }

        private void CargarListados()
        {
            this.lstAprobados.Items.Clear();
            this.lstDesaprobados.Items.Clear();
            this.lstPromocionados.Items.Clear();

            ///Utilizando la clase AlumnoADO, obtener y mostrar todos los productos
            ///
            try
            {
                this.alumnos = EntidadesRSP.AlumnoADO.ObtenerTodos();
            }
            catch (EntidadesRSP.ExcepcionPersonalizada ex)
            {
                this.MostrarError(ex);
            }
            this.lstTodos.DataSource = this.alumnos;


            foreach (EntidadesRSP.Alumno item in this.alumnos)
            {
                ///Agregar, para los eventos
                ///Aprobar, NoAprobar y Promocionar, los manejadores
                ///AlumnoAprobado, AlumnoNoAprobado y AlumnoPromocionado, respectivamente
                ///

                item.Aprobar += this.AlumnoAprobado;
                item.NoAprobar += this.AlumnoNoAprobado;
                item.Promocionar += this.AlumnoPromocionado;

                item.Clasificar();

                ///Quitar los manejadores de eventos para:
                ///Aprobar, NoAprobar y Promocionar

                item.Aprobar -= this.AlumnoAprobado;
                item.NoAprobar -= this.AlumnoNoAprobado;
                item.Promocionar -= this.AlumnoPromocionado;

            }
        }

        private void ManejadorAgregar(object emisor, EventArgs argumentos)
        {
            ///Agregar un nuevo alumno a la base de datos
            ///Utilizar FrmAlumno.
            ///Si se pudo agregar, invocar al método CargarListados, caso contrario mostrar mensaje
            ///
            FrmAlumno frmAlumno = null;
            DialogResult respuesta = DialogResult.None;
            try
            {
                frmAlumno = new FrmAlumno();
                respuesta = frmAlumno.ShowDialog();
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
            if(respuesta == DialogResult.OK)
            {
                try
                {
                    EntidadesRSP.Alumno alumno = frmAlumno.Alumno;
                    EntidadesRSP.AlumnoADO alumnoADO = new EntidadesRSP.AlumnoADO(alumno);
                    if (alumnoADO.Agregar())
                    {
                        this.CargarListados();
                        MessageBox.Show($"Se agrego el Alumno{Environment.NewLine}{alumno.ToString()}{Environment.NewLine}A la base de datos");
                    }
                }
                catch (EntidadesRSP.ExcepcionPersonalizada ex)
                {
                    this.MostrarError(ex);
                }
            }
            else if (respuesta == DialogResult.Cancel)
            {
                MessageBox.Show("Se cancelo el agregar un alumno");
            }

        }

        private void ManejadorModificar(object emisor, EventArgs argumentos)
        {
            ///Modificar el alumno seleccionado (el dni no se debe modificar, adecuar FrmAlumno)
            ///Se deben mostrar todos los datos en el formulario (adaptarlo)
            ///reutilizar FrmAlumno.
            ///Si se pudo modificar, invocar al método CargarListados, caso contrario mostrar mensaje
            ///

            FrmAlumno frmAlumno = null;
            DialogResult respuesta = DialogResult.None;
            try
            {
                EntidadesRSP.Alumno alumno = this.lstTodos.SelectedItem as EntidadesRSP.Alumno;
                if (alumno is not null)
                {
                    frmAlumno = new FrmAlumno(alumno,"modificar");
                    respuesta = frmAlumno.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
            if (respuesta == DialogResult.OK)
            {
                try
                {
                    EntidadesRSP.Alumno alumno = frmAlumno.Alumno;
                    EntidadesRSP.AlumnoADO alumnoADO = new EntidadesRSP.AlumnoADO(alumno);
                    if (alumnoADO.Modificar())
                    {
                        this.CargarListados();
                        MessageBox.Show($"Se modifico el Alumno{Environment.NewLine}{alumno.ToString()}{Environment.NewLine}A la base de datos");
                    }
                }
                catch (EntidadesRSP.ExcepcionPersonalizada ex)
                {
                    this.MostrarError(ex);
                }
            }
            else if (respuesta == DialogResult.Cancel)
            {
                MessageBox.Show("Se cancelo el modificar un alumno");
            }
        }

        private void ManejadorEliminar(object emisor, EventArgs argumentos)
        {
            ///Eliminar el alumno seleccionado (el dni no se debe modificar, adecuar FrmAlumno)
            ///Se deben mostrar todos los datos en el formulario (adaptarlo)
            ///reutilizar FrmAlumno.
            ///Si se pudo eliminar, invocar al método CargarListados, caso contrario mostrar mensaje
            ///
            FrmAlumno frmAlumno = null;
            DialogResult respuesta = DialogResult.None;
            try
            {
                EntidadesRSP.Alumno alumno = this.lstTodos.SelectedItem as EntidadesRSP.Alumno;
                if (alumno is not null)
                {
                    frmAlumno = new FrmAlumno(alumno, "eliminar");
                    respuesta = frmAlumno.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
            if (respuesta == DialogResult.OK)
            {
                try
                {
                    EntidadesRSP.Alumno alumno = frmAlumno.Alumno;
                    EntidadesRSP.AlumnoADO alumnoADO = new EntidadesRSP.AlumnoADO(alumno);
                    if (alumnoADO.Eliminar())
                    {
                        this.CargarListados();
                        MessageBox.Show($"Se elimino el Alumno{Environment.NewLine}{alumno.ToString()}{Environment.NewLine}A la base de datos");
                    }
                }
                catch (EntidadesRSP.ExcepcionPersonalizada ex)
                {
                    this.MostrarError(ex);
                }
            }
            else if (respuesta == DialogResult.Cancel)
            {
                MessageBox.Show("Se cancelo el eliminar un alumno");
            }
        }

        private void ManejadorSerializar(object emisor, EventArgs argumentos)
        {
            ///Serializar a XML la lista de alumnos del formulario (this.alumnos)
            ///El archivo .xml guardarlo en el escritorio del cliente, 
            ///con el nombre formado con su apellido.nombre.alumnos.xml
            ///Ejemplo: Alumno Juan Pérez -> perez.juan.alumnos.xml
            ///Indicar si se pudo o no serializar la lista de alumnos
            ///
            try
            {
                if(this.alumnos.Count > 0)
                {
                    if (EntidadesRSP.Serializador.Guardar(this.alumnos))
                    {
                        MessageBox.Show("Se logro serializar a los alumnos");
                    }
                }
                else
                {
                    MessageBox.Show("No hay alumnos para serializar, agregue al menos uno");
                }
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
        }

        private void ManejadorDeserializar(object emisor, EventArgs argumentos)
        {
            ///Deserializar de XML a una lista de alumnos
            ///El archivo .xml tomarlo del escritorio del cliente, 
            ///con el nombre formado con su apellido.nombre.alumnos.xml
            ///Ejemplo: Alumno Juan Pérez -> perez.juan.alumnos.xml
            ///Si se pudo serializar, mostrar el listado completo en un MessageBox.
            ///Si no se pudo deserializar, mostrar los motivos
            ///
            try
            {
                List<EntidadesRSP.Alumno> alumnos = EntidadesRSP.Serializador.Leer();
                if (alumnos.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(EntidadesRSP.Alumno alumno in alumnos)
                    {
                        sb.AppendLine(alumno.ToString());
                    }
                    MessageBox.Show(sb.ToString(),"Alumnos deserializados de XML");
                }
                else
                {
                    MessageBox.Show("Se logro serializar a los alumnos, pero la lista no tiene alumnos");
                }

            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
        }

        public void AlumnoNoAprobado(object alumni, EventArgs e)
        {
            ///Agregar el alumno al listado lstDesaprobados
            ///
            lstDesaprobados.Items.Add(alumni);
        }

        public void AlumnoAprobado(object alumni, EventArgs e)
        {
            ///Agregar el alumno al listado lstAprobados
            ///
            lstAprobados.Items.Add(alumni);
        }

        public void AlumnoPromocionado(object alumni, EventArgs e)
        {
            ///Agregar el alumno al listado lstPromocionados
            ///
            lstPromocionados.Items.Add(alumni);
        }

        private void ManejadorHilos(object emisor, EventArgs argumentos)
        {
            ///Iniciar una nueva tarea en segundo plano que, para lstDesaprobados:
            ///cambie el color de fondo (a rojo) y el color de la fuente (a blanco)
            ///y lo intercambie (fondo a blanco y fuente a rojo) 10 veces,
            ///agregando un retardo de 1 segundo por cada intercambio.
            ///
            ///NOTA: propiedades BackColor (fondo) y ForeColor (fuente)
            ///colores: 
            ///System.Drawing.Color.Red (rojo)
            ///System.Drawing.Color.White (blanco)

            Task t = new Task(this.TareaSobreDesaprobados);
            t.Start();
        }

        private void TareaSobreDesaprobados()
        {
            //CON EL this.InvokeRequired no funciona !!!
            /*
            if (this.InvokeRequired)
            {
                Action metodo = this.TareaSobreDesaprobados;
                this.Invoke(metodo);
            }
            else
            {
                */
            //MessageBox.Show("hilos");
            for (int i = 0; i < 10; i++)
                {
                    
                    lstDesaprobados.BackColor = System.Drawing.Color.Red;
                    lstDesaprobados.ForeColor = System.Drawing.Color.White;
                    Thread.Sleep(1000);
                    lstDesaprobados.BackColor = System.Drawing.Color.White;
                    lstDesaprobados.ForeColor = System.Drawing.Color.Red;
                    Thread.Sleep(1000);
                }
                
            //}
        }


        private void MostrarError(Exception ex)
        {

            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Fecha: {DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss")}");
            sb.AppendLine($"Fecha: {DateTime.Now.ToString()}");

            int contador = 1;
            sb.AppendLine($"Error nº{contador}: {ex.Message}");

            Exception inner = ex;
            while (inner != null)
            {
                contador++;
                sb.AppendLine($"Error nº{contador}: {inner.Message}");
                inner = inner.InnerException;
            }
            sb.AppendLine($"{Environment.NewLine}------------------------------------{Environment.NewLine}");

            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
