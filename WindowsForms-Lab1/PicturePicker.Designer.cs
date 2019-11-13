namespace WindowsForms_Lab1
{
    partial class PicturePicker
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Option1 = new System.Windows.Forms.PictureBox();
            this.Option2 = new System.Windows.Forms.PictureBox();
            this.Option3 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Option1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick an Option";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.Option1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Option2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Option3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 109);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Option1
            // 
            this.Option1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Option1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Option1.Location = new System.Drawing.Point(3, 3);
            this.Option1.MinimumSize = new System.Drawing.Size(100, 100);
            this.Option1.Name = "Option1";
            this.Option1.Size = new System.Drawing.Size(102, 103);
            this.Option1.TabIndex = 0;
            this.Option1.TabStop = false;
            this.Option1.Click += new System.EventHandler(this.Option1_Click);
            // 
            // Option2
            // 
            this.Option2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Option2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Option2.Location = new System.Drawing.Point(111, 3);
            this.Option2.MinimumSize = new System.Drawing.Size(100, 100);
            this.Option2.Name = "Option2";
            this.Option2.Size = new System.Drawing.Size(102, 103);
            this.Option2.TabIndex = 1;
            this.Option2.TabStop = false;
            this.Option2.Click += new System.EventHandler(this.Option2_Click);
            // 
            // Option3
            // 
            this.Option3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Option3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Option3.Location = new System.Drawing.Point(219, 3);
            this.Option3.MinimumSize = new System.Drawing.Size(100, 100);
            this.Option3.Name = "Option3";
            this.Option3.Size = new System.Drawing.Size(102, 103);
            this.Option3.TabIndex = 2;
            this.Option3.TabStop = false;
            this.Option3.Click += new System.EventHandler(this.Option3_Click);
            // 
            // PicturePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(330, 130);
            this.Name = "PicturePicker";
            this.Size = new System.Drawing.Size(330, 130);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Option1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox Option1;
        private System.Windows.Forms.PictureBox Option2;
        private System.Windows.Forms.PictureBox Option3;
    }
}
