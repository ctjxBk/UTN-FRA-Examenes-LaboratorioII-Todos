namespace Vista
{
    partial class SimuladorForm
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
            this.lblPoblacion = new System.Windows.Forms.Label();
            this.lblMicroorganismo = new System.Windows.Forms.Label();
            this.txtPoblacion = new System.Windows.Forms.TextBox();
            this.cmbMicroorganismo = new System.Windows.Forms.ComboBox();
            this.txtEvolucion = new System.Windows.Forms.RichTextBox();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPoblacion
            // 
            this.lblPoblacion.AutoSize = true;
            this.lblPoblacion.Location = new System.Drawing.Point(12, 9);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(110, 15);
            this.lblPoblacion.TabIndex = 0;
            this.lblPoblacion.Text = "Población a Evaluar";
            // 
            // lblMicroorganismo
            // 
            this.lblMicroorganismo.AutoSize = true;
            this.lblMicroorganismo.Location = new System.Drawing.Point(12, 47);
            this.lblMicroorganismo.Name = "lblMicroorganismo";
            this.lblMicroorganismo.Size = new System.Drawing.Size(95, 15);
            this.lblMicroorganismo.TabIndex = 1;
            this.lblMicroorganismo.Text = "Microorganimos";
            // 
            // txtPoblacion
            // 
            this.txtPoblacion.Location = new System.Drawing.Point(144, 6);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.Size = new System.Drawing.Size(121, 23);
            this.txtPoblacion.TabIndex = 2;
            // 
            // cmbMicroorganismo
            // 
            this.cmbMicroorganismo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMicroorganismo.FormattingEnabled = true;
            this.cmbMicroorganismo.Location = new System.Drawing.Point(144, 44);
            this.cmbMicroorganismo.Name = "cmbMicroorganismo";
            this.cmbMicroorganismo.Size = new System.Drawing.Size(121, 23);
            this.cmbMicroorganismo.TabIndex = 3;
            // 
            // txtEvolucion
            // 
            this.txtEvolucion.Location = new System.Drawing.Point(7, 111);
            this.txtEvolucion.Name = "txtEvolucion";
            this.txtEvolucion.Size = new System.Drawing.Size(781, 327);
            this.txtEvolucion.TabIndex = 4;
            this.txtEvolucion.Text = "";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(686, 71);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(102, 34);
            this.btnEjecutar.TabIndex = 5;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(577, 71);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 34);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // SimuladorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.txtEvolucion);
            this.Controls.Add(this.cmbMicroorganismo);
            this.Controls.Add(this.txtPoblacion);
            this.Controls.Add(this.lblMicroorganismo);
            this.Controls.Add(this.lblPoblacion);
            this.Name = "SimuladorForm";
            this.Text = "Simulador de Pandemia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimuladorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPoblacion;
        private System.Windows.Forms.Label lblMicroorganismo;
        private System.Windows.Forms.TextBox txtPoblacion;
        private System.Windows.Forms.ComboBox cmbMicroorganismo;
        private System.Windows.Forms.RichTextBox txtEvolucion;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
