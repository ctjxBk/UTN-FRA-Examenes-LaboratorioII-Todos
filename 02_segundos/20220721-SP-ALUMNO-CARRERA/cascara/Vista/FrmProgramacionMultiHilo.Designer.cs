namespace Vista
{
    partial class FrmProgramacionMultiHilo
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
            this.btn_cancelarCarga = new System.Windows.Forms.Button();
            this.dtg_listadoDeAlumnos = new System.Windows.Forms.DataGridView();
            this.btn_comenzarCarga = new System.Windows.Forms.Button();
            this.lb_seccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_listadoDeAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancelarCarga
            // 
            this.btn_cancelarCarga.Location = new System.Drawing.Point(388, 463);
            this.btn_cancelarCarga.Name = "btn_cancelarCarga";
            this.btn_cancelarCarga.Size = new System.Drawing.Size(277, 63);
            this.btn_cancelarCarga.TabIndex = 1;
            this.btn_cancelarCarga.Text = "Cancelar Carga Alumnos";
            this.btn_cancelarCarga.UseVisualStyleBackColor = true;
            this.btn_cancelarCarga.Click += new System.EventHandler(this.btn_cancelarCarga_Click);
            // 
            // dtg_listadoDeAlumnos
            // 
            this.dtg_listadoDeAlumnos.AllowUserToAddRows = false;
            this.dtg_listadoDeAlumnos.AllowUserToDeleteRows = false;
            this.dtg_listadoDeAlumnos.AllowUserToResizeColumns = false;
            this.dtg_listadoDeAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_listadoDeAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_listadoDeAlumnos.Location = new System.Drawing.Point(12, 101);
            this.dtg_listadoDeAlumnos.Name = "dtg_listadoDeAlumnos";
            this.dtg_listadoDeAlumnos.RowHeadersVisible = false;
            this.dtg_listadoDeAlumnos.RowTemplate.Height = 25;
            this.dtg_listadoDeAlumnos.Size = new System.Drawing.Size(653, 322);
            this.dtg_listadoDeAlumnos.TabIndex = 2;
            // 
            // btn_comenzarCarga
            // 
            this.btn_comenzarCarga.Location = new System.Drawing.Point(12, 463);
            this.btn_comenzarCarga.Name = "btn_comenzarCarga";
            this.btn_comenzarCarga.Size = new System.Drawing.Size(274, 63);
            this.btn_comenzarCarga.TabIndex = 3;
            this.btn_comenzarCarga.Text = "Comenzar carga Alumnos";
            this.btn_comenzarCarga.UseVisualStyleBackColor = true;
            this.btn_comenzarCarga.Click += new System.EventHandler(this.btn_comenzarCarga_Click);
            // 
            // lb_seccion
            // 
            this.lb_seccion.AutoSize = true;
            this.lb_seccion.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_seccion.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_seccion.Location = new System.Drawing.Point(119, 9);
            this.lb_seccion.Name = "lb_seccion";
            this.lb_seccion.Size = new System.Drawing.Size(393, 37);
            this.lb_seccion.TabIndex = 5;
            this.lb_seccion.Text = "Programación multihilos ( Task )\r\n";
            // 
            // FrmProgramacionMultiHilo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 544);
            this.Controls.Add(this.lb_seccion);
            this.Controls.Add(this.btn_comenzarCarga);
            this.Controls.Add(this.dtg_listadoDeAlumnos);
            this.Controls.Add(this.btn_cancelarCarga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmProgramacionMultiHilo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProgramacionMultiHilo";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_listadoDeAlumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_cancelarCarga;
        private System.Windows.Forms.DataGridView dtg_listadoDeAlumnos;
        private System.Windows.Forms.Button btn_comenzarCarga;
        private System.Windows.Forms.Label lb_seccion;
    }
}