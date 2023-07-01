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
using DAO;
using Archivos;

namespace Vista
{
    public partial class CRUD : Form
    {
        private EmpleadoDAOStatic empleadoDAO;
        private List<Empleado> empleados;
        private Texto texto;
        private XML xml;
        private JSON json;
        private Binario binario;

        
        public CRUD()
        {
            InitializeComponent();

            this.empleados = new List<Empleado>();
            this.empleadoDAO = new EmpleadoDAOStatic();
            this.texto = new Texto();
            this.xml = new XML();
            this.json = new JSON();
            this.binario = new Binario();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            this.Actualizar();
        }
        
        #region BBDD
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.numericUpDownLegajo.Enabled == true)
                {
                    Empleado empleado = this.RecolectarDatos();
                    if (this.empleadoDAO.Existe(empleado.legajo) == false)
                    {
                        if (this.empleadoDAO.Guardar(empleado))
                        {
                            this.empleados.Add(empleado);
                            this.Refrescar();
                            this.BorrarDatos();
                        }
                        else
                        {
                            throw new Exception("No se pudo Guardar el Empleado");
                        }
                    }
                    else
                    {
                        throw new Exception("El empleado ya existe, ya esta cargado el legajo");
                    }
                }
                else
                {
                    MessageBox.Show("Deseleccione el empleado por favor");
                }

            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(this.lstEmpleados.SelectedItem is not null && this.numericUpDownLegajo.Enabled == false)
            {
                try
                {
                    Empleado empleado = this.empleados | new Empleado(this.numericUpDownLegajo.Value);
                    empleado = empleado ^ this.RecolectarDatos();
                    if (this.empleadoDAO.Modificar(empleado))
                    {
                        this.Refrescar();
                        this.BorrarDatos();
                    }
                    else
                    {
                        throw new Exception("No se pudo Modificar el Empleado");
                    }
                }
                catch (Exception ex)
                {
                    this.MostrarError(ex);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado por favor (doble click sobre un empleado en la lista de empleados)",
                    "Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedItem is not null && this.numericUpDownLegajo.Enabled == false)
            {
                try
                {
                    Empleado? empleado = this.lstEmpleados.SelectedItem as Empleado;
                    if (empleado is not null && this.empleadoDAO.Eliminar(empleado.legajo))
                    {
                        this.empleados.Remove(empleado);
                        this.Refrescar();
                        this.BorrarDatos();
                    }
                    else
                    {
                        throw new Exception("No se pudo Eliminar el Empleado");
                    }
                }
                catch (Exception ex)
                {
                    this.MostrarError(ex);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado por favor (doble click sobre un empleado en la lista de empleados)",
                    "Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            this.lstEmpleados.SelectedItem = null;
            this.BorrarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Actualizar();
        }

        private void lstEmpleados_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedItem is not null)
            {
                Empleado? empleado = this.lstEmpleados.SelectedItem as Empleado;
                if (empleado is not null)
                {
                    this.CargarDatosDelListBox(empleado);
                    this.numericUpDownLegajo.Enabled = false;
                }
            }
        }

        #endregion

        #region Lógica BBDD
        public void CargarDatosDelListBox(Empleado empleado)
        {
            this.numericUpDownLegajo.Value = empleado.legajo;
            this.txtNombre.Text = empleado.nombre;
            this.dateTimePickerFechaNacimiento.Value = empleado.fechaNacimiento;
            if (empleado.esFumador)
            {
                this.rbtnEsFumadorTrue.Checked = true;
            }
            else
            {
                this.rbtnEsFumadorFalse.Checked = true;
            }
            this.txtSueldo.Text = empleado.sueldo.ToString();
            this.txtAltura.Text = empleado.altura.ToString();
        }

        private void Actualizar()
        {
            try
            {
                this.empleados = this.empleadoDAO.Leer();
                this.Refrescar();
                this.lstEmpleados.SelectedItem = null;

            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
        }


        private Empleado RecolectarDatos()
        {
            int legajo = (int)this.numericUpDownLegajo.Value;
            string nombre = this.txtNombre.Text;
            DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
            bool esFumador = this.rbtnEsFumadorTrue.Checked;
            double sueldo = double.Parse(this.txtSueldo.Text);
            float altura = float.Parse(this.txtAltura.Text);

            return new Empleado(legajo, nombre, fechaNacimiento, esFumador, sueldo, altura);
        }

        private void BorrarDatos()
        {
            this.numericUpDownLegajo.Value = default;
            this.numericUpDownLegajo.Enabled = true;
            this.txtNombre.Text = default;
            this.dateTimePickerFechaNacimiento.Value = DateTime.Now;
            this.rbtnEsFumadorTrue.Checked = default;
            this.rbtnEsFumadorFalse.Checked = default;
            this.txtSueldo.Text = default;
            this.txtAltura.Text = default;
            this.lstEmpleados.SelectedItem = null;
        }

        private void Refrescar()
        {
            this.lstEmpleados.DataSource = null;
            this.lstEmpleados.DataSource = this.empleados;
        }



        #endregion

        private void MostrarError(Exception ex)
        {

            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Fecha: {DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss")}");
            sb.AppendLine($"Fecha: {DateTime.Now.ToString()}");

            int contador = 0;

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

        #region Lógica Archivos
        private void MostrarMensaje(string contenido)
        {
            MessageBox.Show(contenido,"Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void MostrarMensaje(Empleado empleado)
        {
            this.MostrarMensaje(empleado.ToString());
        }

        private void Guardar(Action<Empleado> metodo)
        {
            if (this.empleados.Count > 0)
            {
                if (this.lstEmpleados.SelectedItem is not null)
                {
                    try
                    {
                        Empleado? empleado = this.lstEmpleados.SelectedItem as Empleado;
                        if (empleado is not null)
                        {
                            metodo?.Invoke(empleado);
                            this.MostrarMensaje("Se guardo correctamente");
                        }
                    }
                    catch (Exception ex)
                    {
                        this.MostrarError(ex);
                    }
                }
                else
                {
                    this.MostrarMensaje($"Por favor seleccione un empleado");
                }
            }
            else
            {
                this.MostrarMensaje($"No hay empleados ...");
            }
        }

        private void Leer(Func<Empleado> metodo)
        {
            try
            {
                this.MostrarMensaje(metodo?.Invoke());

            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            } 
        }

        private void Leer(Func<string> metodo)
        {
            try
            {
                this.MostrarMensaje(metodo?.Invoke());
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
        }
        #endregion

        #region Archivos
        private void btnLeerTexto_Click(object sender, EventArgs e)
        {
            this.Leer(this.texto.Leer);
        }
        

        private void btnGuardarTexto_Click(object sender, EventArgs e)
        {
            this.Guardar(this.texto.Guardar);
        }

        private void btnLeerXML_Click(object sender, EventArgs e)
        {
            this.Leer(this.xml.Leer);
        }

        private void btnGuardarXML_Click(object sender, EventArgs e)
        {
            this.Guardar(this.xml.Guardar);
        }

        private void btnLeerJSON_Click(object sender, EventArgs e)
        {
            this.Leer(this.json.Leer);
        }

        private void btnGuardarJSON_Click(object sender, EventArgs e)
        {
            this.Guardar(this.json.Guardar);
        }

        private void btnLeerBinario_Click(object sender, EventArgs e)
        {
            this.Leer(this.binario.Leer);
        }

        private void btnGuardarBinario_Click(object sender, EventArgs e)
        {
            this.Guardar(this.binario.Guardar);
        }
        #endregion

      
    }
}
