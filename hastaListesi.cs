using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace kararDestek
{
    public partial class hastaListesi : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "JO1k3WnJP2vfBWIoh7ZEoneVbKJnSGWznn9kECui",
            BasePath = "https://hastane-karar-destek-sistemi-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public hastaListesi()
        {
            InitializeComponent();
            dataGridViewHasta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//butun satırı secmek icin
            dataGridViewHasta.MultiSelect = false;//coklu secim satırı kapalı

        }
        hastaKayıt form1 = new hastaKayıt();
        public string tc_secilen;
        public string HastaTcKimlikNo;
        public string HastaAdi;
        public string HastaSoyadi;
        public string HastaCinsiyet;
        public string HastaDogumYeri;
        public string HastaRandevuTarihi;
        public string HastaTelefon;
        public string HastaEposta;
        public void gridTasarim(DataGridView datagridview)
        {
            datagridview.RowHeadersVisible = false;  //ilk sutunu gizleme         
            datagridview.BorderStyle = BorderStyle.None;
            // datagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSlateGray;//varsayılan arka plan rengi verme
            datagridview.DefaultCellStyle.SelectionBackColor = Color.Silver; //seçilen hücrenin arkaplan rengini belirleme
            datagridview.DefaultCellStyle.SelectionForeColor = Color.White;  //seçilen hücrenin yazı rengini belirleme
            datagridview.EnableHeadersVisualStyles = false; //başlık özelliğini değiştirme
            datagridview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single; //başlık çizgilerini ayarlama
            //datagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; //başlık arkaplan rengini belirleme

            //datagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;  //başlık yazı rengini belirleme
            datagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //satırı tamamen seçmeyi sağlama
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //her hangi bir sutunun genişliğini o sutunda yer alan en  uzun yazının genişliğine göre ayarlama

            datagridview.AllowUserToAddRows = false;
            datagridview.AllowUserToOrderColumns = false;

        }
        
        public  void Listele()
        {
            try
            {
                gridTasarim(dataGridViewHasta);
                client = new FirebaseClient(config);
                FirebaseResponse response = client.Get("HastaTCNO");
                Dictionary<string, Data> getData = response.ResultAs<Dictionary<string, Data>>();


                foreach (var get in getData)
                {
                    dataGridViewHasta.Rows.Add(get.Value.HastaTcKimlikNo, get.Value.HastaAdi,
                        get.Value.HastaSoyadi, get.Value.HastaCinsiyet, get.Value.HastaDogumYeri,
                        get.Value.HastaRandevuTarihi, get.Value.HastaTelefon, get.Value.HastaEposta);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Veri Yok");
            }
           
        }
        private async void hastaListesi_Load(object sender, EventArgs e)
        {
           
            Listele();
        }
        private async void buttonHastaSil_Click(object sender, EventArgs e)
        {
            tc_secilen = dataGridViewHasta.SelectedCells[0].Value.ToString();//en bastaki hucreyi alacak
            FirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "JO1k3WnJP2vfBWIoh7ZEoneVbKJnSGWznn9kECui",
                BasePath = "https://hastane-karar-destek-sistemi-default-rtdb.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            var data = await client.DeleteTaskAsync("HastaTCNO/" + tc_secilen);
            MessageBox.Show("Seçili kayıt Silindi");
            dataGridViewHasta.Rows.Clear();
            Listele();
        }
        private async void buttonHastaDüzenle_Click(object sender, EventArgs e)
        {
            tc_secilen = dataGridViewHasta.SelectedCells[0].Value.ToString();//en bastaki hucreyi alacak
            HastaAdi = dataGridViewHasta.SelectedCells[1].Value.ToString();//en bastaki hucreyi alacak
            HastaSoyadi = dataGridViewHasta.SelectedCells[2].Value.ToString();//en bastaki hucreyi alacak
            HastaCinsiyet = dataGridViewHasta.SelectedCells[3].Value.ToString();//en bastaki hucreyi alacak
            HastaDogumYeri = dataGridViewHasta.SelectedCells[4].Value.ToString();//en bastaki hucreyi alacak
            HastaRandevuTarihi = dataGridViewHasta.SelectedCells[5].Value.ToString();//en bastaki hucreyi alacak
            HastaTelefon = dataGridViewHasta.SelectedCells[6].Value.ToString();//en bastaki hucreyi alacak
            HastaEposta = dataGridViewHasta.SelectedCells[7].Value.ToString();//en bastaki hucreyi alacak

            form1.tc_secilen = tc_secilen;
            form1.HastaAdi = HastaAdi;
            form1.HastaSoyadi = HastaSoyadi;
            form1.HastaCinsiyet = HastaCinsiyet;
            form1.HastaDogumYeri = HastaDogumYeri;
            form1.HastaRandevuTarihi = HastaRandevuTarihi;
            form1.HastaTelefon = HastaTelefon;
            form1.HastaEposta = HastaEposta;
            form1.ShowDialog();
            dataGridViewHasta.Rows.Clear();
            Listele();

        }
        private void buttonHastaYeniKayıt_Click(object sender, EventArgs e)
        {
            hastaKayıt form2 = new hastaKayıt();
            form2.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
