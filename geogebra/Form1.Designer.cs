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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnDagiac = new System.Windows.Forms.RadioButton();
            this.rbtnLineCut = new System.Windows.Forms.RadioButton();
            this.rbtnLine = new System.Windows.Forms.RadioButton();
            this.cbtnRound = new System.Windows.Forms.CheckBox();
            this.cbtnShowDot = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numDagiac = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDagiac)).BeginInit();
            this.SuspendLayout();
            // 
            // picGrid
            // 
            this.picGrid.Location = new System.Drawing.Point(-2, -1);
            this.picGrid.Name = "picGrid";
            this.picGrid.Size = new System.Drawing.Size(655, 385);
            this.picGrid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGrid.TabIndex = 0;
            this.picGrid.TabStop = false;
            this.picGrid.Click += new System.EventHandler(this.picGrid_Click);
            this.picGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numDagiac);
            this.groupBox1.Controls.Add(this.rbtnDagiac);
            this.groupBox1.Controls.Add(this.rbtnLineCut);
            this.groupBox1.Controls.Add(this.rbtnLine);
            this.groupBox1.Location = new System.Drawing.Point(652, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 143);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rbtnDagiac
            // 
            this.rbtnDagiac.AutoSize = true;
            this.rbtnDagiac.Location = new System.Drawing.Point(6, 86);
            this.rbtnDagiac.Name = "rbtnDagiac";
            this.rbtnDagiac.Size = new System.Drawing.Size(77, 21);
            this.rbtnDagiac.TabIndex = 2;
            this.rbtnDagiac.TabStop = true;
            this.rbtnDagiac.Text = "Da giac";
            this.rbtnDagiac.UseVisualStyleBackColor = true;
            this.rbtnDagiac.CheckedChanged += new System.EventHandler(this.rbtnDagiac_CheckedChanged);
            // 
            // rbtnLineCut
            // 
            this.rbtnLineCut.AutoSize = true;
            this.rbtnLineCut.Location = new System.Drawing.Point(6, 59);
            this.rbtnLineCut.Name = "rbtnLineCut";
            this.rbtnLineCut.Size = new System.Drawing.Size(79, 21);
            this.rbtnLineCut.TabIndex = 1;
            this.rbtnLineCut.TabStop = true;
            this.rbtnLineCut.Text = "Line cut";
            this.rbtnLineCut.UseVisualStyleBackColor = true;
            this.rbtnLineCut.CheckedChanged += new System.EventHandler(this.rbtnLineCut_CheckedChanged);
            // 
            // rbtnLine
            // 
            this.rbtnLine.AutoSize = true;
            this.rbtnLine.Location = new System.Drawing.Point(6, 31);
            this.rbtnLine.Name = "rbtnLine";
            this.rbtnLine.Size = new System.Drawing.Size(56, 21);
            this.rbtnLine.TabIndex = 0;
            this.rbtnLine.TabStop = true;
            this.rbtnLine.Text = "Line";
            this.rbtnLine.UseVisualStyleBackColor = true;
            this.rbtnLine.CheckedChanged += new System.EventHandler(this.rbtnLine_CheckedChanged);
            // 
            // cbtnRound
            // 
            this.cbtnRound.AutoSize = true;
            this.cbtnRound.Location = new System.Drawing.Point(10, 21);
            this.cbtnRound.Name = "cbtnRound";
            this.cbtnRound.Size = new System.Drawing.Size(72, 21);
            this.cbtnRound.TabIndex = 2;
            this.cbtnRound.Text = "Round";
            this.cbtnRound.UseVisualStyleBackColor = true;
            this.cbtnRound.CheckedChanged += new System.EventHandler(this.cbtnRound_CheckedChanged);
            // 
            // cbtnShowDot
            // 
            this.cbtnShowDot.AutoSize = true;
            this.cbtnShowDot.Checked = true;
            this.cbtnShowDot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbtnShowDot.Location = new System.Drawing.Point(10, 48);
            this.cbtnShowDot.Name = "cbtnShowDot";
            this.cbtnShowDot.Size = new System.Drawing.Size(95, 21);
            this.cbtnShowDot.TabIndex = 3;
            this.cbtnShowDot.Text = "Show dots";
            this.cbtnShowDot.UseVisualStyleBackColor = true;
            this.cbtnShowDot.CheckedChanged += new System.EventHandler(this.cbtnShowDot_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbtnRound);
            this.groupBox2.Controls.Add(this.cbtnShowDot);
            this.groupBox2.Location = new System.Drawing.Point(652, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // numDagiac
            // 
            this.numDagiac.Location = new System.Drawing.Point(6, 114);
            this.numDagiac.Name = "numDagiac";
            this.numDagiac.Size = new System.Drawing.Size(120, 22);
            this.numDagiac.TabIndex = 3;
            this.numDagiac.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(780, 467);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picGrid);
            this.Name = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDagiac)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnDagiac;
        private System.Windows.Forms.RadioButton rbtnLineCut;
        private System.Windows.Forms.RadioButton rbtnLine;
        private System.Windows.Forms.CheckBox cbtnRound;
        private System.Windows.Forms.CheckBox cbtnShowDot;
        private System.Windows.Forms.NumericUpDown numDagiac;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

