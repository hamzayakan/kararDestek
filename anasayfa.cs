using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kararDestek
{
    public partial class anasayfa : Form
    {
        public static ArrayList kriterler = new ArrayList(); //
        public static ArrayList alternatifler = new ArrayList();//
        topsisDiyabet formTopsisDiyabet = new topsisDiyabet();
        public anasayfa()
        {
            InitializeComponent();
        }
        private void anasayfa_Load(object sender, EventArgs e)
        {
            alternatifler.Add("MET");
            alternatifler.Add("GLP-1");
            alternatifler.Add("SGLT2");
            alternatifler.Add("DPP-4");
            alternatifler.Add("TZD");
            alternatifler.Add("SU");
            alternatifler.Add("Insulin");
            kriterler.Add("Hypo");
            kriterler.Add("Weight");
            kriterler.Add("Renal/GU");
            kriterler.Add("GI Sx");
            kriterler.Add("CHF");
            kriterler.Add("CVD");
            kriterler.Add("Bone");
            kriterler.Add("Cost");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            hastaKayıt form = new hastaKayıt();
            form.ShowDialog();
        }
        private void buttonHastaListesi_Click(object sender, EventArgs e)
        {
            hastaListesi form = new hastaListesi();
            form.ShowDialog();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonHastalıkKaydet_Click(object sender, EventArgs e)
        {
            ilacEkle form = new ilacEkle();
            form.ShowDialog();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            formTopsisDiyabet.kriterler = kriterler;
            formTopsisDiyabet.alternatifler = alternatifler;
            formTopsisDiyabet.ShowDialog();
        }
    }
}
