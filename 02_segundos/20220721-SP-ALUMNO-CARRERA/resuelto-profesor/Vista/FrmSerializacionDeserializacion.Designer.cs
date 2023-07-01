namespace Vista
{
    partial class FrmSerializacionDeserializacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_deserializar = new System.Windows.Forms.Button();
            this.lb_mensaje = new System.Windows.Forms.Label();
            this.dt_informacion = new System.Windows.Forms.DataGridView();
            this.lb_seccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dt_informacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_deserializar
            // 
            this.btn_deserializar.Location = new System.Drawing.Point(63, 94);
            this.btn_deserializar.Name = "btn_deserializar";
            this.btn_deserializar.Size = new System.Drawing.Size(664, 41);
            this.btn_deserializar.TabIndex = 1;
            this.btn_deserializar.Text = "Deserializar archivo";
            this.btn_deserializar.UseVisualStyleBackColor = true;
            this.btn_deserializar.Click += new System.EventHandler(this.btn_deserializar_Click);
            // 
            // lb_mensaje
            // 
            this.lb_mensaje.AutoSize = true;
            this.lb_mensaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_mensaje.Location = new System.Drawing.Point(63, 429);
            this.lb_mensaje.Name = "lb_mensaje";
            this.lb_mensaje.Size = new System.Drawing.Size(88, 21);
            this.lb_mensaje.TabIndex = 2;
            this.lb_mensaje.Text = "lb_mensaje";
            this.lb_mensaje.Visible = false;
            // 
            // dt_informacion
            // 
            this.dt_informacion.AllowUserToAddRows = false;
            this.dt_informacion.AllowUserToDeleteRows = false;
            this.dt_informacion.AllowUserToResizeColumns = false;
            this.dt_informacion.AllowUserToResizeRows = false;
            this.dt_informacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_informacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_informacion.Location = new System.Drawing.Point(63, 141);
            this.dt_informacion.Name = "dt_informacion";
            this.dt_informacion.RowHeadersVisible = false;
            this.dt_informacion.RowTemplate.Height = 25;
            this.dt_informacion.Size = new System.Drawing.Size(664, 264);
            this.dt_informacion.TabIndex = 3;
            // 
            // lb_seccion
            // 
            this.lb_seccion.AutoSize = true;
            this.lb_seccion.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_seccion.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_seccion.Location = new System.Drawing.Point(178, 9);
            this.lb_seccion.Name = "lb_seccion";
            this.lb_seccion.Size = new System.Drawing.Size(433, 37);
            this.lb_seccion.TabIndex = 4;
            this.lb_seccion.Text = "Serializacion, Generics y Delegados";
            // 
            // FrmSerializacionDeserializacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.lb_seccion);
            this.Controls.Add(this.dt_informacion);
            this.Controls.Add(this.lb_mensaje);
            this.Controls.Add(this.btn_deserializar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmSerializacionDeserializacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSerializacionDeserializacion";
            this.Load += new System.EventHandler(this.FrmSerializacionDeserializacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_informacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_deserializar;
        private System.Windows.Forms.Label lb_mensaje;
        private System.Windows.Forms.DataGridView dt_informacion;
        private System.Windows.Forms.Label lb_seccion;
    }
}