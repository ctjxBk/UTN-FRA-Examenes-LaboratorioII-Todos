namespace Visual
{
    partial class Visual
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
            this.rtb_oferta = new System.Windows.Forms.RichTextBox();
            this.btn_MostrarOfertas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb_oferta
            // 
            this.rtb_oferta.Location = new System.Drawing.Point(12, 21);
            this.rtb_oferta.Name = "rtb_oferta";
            this.rtb_oferta.Size = new System.Drawing.Size(776, 360);
            this.rtb_oferta.TabIndex = 0;
            this.rtb_oferta.Text = "";
            // 
            // btn_MostrarOfertas
            // 
            this.btn_MostrarOfertas.Location = new System.Drawing.Point(628, 387);
            this.btn_MostrarOfertas.Name = "btn_MostrarOfertas";
            this.btn_MostrarOfertas.Size = new System.Drawing.Size(160, 51);
            this.btn_MostrarOfertas.TabIndex = 1;
            this.btn_MostrarOfertas.Text = "Mostrar Ofertas";
            this.btn_MostrarOfertas.UseVisualStyleBackColor = true;
            this.btn_MostrarOfertas.Click += new System.EventHandler(this.btn_MostrarOfertas_Click);
            // 
            // Visual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_MostrarOfertas);
            this.Controls.Add(this.rtb_oferta);
            this.Name = "Visual";
            this.Text = "Tienda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Visual_FormClosing);
            this.Load += new System.EventHandler(this.Visual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_oferta;
        private System.Windows.Forms.Button btn_MostrarOfertas;
    }
}
