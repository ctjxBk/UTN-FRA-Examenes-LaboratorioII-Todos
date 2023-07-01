
namespace Vista
{
    partial class Circo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Circo));
            this.clown = new System.Windows.Forms.PictureBox();
            this.balloon1 = new System.Windows.Forms.PictureBox();
            this.balloon5 = new System.Windows.Forms.PictureBox();
            this.balloon3 = new System.Windows.Forms.PictureBox();
            this.balloon4 = new System.Windows.Forms.PictureBox();
            this.balloon2 = new System.Windows.Forms.PictureBox();
            this.btnFlotar = new System.Windows.Forms.Button();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon2)).BeginInit();
            this.SuspendLayout();
            // 
            // clown
            // 
            this.clown.Image = ((System.Drawing.Image)(resources.GetObject("clown.Image")));
            this.clown.Location = new System.Drawing.Point(107, 231);
            this.clown.Name = "clown";
            this.clown.Size = new System.Drawing.Size(399, 251);
            this.clown.TabIndex = 0;
            this.clown.TabStop = false;
            // 
            // balloon1
            // 
            this.balloon1.Image = ((System.Drawing.Image)(resources.GetObject("balloon1.Image")));
            this.balloon1.Location = new System.Drawing.Point(11, 231);
            this.balloon1.Name = "balloon1";
            this.balloon1.Size = new System.Drawing.Size(90, 124);
            this.balloon1.TabIndex = 1;
            this.balloon1.TabStop = false;
            this.balloon1.Visible = false;
            // 
            // balloon5
            // 
            this.balloon5.Image = ((System.Drawing.Image)(resources.GetObject("balloon5.Image")));
            this.balloon5.Location = new System.Drawing.Point(512, 231);
            this.balloon5.Name = "balloon5";
            this.balloon5.Size = new System.Drawing.Size(90, 124);
            this.balloon5.TabIndex = 2;
            this.balloon5.TabStop = false;
            this.balloon5.Visible = false;
            // 
            // balloon3
            // 
            this.balloon3.Image = ((System.Drawing.Image)(resources.GetObject("balloon3.Image")));
            this.balloon3.Location = new System.Drawing.Point(264, 101);
            this.balloon3.Name = "balloon3";
            this.balloon3.Size = new System.Drawing.Size(90, 124);
            this.balloon3.TabIndex = 3;
            this.balloon3.TabStop = false;
            this.balloon3.Visible = false;
            // 
            // balloon4
            // 
            this.balloon4.Image = ((System.Drawing.Image)(resources.GetObject("balloon4.Image")));
            this.balloon4.Location = new System.Drawing.Point(416, 101);
            this.balloon4.Name = "balloon4";
            this.balloon4.Size = new System.Drawing.Size(90, 124);
            this.balloon4.TabIndex = 4;
            this.balloon4.TabStop = false;
            this.balloon4.Visible = false;
            // 
            // balloon2
            // 
            this.balloon2.Image = ((System.Drawing.Image)(resources.GetObject("balloon2.Image")));
            this.balloon2.Location = new System.Drawing.Point(107, 101);
            this.balloon2.Name = "balloon2";
            this.balloon2.Size = new System.Drawing.Size(90, 124);
            this.balloon2.TabIndex = 5;
            this.balloon2.TabStop = false;
            this.balloon2.Visible = false;
            // 
            // btnFlotar
            // 
            this.btnFlotar.Location = new System.Drawing.Point(512, 48);
            this.btnFlotar.Name = "btnFlotar";
            this.btnFlotar.Size = new System.Drawing.Size(90, 47);
            this.btnFlotar.TabIndex = 6;
            this.btnFlotar.Text = "Flotar";
            this.btnFlotar.UseVisualStyleBackColor = true;
            this.btnFlotar.Click += new System.EventHandler(this.btnFlotar_Click);
            // 
            // btnSerializar
            // 
            this.btnSerializar.Location = new System.Drawing.Point(264, 48);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(90, 47);
            this.btnSerializar.TabIndex = 7;
            this.btnSerializar.Text = "Serializar";
            this.btnSerializar.UseVisualStyleBackColor = true;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(11, 48);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 47);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Circo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 483);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSerializar);
            this.Controls.Add(this.btnFlotar);
            this.Controls.Add(this.balloon2);
            this.Controls.Add(this.balloon4);
            this.Controls.Add(this.balloon3);
            this.Controls.Add(this.balloon5);
            this.Controls.Add(this.balloon1);
            this.Controls.Add(this.clown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Circo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circo";
            this.Load += new System.EventHandler(this.Circo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balloon2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox clown;
        private System.Windows.Forms.PictureBox balloon1;
        private System.Windows.Forms.PictureBox balloon5;
        private System.Windows.Forms.PictureBox balloon3;
        private System.Windows.Forms.PictureBox balloon4;
        private System.Windows.Forms.PictureBox balloon2;
        private System.Windows.Forms.Button btnFlotar;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.Button btnSalir;
    }
}