
namespace _20210717_RSP___alumno
{
    partial class FrmCarrera
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarrera));
            this.imgListAutos = new System.Windows.Forms.ImageList(this.components);
            this.pcbAutoUno = new System.Windows.Forms.PictureBox();
            this.pcbAutoDos = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAutoUno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAutoDos)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListAutos
            // 
            this.imgListAutos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListAutos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListAutos.ImageStream")));
            this.imgListAutos.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListAutos.Images.SetKeyName(0, "auto_1.png");
            // 
            // pcbAutoUno
            // 
            this.pcbAutoUno.BackColor = System.Drawing.Color.Transparent;
            this.pcbAutoUno.Location = new System.Drawing.Point(12, 24);
            this.pcbAutoUno.Name = "pcbAutoUno";
            this.pcbAutoUno.Size = new System.Drawing.Size(128, 64);
            this.pcbAutoUno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbAutoUno.TabIndex = 0;
            this.pcbAutoUno.TabStop = false;
            // 
            // pcbAutoDos
            // 
            this.pcbAutoDos.BackColor = System.Drawing.Color.Transparent;
            this.pcbAutoDos.Location = new System.Drawing.Point(12, 109);
            this.pcbAutoDos.Name = "pcbAutoDos";
            this.pcbAutoDos.Size = new System.Drawing.Size(128, 64);
            this.pcbAutoDos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbAutoDos.TabIndex = 1;
            this.pcbAutoDos.TabStop = false;
            // 
            // FrmCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_20210717_RSP___alumno.Properties.Resources.pista;
            this.ClientSize = new System.Drawing.Size(854, 204);
            this.Controls.Add(this.pcbAutoDos);
            this.Controls.Add(this.pcbAutoUno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCarrera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Galvez";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCarrera_FormClosing);
            this.Load += new System.EventHandler(this.FrmCarrera_Load);
            this.Shown += new System.EventHandler(this.FrmCarrera_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAutoUno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAutoDos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListAutos;
        private System.Windows.Forms.PictureBox pcbAutoUno;
        private System.Windows.Forms.PictureBox pcbAutoDos;
    }
}