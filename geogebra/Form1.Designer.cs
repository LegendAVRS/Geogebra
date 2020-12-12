namespace geogebra
{
    partial class Form1
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
            this.picGrid = new System.Windows.Forms.PictureBox();
            this.picDot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDot)).BeginInit();
            this.SuspendLayout();
            // 
            // picGrid
            // 
            this.picGrid.Location = new System.Drawing.Point(1, 0);
            this.picGrid.Name = "picGrid";
            this.picGrid.Size = new System.Drawing.Size(193, 72);
            this.picGrid.TabIndex = 0;
            this.picGrid.TabStop = false;
            this.picGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseMove);
            // 
            // picDot
            // 
            this.picDot.Location = new System.Drawing.Point(1, 0);
            this.picDot.Name = "picDot";
            this.picDot.Size = new System.Drawing.Size(193, 72);
            this.picDot.TabIndex = 1;
            this.picDot.TabStop = false;
            this.picDot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDot_MouseMove);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(652, 385);
            this.Controls.Add(this.picDot);
            this.Controls.Add(this.picGrid);
            this.Name = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGrid;
        private System.Windows.Forms.PictureBox picDot;
    }
}

