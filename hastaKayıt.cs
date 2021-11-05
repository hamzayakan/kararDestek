using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net;

namespace kararDestek
{
    public partial class hastaKayıt : Form
    {

        public string tc_secilen="";
        public string HastaTcKimlikNo;
        public string HastaAdi;
        public string HastaSoyadi;
        public string HastaCinsiyet;
        public string HastaDogumYeri;
        public string HastaRandevuTarihi;
        public string HastaTelefon;
        public string HastaEposta;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "JO1k3WnJP2vfBWIoh7ZEoneVbKJnSGWznn9kECui",
            BasePath = "https://hastane-karar-destek-sistemi-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public hastaKayıt()
        {
            InitializeComponent();
        }
        static bool baglantiKontrol()
        {
            try
            {
                return new System.Net.NetworkInformation.Ping().Send("www.google.com", 1000).Status == System.Net.NetworkInformation.IPStatus.Success;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void hastaKayıt_Load(object sender, EventArgs e)
        {
            temizle();
            if (baglantiKontrol() == false)
            {
                MessageBox.Show("İnternet Bağlantınızı Kontrol Ediniz!");
                this.Close();
            }
            else
            {
                client = new FireSharp.FirebaseClient(config);

                if (client != null)//Sunucuda baglanti kontrol
                {
                //    MessageBox.Show("Bağlantı Başarılı");
                }
                else
                {
                    MessageBox.Show("Bağlantı Kurulamadı");
                }
            }
            
        }
        private void buttonHastaKaydet_Click(object sender, EventArgs e)
        {
            
            if (textBoxHastaTc.Text == "" || textBoxHastaAdi.Text =="" ||
            textBoxHastaSoyadi.Text == "" || textBoxHastaTc.Text == "" ||
            comboBoxHastaCinsiyet.Text == "" || textBoxDogumYeri.Text == "" ||
            textBoxHastaTel.Text == "" || textBoxHastaEposta.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girilmiştir");
            }
            else
            {
                var data = new Data
                {
                    HastaTcKimlikNo = textBoxHastaTc.Text,
                    HastaAdi = textBoxHastaAdi.Text,
                    HastaSoyadi = textBoxHastaSoyadi.Text,
                    HastaCinsiyet = comboBoxHastaCinsiyet.Text,
                    HastaDogumYeri = textBoxDogumYeri.Text,
                    HastaRandevuTarihi = dateTimePickerHastaRandevuTarih.Text,
                    HastaTelefon = textBoxHastaTel.Text,
                    HastaEposta = textBoxHastaEposta.Text
                };
                FirebaseResponse response  =  client.Set("HastaTCNO/" + textBoxHastaTc.Text, data);
                MessageBox.Show("Hasta Kayıt Edildi. Başarılı...");
                temizle();
            }
            
        }
         public void temizle()
        {
            textBoxHastaTc.Text = "";
            textBoxHastaAdi.Text = "";
            textBoxHastaSoyadi.Text = "";
            textBoxHastaTc.Text = "";
            comboBoxHastaCinsiyet.Text = "";
            textBoxDogumYeri.Text = "";
            dateTimePickerHastaRandevuTarih.Text = "";
            textBoxHastaTel.Text = "";
            textBoxHastaEposta.Text = "";
        }
        private void buttonHastaKayıtKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void hastaKayıt_Shown(object sender, EventArgs e)
        {
            if (tc_secilen=="")
            {
                temizle();
                buttonHastaKaydet.Text = "Kaydet";
            }
            else
            {
                textBoxHastaTc.Text = tc_secilen;
                textBoxHastaAdi.Text = HastaAdi;
                textBoxHastaSoyadi.Text = HastaSoyadi;
                comboBoxHastaCinsiyet.Text = HastaCinsiyet;
                textBoxDogumYeri.Text = HastaDogumYeri;
                dateTimePickerHastaRandevuTarih.Text = HastaRandevuTarihi;
                textBoxHastaTel.Text = HastaTelefon;
                textBoxHastaEposta.Text = HastaEposta;
                buttonHastaKaydet.Text = "Güncelle";
            }
        }
    }
}
