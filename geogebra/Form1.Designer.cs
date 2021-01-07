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
            this.rbtnCursor = new System.Windows.Forms.RadioButton();
            this.numDagiac = new System.Windows.Forms.NumericUpDown();
            this.rbtnDagiac = new System.Windows.Forms.RadioButton();
            this.rbtnLineCut = new System.Windows.Forms.RadioButton();
            this.rbtnLine = new System.Windows.Forms.RadioButton();
            this.cbtnRound = new System.Windows.Forms.CheckBox();
            this.cbtnShowDot = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCoord = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDagiac)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // picGrid
            // 
            this.picGrid.Location = new System.Drawing.Point(-2, -1);
            this.picGrid.Name = "picGrid";
            this.picGrid.Size = new System.Drawing.Size(544, 343);
            this.picGrid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGrid.TabIndex = 0;
            this.picGrid.TabStop = false;
            this.picGrid.Click += new System.EventHandler(this.picGrid_Click);
            this.picGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtnCursor);
            this.groupBox1.Controls.Add(this.numDagiac);
            this.groupBox1.Controls.Add(this.rbtnDagiac);
            this.groupBox1.Controls.Add(this.rbtnLineCut);
            this.groupBox1.Controls.Add(this.rbtnLine);
            this.groupBox1.Location = new System.Drawing.Point(758, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 170);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modes";
            // 
            // rbtnCursor
            // 
            this.rbtnCursor.AutoSize = true;
            this.rbtnCursor.Checked = true;
            this.rbtnCursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCursor.Location = new System.Drawing.Point(10, 21);
            this.rbtnCursor.Name = "rbtnCursor";
            this.rbtnCursor.Size = new System.Drawing.Size(81, 24);
            this.rbtnCursor.TabIndex = 4;
            this.rbtnCursor.TabStop = true;
            this.rbtnCursor.Text = "Cursor";
            this.rbtnCursor.UseVisualStyleBackColor = true;
            this.rbtnCursor.CheckedChanged += new System.EventHandler(this.rbtnCursor_CheckedChanged);
            // 
            // numDagiac
            // 
            this.numDagiac.Location = new System.Drawing.Point(9, 132);
            this.numDagiac.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numDagiac.Name = "numDagiac";
            this.numDagiac.Size = new System.Drawing.Size(120, 22);
            this.numDagiac.TabIndex = 3;
            this.numDagiac.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // rbtnDagiac
            // 
            this.rbtnDagiac.AutoSize = true;
            this.rbtnDagiac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDagiac.Location = new System.Drawing.Point(10, 102);
            this.rbtnDagiac.Name = "rbtnDagiac";
            this.rbtnDagiac.Size = new System.Drawing.Size(89, 24);
            this.rbtnDagiac.TabIndex = 2;
            this.rbtnDagiac.TabStop = true;
            this.rbtnDagiac.Text = "Polygon";
            this.rbtnDagiac.UseVisualStyleBackColor = true;
            this.rbtnDagiac.CheckedChanged += new System.EventHandler(this.rbtnDagiac_CheckedChanged);
            // 
            // rbtnLineCut
            // 
            this.rbtnLineCut.AutoSize = true;
            this.rbtnLineCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnLineCut.Location = new System.Drawing.Point(10, 75);
            this.rbtnLineCut.Name = "rbtnLineCut";
            this.rbtnLineCut.Size = new System.Drawing.Size(90, 24);
            this.rbtnLineCut.TabIndex = 1;
            this.rbtnLineCut.TabStop = true;
            this.rbtnLineCut.Text = "Line cut";
            this.rbtnLineCut.UseVisualStyleBackColor = true;
            this.rbtnLineCut.CheckedChanged += new System.EventHandler(this.rbtnLineCut_CheckedChanged);
            // 
            // rbtnLine
            // 
            this.rbtnLine.AutoSize = true;
            this.rbtnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnLine.Location = new System.Drawing.Point(10, 48);
            this.rbtnLine.Name = "rbtnLine";
            this.rbtnLine.Size = new System.Drawing.Size(62, 24);
            this.rbtnLine.TabIndex = 0;
            this.rbtnLine.TabStop = true;
            this.rbtnLine.Text = "Line";
            this.rbtnLine.UseVisualStyleBackColor = true;
            this.rbtnLine.CheckedChanged += new System.EventHandler(this.rbtnLine_CheckedChanged);
            // 
            // cbtnRound
            // 
            this.cbtnRound.AutoSize = true;
            this.cbtnRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtnRound.Location = new System.Drawing.Point(10, 21);
            this.cbtnRound.Name = "cbtnRound";
            this.cbtnRound.Size = new System.Drawing.Size(79, 24);
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
            this.cbtnShowDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtnShowDot.Location = new System.Drawing.Point(10, 48);
            this.cbtnShowDot.Name = "cbtnShowDot";
            this.cbtnShowDot.Size = new System.Drawing.Size(109, 24);
            this.cbtnShowDot.TabIndex = 3;
            this.cbtnShowDot.Text = "Show dots";
            this.cbtnShowDot.UseVisualStyleBackColor = true;
            this.cbtnShowDot.CheckedChanged += new System.EventHandler(this.cbtnShowDot_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.cbtnRound);
            this.groupBox2.Controls.Add(this.cbtnShowDot);
            this.groupBox2.Location = new System.Drawing.Point(758, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferences";
            // 
            // lblCoord
            // 
            this.lblCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCoord.AutoSize = true;
            this.lblCoord.Location = new System.Drawing.Point(12, 461);
            this.lblCoord.Name = "lblCoord";
            this.lblCoord.Size = new System.Drawing.Size(46, 17);
            this.lblCoord.TabIndex = 5;
            this.lblCoord.Text = "label1";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblData);
            this.groupBox3.Location = new System.Drawing.Point(758, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(122, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(6, 18);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(20, 18);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "...";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(888, 487);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblCoord);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDagiac)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.RadioButton rbtnCursor;
        private System.Windows.Forms.Label lblCoord;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblData;
    }
}

