namespace Atencion
{
    partial class FrmAtencion
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
            this.lstMedicos = new System.Windows.Forms.ListBox();
            this.lblMedicos = new System.Windows.Forms.Label();
            this.lblPacientes = new System.Windows.Forms.Label();
            this.lstPacientes = new System.Windows.Forms.ListBox();
            this.rtbInfoMedico = new System.Windows.Forms.RichTextBox();
            this.btnAtender = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMedicos
            // 
            this.lstMedicos.FormattingEnabled = true;
            this.lstMedicos.ItemHeight = 15;
            this.lstMedicos.Location = new System.Drawing.Point(12, 27);
            this.lstMedicos.Name = "lstMedicos";
            this.lstMedicos.Size = new System.Drawing.Size(225, 259);
            this.lstMedicos.TabIndex = 0;
            this.lstMedicos.SelectedIndexChanged += new System.EventHandler(this.lstMedicos_SelectedIndexChanged);
            // 
            // lblMedicos
            // 
            this.lblMedicos.AutoSize = true;
            this.lblMedicos.Location = new System.Drawing.Point(12, 9);
            this.lblMedicos.Name = "lblMedicos";
            this.lblMedicos.Size = new System.Drawing.Size(95, 15);
            this.lblMedicos.TabIndex = 1;
            this.lblMedicos.Text = "Personal médico";
            // 
            // lblPacientes
            // 
            this.lblPacientes.AutoSize = true;
            this.lblPacientes.Location = new System.Drawing.Point(243, 9);
            this.lblPacientes.Name = "lblPacientes";
            this.lblPacientes.Size = new System.Drawing.Size(57, 15);
            this.lblPacientes.TabIndex = 3;
            this.lblPacientes.Text = "Pacientes";
            // 
            // lstPacientes
            // 
            this.lstPacientes.FormattingEnabled = true;
            this.lstPacientes.ItemHeight = 15;
            this.lstPacientes.Location = new System.Drawing.Point(243, 27);
            this.lstPacientes.Name = "lstPacientes";
            this.lstPacientes.Size = new System.Drawing.Size(225, 259);
            this.lstPacientes.TabIndex = 2;
            // 
            // rtbInfoMedico
            // 
            this.rtbInfoMedico.Location = new System.Drawing.Point(12, 292);
            this.rtbInfoMedico.Name = "rtbInfoMedico";
            this.rtbInfoMedico.Size = new System.Drawing.Size(456, 172);
            this.rtbInfoMedico.TabIndex = 4;
            this.rtbInfoMedico.Text = "";
            // 
            // btnAtender
            // 
            this.btnAtender.Location = new System.Drawing.Point(474, 27);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(125, 51);
            this.btnAtender.TabIndex = 5;
            this.btnAtender.Text = "Atender";
            this.btnAtender.UseVisualStyleBackColor = true;
            this.btnAtender.Click += new System.EventHandler(this.btnAtender_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(474, 413);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(125, 51);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 476);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAtender);
            this.Controls.Add(this.rtbInfoMedico);
            this.Controls.Add(this.lblPacientes);
            this.Controls.Add(this.lstPacientes);
            this.Controls.Add(this.lblMedicos);
            this.Controls.Add(this.lstMedicos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAtencion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atención de pacientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAtencion_FormClosing);
            this.Load += new System.EventHandler(this.FrmAtencion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMedicos;
        private System.Windows.Forms.Label lblMedicos;
        private System.Windows.Forms.Label lblPacientes;
        private System.Windows.Forms.ListBox lstPacientes;
        private System.Windows.Forms.RichTextBox rtbInfoMedico;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.Button btnSalir;
    }
}
