using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;


namespace kararDestek
{
    public partial class topsisDiyabet : Form
    {
        int[,] riskmatris = new int[,] { {3,1,7,5,3,1,3,1 }, { 3,1,7,5,3,3,3,3}, {3,1,5,3,3,3,3,3},
            { 3,3,3,3,3,3,3,3 },{3,5,3,3,5,3,5,1 },{7,7,7,3,3,5,3,1 },{7,7,7,3,3,3,3,3 } };
        public  ArrayList kriterler = new ArrayList(); //
        public  ArrayList alternatifler = new ArrayList();//
        public  ArrayList agirliklar = new ArrayList();//
        public  ArrayList maxList = new ArrayList();
        public  ArrayList minList = new ArrayList();
        public  ArrayList kriterMaxMin = new ArrayList(); //

        public ArrayList eklenenIlaclar = new ArrayList();
        double max, min, agirlikToplam;


        public topsisDiyabet()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
            gridTasarimSirasiz(dataGridViewRiskIlacMatris);
            gridTasarimSirasiz(dataGridViewNormalize);
            gridTasarimSirasiz(dataGridViewKriterAgirlik);
            gridTasarimSirasiz(dataGridViewAgirlikliNormalizeKMat);
            gridTasarimSirasiz(dataGridViewIdealCozumMat);
            gridTasarimSirasiz(dataGridViewIdealUzaklik);
            gridTasarimSirasiz(dataGridViewNegatifIdealUzaklık);
            gridTasarimSirasiz(dataGridViewTopsisSonuc);
            gridTasarimSirasiz(dataGridViewRiskIlacMatris);
        }
        public void gridTasarimSirasiz(DataGridView datagridview)
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
        private void topsisDiyabet_Load(object sender, EventArgs e)
        {
            kararMatrisiDoldur();

        }
        private void kararMatrisiDoldur()
        {
                kararMatrisiOlustur();
                for (int i = 0; i < 7; i++)
                {
                    for (int k = 1; k < 9; k++)
                    {
                        dataGridViewRiskIlacMatris.Rows[i].Cells[k].Value = riskmatris[i, k - 1];
                    }
                }
        }
        private void kararMatrisiOlustur()
        {
            try
            {
                dataGridViewRiskIlacMatris.Rows.Clear();
                tabControl1.SelectedTab = tabPageKararMatrisi;
                dataGridViewRiskIlacMatris.ColumnCount = kriterler.Count + 1;
                dataGridViewRiskIlacMatris.Columns[0].Name = " ";

                int j = 1;
                for (int i = 0; i < kriterler.Count; i++)
                {
                    dataGridViewRiskIlacMatris.Columns[j].Name = kriterler[i].ToString();
                    j++;
                }

                for (int i = 0; i < alternatifler.Count; i++)
                {

                    dataGridViewRiskIlacMatris.Rows.Add(alternatifler[i].ToString());
                }

                kararMatColumnsRenklendir();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void kararMatColumnsRenklendir()
        {
            for (int j = 1; j < kriterler.Count + 1; j++)
            {
                    dataGridViewRiskIlacMatris.Columns[j].HeaderCell.Style.BackColor = Color.Plum;
            }
        }
        private void buttonEkleIlac_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    if (comboBoxIlaclar.Text == eklenenIlaclar[i].ToString())
                    {
                        MessageBox.Show("Lütfen farklı ilaç giriniz!", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (comboBoxIlaclar.Text == "")
                {
                    MessageBox.Show("İlaç girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    labelIlacGoster.Visible = true;
                    eklenenIlaclar.Add(comboBoxIlaclar.Text);
                    labelIlacGoster.Text = labelIlacGoster.Text + "\n" + comboBoxIlaclar.Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void buttonNormalizeMat_Click(object sender, EventArgs e)
        {
            normalizeMatrisAta();
            tabControl1.SelectedTab = tabPageNormalizeMat;
        }
        private void normalizeMatrisAta()
        {
            // dataGridViewNormalize

            secilenMatrisAta();
            dataGridViewNormalize.Rows.Clear();
            tabControl1.SelectedTab = tabPageKararMatrisi;
            dataGridViewNormalize.ColumnCount = kriterler.Count + 1;
            dataGridViewNormalize.Columns[0].Name = " ";

            int n = 1;
            for (int i = 0; i < kriterler.Count; i++)
            {
                dataGridViewNormalize.Columns[n].Name = kriterler[i].ToString();
                n++;
            }

            for (int i = 0; i < eklenenIlaclar.Count; i++)
            {

                dataGridViewNormalize.Rows.Add(eklenenIlaclar[i].ToString());
            }

            for (int i = 0; i < eklenenIlaclar.Count; i++)
            {
                for (int k = 1; k < kriterler.Count + 1; k++)
                {
                 //   dataGridViewNormalize.Rows[i].Cells[k].Value = dataGridViewKullan.Rows[i].Cells[k].Value;

                }
            }

            for (int j = 1; j < kriterler.Count + 1; j++)
            {
                double payda = 0;
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    payda += (double)Math.Pow(Convert.ToDouble(dataGridViewKullan.Rows[i].Cells[j].Value), 2);
                }
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    double nij = (Convert.ToDouble(dataGridViewKullan.Rows[i].Cells[j].Value) / (double)Math.Sqrt(payda));

                    dataGridViewNormalize.Rows[i].Cells[j].Value = nij;
                }
            }

        }
        private void secilenMatrisAta()
        {
            int[,] secilenIlaclarMat = new int[eklenenIlaclar.Count + 1, 8];

            for (int i = 0; i < eklenenIlaclar.Count; i++)
            {
                for (int j = 0; j < alternatifler.Count; j++)
                {
                    if (eklenenIlaclar[i].ToString() == alternatifler[j].ToString())
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            secilenIlaclarMat[i, k] = riskmatris[j, k];
                        }
                    }
                }
            }
            try
            {
                dataGridViewKullan.Rows.Clear();
                dataGridViewKullan.ColumnCount = kriterler.Count + 1;
                dataGridViewKullan.Columns[0].Name = " ";

                int j = 1;
                for (int i = 0; i < kriterler.Count; i++)
                {
                    dataGridViewKullan.Columns[j].Name = kriterler[i].ToString();
                    j++;
                }
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    dataGridViewKullan.Rows.Add(eklenenIlaclar[i].ToString());
                }

                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    for (int k = 1; k < 9; k++)
                    {
                        dataGridViewKullan.Rows[i].Cells[k].Value = secilenIlaclarMat[i, k - 1];
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonKriterAgirlikHesapla_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAgirlikBelirleme;
            AgirlikMatrisi();
        }
        public void AgirlikMatrisi()
        {
            try
            {
                dataGridViewKriterAgirlik.Rows.Clear();
                int k = 1;
                dataGridViewKriterAgirlik.ColumnCount = kriterler.Count + 1;
                dataGridViewKriterAgirlik.Columns[0].Name = " ";

                for (int j = 0; j < kriterler.Count; j++)
                {
                    dataGridViewKriterAgirlik.Columns[k].Name = kriterler[j].ToString();
                    k++;
                }

                dataGridViewKriterAgirlik.Rows.Add("Ağırlıklar (virgül ile ayırınız)");



            }
            catch (Exception)
            {

                MessageBox.Show("Hata!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void buttonKriterAgirlikKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                for (int j = 1; j < kriterler.Count + 1; j++)
                {
                    agirliklar.Add(dataGridViewKriterAgirlik.Rows[0].Cells[j].Value.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen boş hücreleri doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            topsisAgirlikliNormalize();
            tabControl1.SelectedTab = tabPageAgirlikliNormalizeKMat;
        }

       

        public void topsisAgirlikliNormalize()
        {
            try
            {
                MatCerceve(dataGridViewAgirlikliNormalizeKMat);
                for (int j = 1; j < kriterler.Count + 1; j++)
                {
                    for (int i = 0; i < eklenenIlaclar.Count; i++)
                    {
                        dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value = Convert.ToDouble(dataGridViewNormalize.Rows[i].Cells[j].Value) * Convert.ToDouble(agirliklar[j - 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ağırlıklı normalize matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void MatCerceve(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                //normalize matrisi
                dataGridView.ColumnCount = kriterler.Count + 1; //alternatif sutunuda bulunması gerektiğinden kriterler+1 tane sutun ekledim
                dataGridView.Columns[0].Name = " ";

                for (int i = 0; i < kriterler.Count; i++)
                {
                    dataGridView.Columns[i + 1].Name = kriterler[i].ToString();
                }
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    dataGridView.Rows.Add(eklenenIlaclar[i].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Normalize matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonIdealCozum_Click(object sender, EventArgs e)
        {
            topsisIdealNegatifIdealCozumDegeri();
            tabControl1.SelectedTab = tabPageIdealCozum;
        }
        public void topsisIdealNegatifIdealCozumDegeri()
        {
            try
            {
                normalizeMaxMin(); //karar matrisindeki max ve min değerleri bulup listeye atan metod
                topsisIdealNegatifIdealMatCerceve();

                for (int i = 0; i < kriterler.Count; i++)
                {
                    /* if (kriterMaxMin[i].ToString() == rbtnMax.Text)
                     {
                         dataGridViewIdealCozumMat.Rows[0].Cells[i + 1].Value = Convert.ToDouble(maxList[i]);
                         dataGridViewIdealCozumMat.Rows[1].Cells[i + 1].Value = Convert.ToDouble(minList[i]);
                     }
                     else if (kriterMaxMin[i].ToString() == rbtnMin.Text)
                     {
                         dataGridViewIdealCozumMat.Rows[0].Cells[i + 1].Value = Convert.ToDouble(minList[i]);
                         dataGridViewIdealCozumMat.Rows[1].Cells[i + 1].Value = Convert.ToDouble(maxList[i]);
                     }*/
                    dataGridViewIdealCozumMat.Rows[0].Cells[i + 1].Value = Convert.ToDouble(minList[i]);
                        dataGridViewIdealCozumMat.Rows[1].Cells[i + 1].Value = Convert.ToDouble(maxList[i]);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("İdeal ve negatif ideal çözüm değerleri belirlenemedi!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }


        public void normalizeMaxMin() //AĞIRLIKLANDIRILMIŞ NORMALİZE MATRİSİNDEKİ HER SUTUNDAKİ MAX VE MİN DEĞERLERİ BULUP ARRAYLİSTLERE ATAN METOD
        {
            //ağırlıklandırılmış normalize matrisindeki bir sutundaki max ve min değerleri bulan döngüler
            for (int j = 1; j < kriterler.Count + 1; j++)
            {
                max = Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[0].Cells[j].Value);
                min = Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[0].Cells[j].Value);

                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    if (Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value) > max)
                    {
                        max = Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value);
                    }
                }
                maxList.Add(max);

                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    if (Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value) < min)
                    {
                        min = Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value);
                    }
                }
                minList.Add(min);
            }
        }
        public void topsisIdealNegatifIdealMatCerceve()
        {
            try
            {
                dataGridViewIdealCozumMat.Rows.Clear();

                dataGridViewIdealCozumMat.ColumnCount = kriterler.Count + 1;
                dataGridViewIdealCozumMat.Columns[0].Name = " ";
                int k = 1;
                for (int i = 0; i < kriterler.Count; i++)
                {
                    dataGridViewIdealCozumMat.Columns[k].Name = kriterler[i].ToString();
                    k++;
                }
                dataGridViewIdealCozumMat.Rows.Add("S*");
                dataGridViewIdealCozumMat.Rows.Add("S-");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void buttonUzaklikDeger_Click(object sender, EventArgs e)
        {
            negatifIdealUzaklık();
            idealUzaklik();
            tabControl1.SelectedTab = tabPageIdealUzaklık;
        }
        public void negatifIdealUzaklık()
        {
            try
            {
                negatifIdealUzaklikMatCerceve();
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    double s2Ussu = 0;
                    for (int j = 1; j < kriterler.Count + 1; j++)
                    {
                        s2Ussu += (double)Math.Pow((Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value) - Convert.ToDouble(dataGridViewIdealCozumMat.Rows[1].Cells[j].Value)), 2);
                    }
                    dataGridViewNegatifIdealUzaklık.Rows[i].Cells[1].Value = (double)Math.Sqrt(s2Ussu);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("İdeal uzaklık matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void idealUzaklik()
        {
            try
            {
                idealUzaklikMatCerceve();
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    double s2Yildiz = 0;
                    for (int j = 1; j < kriterler.Count + 1; j++)
                    {
                        s2Yildiz += (Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value) - Convert.ToDouble(dataGridViewIdealCozumMat.Rows[0].Cells[j].Value)) * (Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value) - Convert.ToDouble(dataGridViewIdealCozumMat.Rows[0].Cells[j].Value));
                    }
                    dataGridViewIdealUzaklik.Rows[i].Cells[1].Value = (double)Math.Sqrt(s2Yildiz);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("İdeal uzaklık matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void negatifIdealUzaklikMatCerceve()
        {
            try
            {
                dataGridViewNegatifIdealUzaklık.Rows.Clear();
                dataGridViewNegatifIdealUzaklık.ColumnCount = 2;
                dataGridViewNegatifIdealUzaklık.Columns[0].Name = " ";
                dataGridViewNegatifIdealUzaklık.Columns[1].Name = "Si-";

                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    dataGridViewNegatifIdealUzaklık.Rows.Add(eklenenIlaclar[i].ToString());
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Negatif ideal uzaklık matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void idealUzaklikMatCerceve()
        {
            try
            {
                dataGridViewIdealUzaklik.Rows.Clear();
                dataGridViewIdealUzaklik.ColumnCount = 2;
                dataGridViewIdealUzaklik.Columns[0].Name = " ";
                dataGridViewIdealUzaklik.Columns[1].Name = "Si*";

                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    dataGridViewIdealUzaklik.Rows.Add(eklenenIlaclar[i].ToString());
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("İdeal uzaklık matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonGöreceYakinlikHesapla_Click(object sender, EventArgs e)
        {
            idealCozumGoreliYakinlik();
            tabControl1.SelectedTab = tabPageTopsisSonuc;
        }

        private void tabPageKararMatrisi_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void idealCozumGoreliYakinlik()
        {
            try
            {
                idealCozumGoreliYakinlikMatCerceve();
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    dataGridViewTopsisSonuc.Rows[i].Cells[1].Value = dataGridViewIdealUzaklik.Rows[i].Cells[1].Value;
                    dataGridViewTopsisSonuc.Rows[i].Cells[2].Value = dataGridViewNegatifIdealUzaklık.Rows[i].Cells[1].Value;
                    dataGridViewTopsisSonuc.Rows[i].Cells[3].Value = Convert.ToDouble(dataGridViewTopsisSonuc.Rows[i].Cells[2].Value) / (Convert.ToDouble(dataGridViewTopsisSonuc.Rows[i].Cells[2].Value) + Convert.ToDouble(dataGridViewTopsisSonuc.Rows[i].Cells[1].Value));
                }
                dataGridViewTopsisSonuc.Sort(dataGridViewTopsisSonuc.Columns[3], ListSortDirection.Descending);

            }
            catch (Exception ex)
            {

                MessageBox.Show("İdeal çözüme göreli yakınlık matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void idealCozumGoreliYakinlikMatCerceve()
        {
            try
            {
                dataGridViewTopsisSonuc.Rows.Clear();
                dataGridViewTopsisSonuc.ColumnCount = 4;
                dataGridViewTopsisSonuc.Columns[0].Name = " ";
                dataGridViewTopsisSonuc.Columns[1].Name = "Si*";
                dataGridViewTopsisSonuc.Columns[2].Name = "Sİ-";
                dataGridViewTopsisSonuc.Columns[3].Name = "Ci*";
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                    dataGridViewTopsisSonuc.Rows.Add(eklenenIlaclar[i].ToString());
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("İdeal çözüme göreli yakınlık matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}

