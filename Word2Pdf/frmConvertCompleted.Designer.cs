namespace Word2Pdf
{
    partial class frmConvertCompleted
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertCompleted));
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpenFileLocation = new ReaLTaiizor.Controls.Button();
            this.btnCancel = new ReaLTaiizor.Controls.Button();
            this.btnOpenPDF = new ReaLTaiizor.Controls.Button();
            this.lblOpenProgress = new ReaLTaiizor.Controls.BigLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bigLabel1.Location = new System.Drawing.Point(31, 23);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(700, 38);
            this.bigLabel1.TabIndex = 0;
            this.bigLabel1.Text = "Word file has been converted to PDF successfully.";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Word2Pdf.Properties.Resources._128__1__35963;
            this.pictureBox5.Location = new System.Drawing.Point(302, 73);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(167, 163);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(737, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpenFileLocation
            // 
            this.btnOpenFileLocation.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenFileLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnOpenFileLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFileLocation.EnteredBorderColor = System.Drawing.Color.Blue;
            this.btnOpenFileLocation.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnOpenFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOpenFileLocation.Image = null;
            this.btnOpenFileLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFileLocation.InactiveColor = System.Drawing.Color.Navy;
            this.btnOpenFileLocation.Location = new System.Drawing.Point(302, 336);
            this.btnOpenFileLocation.Name = "btnOpenFileLocation";
            this.btnOpenFileLocation.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnOpenFileLocation.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnOpenFileLocation.Size = new System.Drawing.Size(167, 60);
            this.btnOpenFileLocation.TabIndex = 14;
            this.btnOpenFileLocation.Text = "Open Location";
            this.btnOpenFileLocation.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnOpenFileLocation.Click += new System.EventHandler(this.btnOpenFileLocation_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.EnteredBorderColor = System.Drawing.Color.Blue;
            this.btnCancel.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Image = null;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.Location = new System.Drawing.Point(564, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCancel.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCancel.Size = new System.Drawing.Size(167, 60);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOpenPDF
            // 
            this.btnOpenPDF.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenPDF.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnOpenPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenPDF.EnteredBorderColor = System.Drawing.Color.Blue;
            this.btnOpenPDF.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnOpenPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOpenPDF.Image = null;
            this.btnOpenPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenPDF.InactiveColor = System.Drawing.Color.LimeGreen;
            this.btnOpenPDF.Location = new System.Drawing.Point(63, 336);
            this.btnOpenPDF.Name = "btnOpenPDF";
            this.btnOpenPDF.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnOpenPDF.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnOpenPDF.Size = new System.Drawing.Size(167, 60);
            this.btnOpenPDF.TabIndex = 16;
            this.btnOpenPDF.Text = "Open PDF";
            this.btnOpenPDF.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnOpenPDF.Click += new System.EventHandler(this.btnOpenPDF_Click);
            // 
            // lblOpenProgress
            // 
            this.lblOpenProgress.AutoSize = true;
            this.lblOpenProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblOpenProgress.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblOpenProgress.Location = new System.Drawing.Point(230, 269);
            this.lblOpenProgress.Name = "lblOpenProgress";
            this.lblOpenProgress.Size = new System.Drawing.Size(0, 38);
            this.lblOpenProgress.TabIndex = 17;
            // 
            // frmConvertCompleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblOpenProgress);
            this.Controls.Add(this.btnOpenPDF);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenFileLocation);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.bigLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConvertCompleted";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConvertCompleted";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ReaLTaiizor.Controls.Button btnOpenFileLocation;
        private ReaLTaiizor.Controls.Button btnCancel;
        private ReaLTaiizor.Controls.Button btnOpenPDF;
        private ReaLTaiizor.Controls.BigLabel lblOpenProgress;
    }
}