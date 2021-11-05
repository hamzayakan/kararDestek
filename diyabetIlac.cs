using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
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
    public partial class diyabetIlac : Form
    {
        int[,] riskmatris = new int[,] { {3,1,7,5,3,1,3,1 }, { 3,1,7,5,3,3,3,3}, {3,1,5,3,3,3,3,3},
            { 3,3,3,3,3,3,3,3 },{3,5,3,3,5,3,5,1 },{7,7,7,3,3,5,3,1 },{7,7,7,3,3,3,3,3 } };
        public ArrayList ozellikler = new ArrayList();
        public ArrayList ilaclar = new ArrayList();
        public ArrayList eklenenIlaclar = new ArrayList();

        public static ArrayList agirliklar = new ArrayList();//
        public static ArrayList maxList = new ArrayList();
        public static ArrayList minList = new ArrayList();
        public static ArrayList kriterMaxMin = new ArrayList(); //
        int duzenleIndex;
        double max, min, agirlikToplam;
        public diyabetIlac()
        {
            InitializeComponent();
            gridTasarim(dataGridViewAgirlikliNormalizeKMat);

        }

        private void diyabetIlac_Load(object sender, EventArgs e)
        {
            ilaclar.Add("MET");
            ilaclar.Add("GLP-1");
            ilaclar.Add("SGLT2");
            ilaclar.Add("DPP-4");
            ilaclar.Add("TZD");
            ilaclar.Add("SU");
            ilaclar.Add("Insulin");
            ozellikler.Add("Hypo");
            ozellikler.Add("Weight");
            ozellikler.Add("Renal/GU");
            ozellikler.Add("GI Sx");
            ozellikler.Add("CHF");
            ozellikler.Add("CVD");
            ozellikler.Add("Bone");
            ozellikler.Add("Cost");
            riskMatrisiOlustur();

        }
        private void riskMatrisiOlustur()
        {
            gridTasarim(dataGridViewRiskIlacMatris);
            try
            {
                dataGridViewRiskIlacMatris.Rows.Clear();
                dataGridViewRiskIlacMatris.ColumnCount = ozellikler.Count + 1;
                dataGridViewRiskIlacMatris.Columns[0].Name = " ";

                int j = 1;
                for (int i = 0; i < ozellikler.Count; i++)
                {
                    dataGridViewRiskIlacMatris.Columns[j].Name = ozellikler[i].ToString();
                    j++;
                }
                for (int i = 0; i < ilaclar.Count; i++)
                {
                    dataGridViewRiskIlacMatris.Rows.Add(ilaclar[i].ToString());
                }

                for (int i = 0; i < 7; i++)
                {
                    for (int k = 1; k < 9; k++)
                    {
                        dataGridViewRiskIlacMatris.Rows[i].Cells[k].Value = riskmatris[i, k-1];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
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

        private void buttonOzellikAgirlikBelirle_Click(object sender, EventArgs e)
        {
            topsisNormalize(dataGridViewNormalize);
            normalizeMatris();
            tabControl1.SelectedTab = tabPageNormalizeMat;
        }
        private void normalizeMatris()
        {
            int[,] secilenIlaclarMat = new int[eklenenIlaclar.Count+1, 8];
            
                for (int i = 0; i < eklenenIlaclar.Count; i++)
                {
                for (int j = 0; j < ilaclar.Count; j++)
                {
                    if ( eklenenIlaclar[i].ToString() == ilaclar[j].ToString())
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            secilenIlaclarMat[i, k] = riskmatris[j,k];
                        }
                    }
                }
                }
            try
            {
                dataGridViewKullan.Rows.Clear();
                dataGridViewKullan.ColumnCount = ozellikler.Count + 1;
                dataGridViewKullan.Columns[0].Name = " ";

                int j = 1;
                for (int i = 0; i < ozellikler.Count; i++)
                {
                    dataGridViewKullan.Columns[j].Name = ozellikler[i].ToString();
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
                        dataGridViewKullan.Rows[i].Cells[k].Value = secilenIlaclarMat[i,k-1 ];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void topsisNormalize(DataGridView dataGridView)
        {
            try
            {
                gridTasarim(dataGridView);
                MatCerceve(dataGridView);

                for (int j = 1; j < ozellikler.Count + 1; j++)
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
            catch (Exception ex)
            {

                MessageBox.Show("Matris Normalize Edilemedi!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void MatCerceve(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                //normalize matrisi
                dataGridView.ColumnCount = ozellikler.Count + 1; //alternatif sutunuda bulunması gerektiğinden ozellikler+1 tane sutun ekledim
                dataGridView.Columns[0].Name = " ";

                for (int i = 0; i < ozellikler.Count; i++)
                {
                    dataGridView.Columns[i + 1].Name = ozellikler[i].ToString();
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
        

    }
}
