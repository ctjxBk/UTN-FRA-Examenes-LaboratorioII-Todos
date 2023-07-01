namespace Vista
{
    partial class FormularioPrincipal
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
            this.btn_SerializacionDeserializacion = new System.Windows.Forms.Button();
            this.btn_BaseDeDatos = new System.Windows.Forms.Button();
            this.btn_multiHilo = new System.Windows.Forms.Button();
            this.btn_eventos = new System.Windows.Forms.Button();
            this.lb_seccion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_SerializacionDeserializacion
            // 
            this.btn_SerializacionDeserializacion.Location = new System.Drawing.Point(311, 92);
            this.btn_SerializacionDeserializacion.Name = "btn_SerializacionDeserializacion";
            this.btn_SerializacionDeserializacion.Size = new System.Drawing.Size(179, 87);
            this.btn_SerializacionDeserializacion.TabIndex = 0;
            this.btn_SerializacionDeserializacion.Text = "Serialización,\r\nGenerics\r\ny\r\nDelegados\r\n";
            this.btn_SerializacionDeserializacion.UseVisualStyleBackColor = true;
            this.btn_SerializacionDeserializacion.Click += new System.EventHandler(this.btn_SerializacionDeserializacion_Click);
            // 
            // btn_BaseDeDatos
            // 
            this.btn_BaseDeDatos.Location = new System.Drawing.Point(56, 92);
            this.btn_BaseDeDatos.Name = "btn_BaseDeDatos";
            this.btn_BaseDeDatos.Size = new System.Drawing.Size(179, 87);
            this.btn_BaseDeDatos.TabIndex = 1;
            this.btn_BaseDeDatos.Text = "Base de Datos \r\ne\r\nInterfaces";
            this.btn_BaseDeDatos.UseVisualStyleBackColor = true;
            this.btn_BaseDeDatos.Click += new System.EventHandler(this.btn_BaseDeDatos_Click);
            // 
            // btn_multiHilo
            // 
            this.btn_multiHilo.Location = new System.Drawing.Point(56, 228);
            this.btn_multiHilo.Name = "btn_multiHilo";
            this.btn_multiHilo.Size = new System.Drawing.Size(179, 87);
            this.btn_multiHilo.TabIndex = 2;
            this.btn_multiHilo.Text = "Programacion multi hilo (task)";
            this.btn_multiHilo.UseVisualStyleBackColor = true;
            this.btn_multiHilo.Click += new System.EventHandler(this.btn_multiHilo_Click);
            // 
            // btn_eventos
            // 
            this.btn_eventos.Location = new System.Drawing.Point(311, 228);
            this.btn_eventos.Name = "btn_eventos";
            this.btn_eventos.Size = new System.Drawing.Size(179, 87);
            this.btn_eventos.TabIndex = 3;
            this.btn_eventos.Text = "Eventos";
            this.btn_eventos.UseVisualStyleBackColor = true;
            this.btn_eventos.Click += new System.EventHandler(this.btn_eventos_Click);
            // 
            // lb_seccion
            // 
            this.lb_seccion.AutoSize = true;
            this.lb_seccion.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_seccion.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_seccion.Location = new System.Drawing.Point(64, 9);
            this.lb_seccion.Name = "lb_seccion";
            this.lb_seccion.Size = new System.Drawing.Size(413, 37);
            this.lb_seccion.TabIndex = 6;
            this.lb_seccion.Text = "Segundo Parcial Lab II - C1- 2022";
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 335);
            this.Controls.Add(this.lb_seccion);
            this.Controls.Add(this.btn_eventos);
            this.Controls.Add(this.btn_multiHilo);
            this.Controls.Add(this.btn_BaseDeDatos);
            this.Controls.Add(this.btn_SerializacionDeserializacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormularioPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apellido.Nombre";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SerializacionDeserializacion;
        private System.Windows.Forms.Button btn_BaseDeDatos;
        private System.Windows.Forms.Button btn_multiHilo;
        private System.Windows.Forms.Button btn_eventos;
        private System.Windows.Forms.Label lb_seccion;
    }
}
