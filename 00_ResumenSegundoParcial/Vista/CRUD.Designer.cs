namespace Vista
{
    partial class CRUD
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.numericUpDownLegajo = new System.Windows.Forms.NumericUpDown();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.dateTimePickerFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.groupBoxEsFumador = new System.Windows.Forms.GroupBox();
            this.rbtnEsFumadorFalse = new System.Windows.Forms.RadioButton();
            this.rbtnEsFumadorTrue = new System.Windows.Forms.RadioButton();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBoxEmpleado = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDeseleccionar = new System.Windows.Forms.Button();
            this.lstEmpleados = new System.Windows.Forms.ListBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnLeerTexto = new System.Windows.Forms.Button();
            this.btnGuardarTexto = new System.Windows.Forms.Button();
            this.btnLeerXML = new System.Windows.Forms.Button();
            this.btnGuardarXML = new System.Windows.Forms.Button();
            this.btnLeerJSON = new System.Windows.Forms.Button();
            this.btnGuardarJSON = new System.Windows.Forms.Button();
            this.btnLeerBinario = new System.Windows.Forms.Button();
            this.btnGuardarBinario = new System.Windows.Forms.Button();
            this.lblLeer = new System.Windows.Forms.Label();
            this.lblGuardar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLegajo)).BeginInit();
            this.groupBoxEsFumador.SuspendLayout();
            this.groupBoxEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(131, 49);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Nombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // txtSueldo
            // 
            this.txtSueldo.Location = new System.Drawing.Point(131, 122);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.PlaceholderText = "Sueldo";
            this.txtSueldo.Size = new System.Drawing.Size(100, 23);
            this.txtSueldo.TabIndex = 5;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(131, 151);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.PlaceholderText = "Altura";
            this.txtAltura.Size = new System.Drawing.Size(100, 23);
            this.txtAltura.TabIndex = 6;
            // 
            // numericUpDownLegajo
            // 
            this.numericUpDownLegajo.Location = new System.Drawing.Point(17, 49);
            this.numericUpDownLegajo.Name = "numericUpDownLegajo";
            this.numericUpDownLegajo.Size = new System.Drawing.Size(100, 23);
            this.numericUpDownLegajo.TabIndex = 1;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(17, 31);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(42, 15);
            this.lblLegajo.TabIndex = 6;
            this.lblLegajo.Text = "Legajo";
            // 
            // dateTimePickerFechaNacimiento
            // 
            this.dateTimePickerFechaNacimiento.Location = new System.Drawing.Point(17, 93);
            this.dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            this.dateTimePickerFechaNacimiento.Size = new System.Drawing.Size(214, 23);
            this.dateTimePickerFechaNacimiento.TabIndex = 3;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(17, 75);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(119, 15);
            this.lblFechaNacimiento.TabIndex = 7;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // groupBoxEsFumador
            // 
            this.groupBoxEsFumador.Controls.Add(this.rbtnEsFumadorFalse);
            this.groupBoxEsFumador.Controls.Add(this.rbtnEsFumadorTrue);
            this.groupBoxEsFumador.Location = new System.Drawing.Point(17, 125);
            this.groupBoxEsFumador.Name = "groupBoxEsFumador";
            this.groupBoxEsFumador.Size = new System.Drawing.Size(108, 47);
            this.groupBoxEsFumador.TabIndex = 4;
            this.groupBoxEsFumador.TabStop = false;
            this.groupBoxEsFumador.Text = "¿Es Fumador/a?";
            // 
            // rbtnEsFumadorFalse
            // 
            this.rbtnEsFumadorFalse.AutoSize = true;
            this.rbtnEsFumadorFalse.Location = new System.Drawing.Point(46, 22);
            this.rbtnEsFumadorFalse.Name = "rbtnEsFumadorFalse";
            this.rbtnEsFumadorFalse.Size = new System.Drawing.Size(41, 19);
            this.rbtnEsFumadorFalse.TabIndex = 1;
            this.rbtnEsFumadorFalse.TabStop = true;
            this.rbtnEsFumadorFalse.Text = "No";
            this.rbtnEsFumadorFalse.UseVisualStyleBackColor = true;
            // 
            // rbtnEsFumadorTrue
            // 
            this.rbtnEsFumadorTrue.AutoSize = true;
            this.rbtnEsFumadorTrue.Location = new System.Drawing.Point(6, 22);
            this.rbtnEsFumadorTrue.Name = "rbtnEsFumadorTrue";
            this.rbtnEsFumadorTrue.Size = new System.Drawing.Size(34, 19);
            this.rbtnEsFumadorTrue.TabIndex = 0;
            this.rbtnEsFumadorTrue.TabStop = true;
            this.rbtnEsFumadorTrue.Text = "Si";
            this.rbtnEsFumadorTrue.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(18, 207);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // groupBoxEmpleado
            // 
            this.groupBoxEmpleado.Controls.Add(this.lblLegajo);
            this.groupBoxEmpleado.Controls.Add(this.txtNombre);
            this.groupBoxEmpleado.Controls.Add(this.groupBoxEsFumador);
            this.groupBoxEmpleado.Controls.Add(this.txtSueldo);
            this.groupBoxEmpleado.Controls.Add(this.lblFechaNacimiento);
            this.groupBoxEmpleado.Controls.Add(this.txtAltura);
            this.groupBoxEmpleado.Controls.Add(this.dateTimePickerFechaNacimiento);
            this.groupBoxEmpleado.Controls.Add(this.numericUpDownLegajo);
            this.groupBoxEmpleado.Location = new System.Drawing.Point(18, 12);
            this.groupBoxEmpleado.Name = "groupBoxEmpleado";
            this.groupBoxEmpleado.Size = new System.Drawing.Size(237, 189);
            this.groupBoxEmpleado.TabIndex = 0;
            this.groupBoxEmpleado.TabStop = false;
            this.groupBoxEmpleado.Text = "Empleado";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(99, 207);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(180, 207);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnDeseleccionar
            // 
            this.btnDeseleccionar.Location = new System.Drawing.Point(18, 236);
            this.btnDeseleccionar.Name = "btnDeseleccionar";
            this.btnDeseleccionar.Size = new System.Drawing.Size(237, 23);
            this.btnDeseleccionar.TabIndex = 10;
            this.btnDeseleccionar.Text = "Deseleccionar";
            this.btnDeseleccionar.UseVisualStyleBackColor = true;
            this.btnDeseleccionar.Click += new System.EventHandler(this.btnDeseleccionar_Click);
            // 
            // lstEmpleados
            // 
            this.lstEmpleados.FormattingEnabled = true;
            this.lstEmpleados.ItemHeight = 15;
            this.lstEmpleados.Location = new System.Drawing.Point(261, 12);
            this.lstEmpleados.Name = "lstEmpleados";
            this.lstEmpleados.Size = new System.Drawing.Size(759, 274);
            this.lstEmpleados.TabIndex = 14;
            this.lstEmpleados.DoubleClick += new System.EventHandler(this.lstEmpleados_DoubleClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(18, 263);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(237, 23);
            this.btnActualizar.TabIndex = 15;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnLeerTexto
            // 
            this.btnLeerTexto.Location = new System.Drawing.Point(459, 292);
            this.btnLeerTexto.Name = "btnLeerTexto";
            this.btnLeerTexto.Size = new System.Drawing.Size(75, 23);
            this.btnLeerTexto.TabIndex = 16;
            this.btnLeerTexto.Text = "Texto";
            this.btnLeerTexto.UseVisualStyleBackColor = true;
            this.btnLeerTexto.Click += new System.EventHandler(this.btnLeerTexto_Click);
            // 
            // btnGuardarTexto
            // 
            this.btnGuardarTexto.Location = new System.Drawing.Point(459, 321);
            this.btnGuardarTexto.Name = "btnGuardarTexto";
            this.btnGuardarTexto.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarTexto.TabIndex = 17;
            this.btnGuardarTexto.Text = "Texto";
            this.btnGuardarTexto.UseVisualStyleBackColor = true;
            this.btnGuardarTexto.Click += new System.EventHandler(this.btnGuardarTexto_Click);
            // 
            // btnLeerXML
            // 
            this.btnLeerXML.Location = new System.Drawing.Point(559, 292);
            this.btnLeerXML.Name = "btnLeerXML";
            this.btnLeerXML.Size = new System.Drawing.Size(75, 23);
            this.btnLeerXML.TabIndex = 18;
            this.btnLeerXML.Text = "XML";
            this.btnLeerXML.UseVisualStyleBackColor = true;
            this.btnLeerXML.Click += new System.EventHandler(this.btnLeerXML_Click);
            // 
            // btnGuardarXML
            // 
            this.btnGuardarXML.Location = new System.Drawing.Point(559, 321);
            this.btnGuardarXML.Name = "btnGuardarXML";
            this.btnGuardarXML.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarXML.TabIndex = 19;
            this.btnGuardarXML.Text = "XML";
            this.btnGuardarXML.UseVisualStyleBackColor = true;
            this.btnGuardarXML.Click += new System.EventHandler(this.btnGuardarXML_Click);
            // 
            // btnLeerJSON
            // 
            this.btnLeerJSON.Location = new System.Drawing.Point(661, 292);
            this.btnLeerJSON.Name = "btnLeerJSON";
            this.btnLeerJSON.Size = new System.Drawing.Size(75, 23);
            this.btnLeerJSON.TabIndex = 20;
            this.btnLeerJSON.Text = "JSON";
            this.btnLeerJSON.UseVisualStyleBackColor = true;
            this.btnLeerJSON.Click += new System.EventHandler(this.btnLeerJSON_Click);
            // 
            // btnGuardarJSON
            // 
            this.btnGuardarJSON.Location = new System.Drawing.Point(661, 321);
            this.btnGuardarJSON.Name = "btnGuardarJSON";
            this.btnGuardarJSON.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarJSON.TabIndex = 21;
            this.btnGuardarJSON.Text = "JSON";
            this.btnGuardarJSON.UseVisualStyleBackColor = true;
            this.btnGuardarJSON.Click += new System.EventHandler(this.btnGuardarJSON_Click);
            // 
            // btnLeerBinario
            // 
            this.btnLeerBinario.Location = new System.Drawing.Point(754, 292);
            this.btnLeerBinario.Name = "btnLeerBinario";
            this.btnLeerBinario.Size = new System.Drawing.Size(75, 23);
            this.btnLeerBinario.TabIndex = 22;
            this.btnLeerBinario.Text = "Binario";
            this.btnLeerBinario.UseVisualStyleBackColor = true;
            this.btnLeerBinario.Click += new System.EventHandler(this.btnLeerBinario_Click);
            // 
            // btnGuardarBinario
            // 
            this.btnGuardarBinario.Location = new System.Drawing.Point(754, 321);
            this.btnGuardarBinario.Name = "btnGuardarBinario";
            this.btnGuardarBinario.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarBinario.TabIndex = 23;
            this.btnGuardarBinario.Text = "Binario";
            this.btnGuardarBinario.UseVisualStyleBackColor = true;
            this.btnGuardarBinario.Click += new System.EventHandler(this.btnGuardarBinario_Click);
            // 
            // lblLeer
            // 
            this.lblLeer.AutoSize = true;
            this.lblLeer.Location = new System.Drawing.Point(382, 296);
            this.lblLeer.Name = "lblLeer";
            this.lblLeer.Size = new System.Drawing.Size(29, 15);
            this.lblLeer.TabIndex = 24;
            this.lblLeer.Text = "Leer";
            // 
            // lblGuardar
            // 
            this.lblGuardar.AutoSize = true;
            this.lblGuardar.Location = new System.Drawing.Point(382, 329);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(49, 15);
            this.lblGuardar.TabIndex = 25;
            this.lblGuardar.Text = "Guardar";
            // 
            // CRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 364);
            this.Controls.Add(this.lblGuardar);
            this.Controls.Add(this.lblLeer);
            this.Controls.Add(this.btnGuardarBinario);
            this.Controls.Add(this.btnLeerBinario);
            this.Controls.Add(this.btnGuardarJSON);
            this.Controls.Add(this.btnLeerJSON);
            this.Controls.Add(this.btnGuardarXML);
            this.Controls.Add(this.btnLeerXML);
            this.Controls.Add(this.btnGuardarTexto);
            this.Controls.Add(this.btnLeerTexto);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lstEmpleados);
            this.Controls.Add(this.btnDeseleccionar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.groupBoxEmpleado);
            this.Controls.Add(this.btnAgregar);
            this.Name = "CRUD";
            this.Text = "CRUD";
            this.Load += new System.EventHandler(this.CRUD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLegajo)).EndInit();
            this.groupBoxEsFumador.ResumeLayout(false);
            this.groupBoxEsFumador.PerformLayout();
            this.groupBoxEmpleado.ResumeLayout(false);
            this.groupBoxEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.NumericUpDown numericUpDownLegajo;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNacimiento;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.GroupBox groupBoxEsFumador;
        private System.Windows.Forms.RadioButton rbtnEsFumadorFalse;
        private System.Windows.Forms.RadioButton rbtnEsFumadorTrue;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox groupBoxEmpleado;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDeseleccionar;
        private System.Windows.Forms.ListBox lstEmpleados;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLeerTexto;
        private System.Windows.Forms.Button btnGuardarTexto;
        private System.Windows.Forms.Button btnLeerXML;
        private System.Windows.Forms.Button btnGuardarXML;
        private System.Windows.Forms.Button btnLeerJSON;
        private System.Windows.Forms.Button btnGuardarJSON;
        private System.Windows.Forms.Button btnLeerBinario;
        private System.Windows.Forms.Button btnGuardarBinario;
        private System.Windows.Forms.Label lblLeer;
        private System.Windows.Forms.Label lblGuardar;
    }
}
