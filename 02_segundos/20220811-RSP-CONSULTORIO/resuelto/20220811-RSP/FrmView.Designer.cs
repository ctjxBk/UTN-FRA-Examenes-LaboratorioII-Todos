namespace _20220811_RSP
{
    partial class FrmView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmView));
            this.lblTitlePaciente = new System.Windows.Forms.Label();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.lblTitleTiempo = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblTma = new System.Windows.Forms.Label();
            this.lblTitleTma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAtendidos = new System.Windows.Forms.ListBox();
            this.grpbProximoPaciente = new System.Windows.Forms.GroupBox();
            this.grpbProximoPaciente.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitlePaciente
            // 
            this.lblTitlePaciente.AutoSize = true;
            this.lblTitlePaciente.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitlePaciente.Location = new System.Drawing.Point(24, 30);
            this.lblTitlePaciente.Name = "lblTitlePaciente";
            this.lblTitlePaciente.Size = new System.Drawing.Size(163, 32);
            this.lblTitlePaciente.TabIndex = 0;
            this.lblTitlePaciente.Text = "Atendiendo a:";
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblNombrePaciente.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNombrePaciente.Location = new System.Drawing.Point(181, 30);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(121, 32);
            this.lblNombrePaciente.TabIndex = 1;
            this.lblNombrePaciente.Text = "esperando";
            // 
            // lblTitleTiempo
            // 
            this.lblTitleTiempo.AutoSize = true;
            this.lblTitleTiempo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleTiempo.Location = new System.Drawing.Point(24, 82);
            this.lblTitleTiempo.Name = "lblTitleTiempo";
            this.lblTitleTiempo.Size = new System.Drawing.Size(100, 32);
            this.lblTitleTiempo.TabIndex = 2;
            this.lblTitleTiempo.Text = "Tiempo:";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTiempo.Location = new System.Drawing.Point(119, 82);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(87, 32);
            this.lblTiempo.TabIndex = 3;
            this.lblTiempo.Text = "tiempo";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrir.FlatAppearance.BorderSize = 0;
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.Image = global::_20220811_RSP.Properties.Resources.open;
            this.btnAbrir.Location = new System.Drawing.Point(316, 448);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(64, 64);
            this.btnAbrir.TabIndex = 4;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = global::_20220811_RSP.Properties.Resources.next;
            this.btnSiguiente.Location = new System.Drawing.Point(15, 16);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(96, 96);
            this.btnSiguiente.TabIndex = 5;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblTma
            // 
            this.lblTma.AutoSize = true;
            this.lblTma.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTma.Location = new System.Drawing.Point(527, 69);
            this.lblTma.Name = "lblTma";
            this.lblTma.Size = new System.Drawing.Size(286, 32);
            this.lblTma.TabIndex = 7;
            this.lblTma.Text = "tiempo medio de atencion";
            // 
            // lblTitleTma
            // 
            this.lblTitleTma.AutoSize = true;
            this.lblTitleTma.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleTma.Location = new System.Drawing.Point(527, 37);
            this.lblTitleTma.Name = "lblTitleTma";
            this.lblTitleTma.Size = new System.Drawing.Size(308, 32);
            this.lblTitleTma.TabIndex = 6;
            this.lblTitleTma.Text = "Tiempo medio de atencion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pacientes atendidos:";
            // 
            // lstAtendidos
            // 
            this.lstAtendidos.Enabled = false;
            this.lstAtendidos.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstAtendidos.ForeColor = System.Drawing.Color.Red;
            this.lstAtendidos.FormattingEnabled = true;
            this.lstAtendidos.ItemHeight = 28;
            this.lstAtendidos.Location = new System.Drawing.Point(24, 192);
            this.lstAtendidos.Name = "lstAtendidos";
            this.lstAtendidos.Size = new System.Drawing.Size(267, 312);
            this.lstAtendidos.TabIndex = 10;
            // 
            // grpbProximoPaciente
            // 
            this.grpbProximoPaciente.Controls.Add(this.btnSiguiente);
            this.grpbProximoPaciente.Location = new System.Drawing.Point(696, 394);
            this.grpbProximoPaciente.Name = "grpbProximoPaciente";
            this.grpbProximoPaciente.Size = new System.Drawing.Size(117, 118);
            this.grpbProximoPaciente.TabIndex = 12;
            this.grpbProximoPaciente.TabStop = false;
            this.grpbProximoPaciente.Text = "Proximo Paciente";
            // 
            // FrmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::_20220811_RSP.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(843, 516);
            this.Controls.Add(this.grpbProximoPaciente);
            this.Controls.Add(this.lstAtendidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTma);
            this.Controls.Add(this.lblTitleTma);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblTitleTiempo);
            this.Controls.Add(this.lblNombrePaciente);
            this.Controls.Add(this.lblTitlePaciente);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultorio";
            this.Load += new System.EventHandler(this.FrmView_Load);
            this.grpbProximoPaciente.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitlePaciente;
        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.Label lblTitleTiempo;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblTma;
        private System.Windows.Forms.Label lblTitleTma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAtendidos;
        private System.Windows.Forms.GroupBox grpbProximoPaciente;
    }
}
