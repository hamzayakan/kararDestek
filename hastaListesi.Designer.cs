
namespace kararDestek
{
    partial class hastaListesi
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
            this.dataGridViewHasta = new System.Windows.Forms.DataGridView();
            this.tcKimilNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonHastaSil = new System.Windows.Forms.Button();
            this.buttonHastaDüzenle = new System.Windows.Forms.Button();
            this.buttonHastaYeniKayıt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.HastaTcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHasta)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHasta
            // 
            this.dataGridViewHasta.AllowUserToAddRows = false;
            this.dataGridViewHasta.AllowUserToDeleteRows = false;
            this.dataGridViewHasta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewHasta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHasta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tcKimilNo,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridViewHasta.Location = new System.Drawing.Point(21, 49);
            this.dataGridViewHasta.Name = "dataGridViewHasta";
            this.dataGridViewHasta.ReadOnly = true;
            this.dataGridViewHasta.RowTemplate.Height = 25;
            this.dataGridViewHasta.Size = new System.Drawing.Size(863, 258);
            this.dataGridViewHasta.TabIndex = 0;
            // 
            // tcKimilNo
            // 
            this.tcKimilNo.HeaderText = "TC Kimlik";
            this.tcKimilNo.Name = "tcKimilNo";
            this.tcKimilNo.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ad";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Soyad";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cinsiyet";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Doğum Yeri";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Randevu Tarihi";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Telefon";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "E-Posta";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // buttonHastaSil
            // 
            this.buttonHastaSil.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonHastaSil.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHastaSil.Location = new System.Drawing.Point(162, 425);
            this.buttonHastaSil.Name = "buttonHastaSil";
            this.buttonHastaSil.Size = new System.Drawing.Size(143, 40);
            this.buttonHastaSil.TabIndex = 1;
            this.buttonHastaSil.Text = "Sil";
            this.buttonHastaSil.UseVisualStyleBackColor = false;
            this.buttonHastaSil.Click += new System.EventHandler(this.buttonHastaSil_Click);
            // 
            // buttonHastaDüzenle
            // 
            this.buttonHastaDüzenle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonHastaDüzenle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHastaDüzenle.Location = new System.Drawing.Point(356, 425);
            this.buttonHastaDüzenle.Name = "buttonHastaDüzenle";
            this.buttonHastaDüzenle.Size = new System.Drawing.Size(143, 40);
            this.buttonHastaDüzenle.TabIndex = 2;
            this.buttonHastaDüzenle.Text = "Düzenle";
            this.buttonHastaDüzenle.UseVisualStyleBackColor = false;
            this.buttonHastaDüzenle.Click += new System.EventHandler(this.buttonHastaDüzenle_Click);
            // 
            // buttonHastaYeniKayıt
            // 
            this.buttonHastaYeniKayıt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonHastaYeniKayıt.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHastaYeniKayıt.Location = new System.Drawing.Point(551, 425);
            this.buttonHastaYeniKayıt.Name = "buttonHastaYeniKayıt";
            this.buttonHastaYeniKayıt.Size = new System.Drawing.Size(143, 40);
            this.buttonHastaYeniKayıt.TabIndex = 3;
            this.buttonHastaYeniKayıt.Text = "Yeni Kayıt";
            this.buttonHastaYeniKayıt.UseVisualStyleBackColor = false;
            this.buttonHastaYeniKayıt.Click += new System.EventHandler(this.buttonHastaYeniKayıt_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(741, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 40);
            this.button1.TabIndex = 4;
            this.button1.Tag = "";
            this.button1.Text = "Çıkış";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HastaTcNo
            // 
            this.HastaTcNo.HeaderText = "TC No";
            this.HastaTcNo.Name = "HastaTcNo";
            // 
            // hastaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 528);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonHastaYeniKayıt);
            this.Controls.Add(this.buttonHastaDüzenle);
            this.Controls.Add(this.buttonHastaSil);
            this.Controls.Add(this.dataGridViewHasta);
            this.Name = "hastaListesi";
            this.Tag = "";
            this.Text = "Hasta Kayıt ve Randevu Ver";
            this.Load += new System.EventHandler(this.hastaListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHasta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHasta;
        private System.Windows.Forms.Button buttonHastaSil;
        private System.Windows.Forms.Button buttonHastaDüzenle;
        private System.Windows.Forms.Button buttonHastaYeniKayıt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HastaTcNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcKimilNp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcKimilNo;
    }
}