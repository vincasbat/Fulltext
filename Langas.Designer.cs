namespace WindowsFormsApplication1
{
    partial class Langas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Langas));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIkelti = new System.Windows.Forms.Button();
            this.folderChooser = new System.Windows.Forms.FolderBrowserDialog();
            this.chooser = new System.Windows.Forms.OpenFileDialog();
            this.btnXslt = new System.Windows.Forms.Button();
            this.btnUnzip = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnEbd = new System.Windows.Forms.Button();
            this.pbUnzip = new System.Windows.Forms.PictureBox();
            this.pbPdf = new System.Windows.Forms.PictureBox();
            this.pbEbd = new System.Windows.Forms.PictureBox();
            this.chk = new System.Windows.Forms.CheckBox();
            this.btnZipbebiblio = new System.Windows.Forms.Button();
            this.pbIkelti = new System.Windows.Forms.PictureBox();
            this.pbXslt = new System.Windows.Forms.PictureBox();
            this.pbZipbebiblio = new System.Windows.Forms.PictureBox();
            this.btnVveiksmu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnzip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEbd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIkelti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbXslt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZipbebiblio)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 230);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 27);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnIkelti
            // 
            this.btnIkelti.Location = new System.Drawing.Point(134, 155);
            this.btnIkelti.Name = "btnIkelti";
            this.btnIkelti.Size = new System.Drawing.Size(294, 31);
            this.btnIkelti.TabIndex = 4;
            this.btnIkelti.Text = "Įkelti <description>, <claims>, <drawings> ir zipuoti";
            this.btnIkelti.UseVisualStyleBackColor = true;
            this.btnIkelti.Click += new System.EventHandler(this.btnIkelti_Click);
            // 
            // btnXslt
            // 
            this.btnXslt.Location = new System.Drawing.Point(134, 190);
            this.btnXslt.Name = "btnXslt";
            this.btnXslt.Size = new System.Drawing.Size(294, 31);
            this.btnXslt.TabIndex = 5;
            this.btnXslt.Text = "XSLT";
            this.btnXslt.UseVisualStyleBackColor = true;
            this.btnXslt.Click += new System.EventHandler(this.btnXslt_Click);
            // 
            // btnUnzip
            // 
            this.btnUnzip.Location = new System.Drawing.Point(134, 50);
            this.btnUnzip.Name = "btnUnzip";
            this.btnUnzip.Size = new System.Drawing.Size(294, 31);
            this.btnUnzip.TabIndex = 1;
            this.btnUnzip.Text = "Unzip";
            this.btnUnzip.UseVisualStyleBackColor = true;
            this.btnUnzip.Click += new System.EventHandler(this.btnUnzip_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 172);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Patentų XML tekstų tvarkymas";
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(134, 85);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(294, 31);
            this.btnPdf.TabIndex = 2;
            this.btnPdf.Text = "PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnEbd
            // 
            this.btnEbd.Location = new System.Drawing.Point(134, 120);
            this.btnEbd.Name = "btnEbd";
            this.btnEbd.Size = new System.Drawing.Size(294, 31);
            this.btnEbd.TabIndex = 3;
            this.btnEbd.Text = "EBD";
            this.btnEbd.UseVisualStyleBackColor = true;
            this.btnEbd.Click += new System.EventHandler(this.btnEbd_Click);
            // 
            // pbUnzip
            // 
            this.pbUnzip.Image = ((System.Drawing.Image)(resources.GetObject("pbUnzip.Image")));
            this.pbUnzip.Location = new System.Drawing.Point(434, 50);
            this.pbUnzip.Name = "pbUnzip";
            this.pbUnzip.Size = new System.Drawing.Size(32, 32);
            this.pbUnzip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbUnzip.TabIndex = 6;
            this.pbUnzip.TabStop = false;
            // 
            // pbPdf
            // 
            this.pbPdf.Image = ((System.Drawing.Image)(resources.GetObject("pbPdf.Image")));
            this.pbPdf.Location = new System.Drawing.Point(434, 84);
            this.pbPdf.Name = "pbPdf";
            this.pbPdf.Size = new System.Drawing.Size(32, 32);
            this.pbPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPdf.TabIndex = 7;
            this.pbPdf.TabStop = false;
            // 
            // pbEbd
            // 
            this.pbEbd.Image = ((System.Drawing.Image)(resources.GetObject("pbEbd.Image")));
            this.pbEbd.Location = new System.Drawing.Point(434, 120);
            this.pbEbd.Name = "pbEbd";
            this.pbEbd.Size = new System.Drawing.Size(32, 32);
            this.pbEbd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEbd.TabIndex = 8;
            this.pbEbd.TabStop = false;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Location = new System.Drawing.Point(443, 30);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(15, 14);
            this.chk.TabIndex = 11;
            this.chk.UseVisualStyleBackColor = true;
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // btnZipbebiblio
            // 
            this.btnZipbebiblio.Location = new System.Drawing.Point(134, 227);
            this.btnZipbebiblio.Name = "btnZipbebiblio";
            this.btnZipbebiblio.Size = new System.Drawing.Size(294, 30);
            this.btnZipbebiblio.TabIndex = 14;
            this.btnZipbebiblio.Text = "Zip be biblio";
            this.btnZipbebiblio.UseVisualStyleBackColor = true;
            this.btnZipbebiblio.Click += new System.EventHandler(this.btnZipbebiblio_Click);
            // 
            // pbIkelti
            // 
            this.pbIkelti.Image = ((System.Drawing.Image)(resources.GetObject("pbIkelti.Image")));
            this.pbIkelti.Location = new System.Drawing.Point(434, 154);
            this.pbIkelti.Name = "pbIkelti";
            this.pbIkelti.Size = new System.Drawing.Size(32, 32);
            this.pbIkelti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbIkelti.TabIndex = 16;
            this.pbIkelti.TabStop = false;
            // 
            // pbXslt
            // 
            this.pbXslt.Image = ((System.Drawing.Image)(resources.GetObject("pbXslt.Image")));
            this.pbXslt.Location = new System.Drawing.Point(434, 190);
            this.pbXslt.Name = "pbXslt";
            this.pbXslt.Size = new System.Drawing.Size(32, 32);
            this.pbXslt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbXslt.TabIndex = 17;
            this.pbXslt.TabStop = false;
            // 
            // pbZipbebiblio
            // 
            this.pbZipbebiblio.Image = ((System.Drawing.Image)(resources.GetObject("pbZipbebiblio.Image")));
            this.pbZipbebiblio.Location = new System.Drawing.Point(434, 225);
            this.pbZipbebiblio.Name = "pbZipbebiblio";
            this.pbZipbebiblio.Size = new System.Drawing.Size(32, 32);
            this.pbZipbebiblio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbZipbebiblio.TabIndex = 18;
            this.pbZipbebiblio.TabStop = false;
            // 
            // btnVveiksmu
            // 
            this.btnVveiksmu.BackColor = System.Drawing.SystemColors.Control;
            this.btnVveiksmu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnVveiksmu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVveiksmu.Location = new System.Drawing.Point(275, 10);
            this.btnVveiksmu.Name = "btnVveiksmu";
            this.btnVveiksmu.Size = new System.Drawing.Size(153, 32);
            this.btnVveiksmu.TabIndex = 19;
            this.btnVveiksmu.Text = "Vienu veiksmu";
            this.btnVveiksmu.UseVisualStyleBackColor = false;
            this.btnVveiksmu.Click += new System.EventHandler(this.btnVveiksmu_Click);
            // 
            // Langas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 280);
            this.Controls.Add(this.btnVveiksmu);
            this.Controls.Add(this.pbZipbebiblio);
            this.Controls.Add(this.pbXslt);
            this.Controls.Add(this.pbIkelti);
            this.Controls.Add(this.btnZipbebiblio);
            this.Controls.Add(this.chk);
            this.Controls.Add(this.pbEbd);
            this.Controls.Add(this.pbPdf);
            this.Controls.Add(this.pbUnzip);
            this.Controls.Add(this.btnEbd);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnUnzip);
            this.Controls.Add(this.btnXslt);
            this.Controls.Add(this.btnIkelti);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Langas";
            this.Text = "Programavo Vincas Batulevičius        20150423v";
            this.Load += new System.EventHandler(this.Langas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnzip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEbd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIkelti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbXslt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZipbebiblio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIkelti;
        private System.Windows.Forms.FolderBrowserDialog folderChooser;
        private System.Windows.Forms.OpenFileDialog chooser;
        private System.Windows.Forms.Button btnXslt;
        private System.Windows.Forms.Button btnUnzip;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnEbd;
        private System.Windows.Forms.PictureBox pbUnzip;
        private System.Windows.Forms.PictureBox pbPdf;
        private System.Windows.Forms.PictureBox pbEbd;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.Button btnZipbebiblio;
        private System.Windows.Forms.PictureBox pbIkelti;
        private System.Windows.Forms.PictureBox pbXslt;
        private System.Windows.Forms.PictureBox pbZipbebiblio;
        private System.Windows.Forms.Button btnVveiksmu;
    }
}

