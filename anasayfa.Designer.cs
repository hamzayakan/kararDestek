
namespace kararDestek
{
    partial class anasayfa
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
            this.buttonHastaKaydet = new System.Windows.Forms.Button();
            this.buttonHastaListesi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonHastaKaydet
            // 
            this.buttonHastaKaydet.BackColor = System.Drawing.Color.Fuchsia;
            this.buttonHastaKaydet.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHastaKaydet.Location = new System.Drawing.Point(65, 45);
            this.buttonHastaKaydet.Name = "buttonHastaKaydet";
            this.buttonHastaKaydet.Size = new System.Drawing.Size(368, 72);
            this.buttonHastaKaydet.TabIndex = 0;
            this.buttonHastaKaydet.Text = "Hasta Ekle";
            this.buttonHastaKaydet.UseVisualStyleBackColor = false;
            this.buttonHastaKaydet.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonHastaListesi
            // 
            this.buttonHastaListesi.BackColor = System.Drawing.Color.Fuchsia;
            this.buttonHastaListesi.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHastaListesi.Location = new System.Drawing.Point(65, 142);
            this.buttonHastaListesi.Name = "buttonHastaListesi";
            this.buttonHastaListesi.Size = new System.Drawing.Size(368, 73);
            this.buttonHastaListesi.TabIndex = 6;
            this.buttonHastaListesi.Text = "Hasta Listesi";
            this.buttonHastaListesi.UseVisualStyleBackColor = false;
            this.buttonHastaListesi.Click += new System.EventHandler(this.buttonHastaListesi_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(272, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 43);
            this.button1.TabIndex = 7;
            this.button1.Text = "Çıkış";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Fuchsia;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(65, 235);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(368, 72);
            this.button5.TabIndex = 10;
            this.button5.Text = "Diyabet İlaç Öner(TOPSIS)";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(729, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonHastaListesi);
            this.Controls.Add(this.buttonHastaKaydet);
            this.Name = "anasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.Load += new System.EventHandler(this.anasayfa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonHastaKaydet;
        private System.Windows.Forms.Button buttonHastaListesi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
    }
}