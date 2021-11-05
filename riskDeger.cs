using System;
using System.Collections;
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
using FireSharp;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;

namespace kararDestek
{
    public partial class riskDeger : Form
    {

        public ArrayList ilacOzellikleri = new ArrayList(); //
        public  ArrayList ilaclar = new ArrayList();//
        public ArrayList riskDegerler = new ArrayList();//
        public string hastalikIsmi;
        public riskDeger()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY"); //import için

            InitializeComponent();
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
        private void riskDeger_Load(object sender, EventArgs e)
        {
            labelHastalikismi.Text = hastalikIsmi;
            riskMatrisiOlustur();
           }
        private void riskMatrisiOlustur()
        {
            gridTasarim(dataGridViewRiskMatrisi);
            try
            {
                dataGridViewRiskMatrisi.Rows.Clear();
                dataGridViewRiskMatrisi.ColumnCount = ilacOzellikleri.Count + 1;
                dataGridViewRiskMatrisi.Columns[0].Name = " ";

                int j = 1;
                for (int i = 0; i < ilacOzellikleri.Count; i++)
                {
                    dataGridViewRiskMatrisi.Columns[j].Name = ilacOzellikleri[i].ToString();
                    j++;
                }
                for (int i = 0; i < ilaclar.Count; i++)
                {
                    dataGridViewRiskMatrisi.Rows.Add(ilaclar[i].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void buttonIlaclarRiskMatrisKaydet_Click(object sender, EventArgs e)
        {
                //boş hücre kontrolü
                for (int i = 0; i < ilaclar.Count; i++) //satır
                {
                    for (int j = 1; j < ilacOzellikleri.Count + 1; j++) //sutun
                    {
                        if (dataGridViewRiskMatrisi.Rows[i].Cells[j].Value == null)
                        {
                            //dataGridViewKararMat.Visible = false;
                            MessageBox.Show("Lütfen boş hücreleri doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            riskMatExelAktar();
            }
        public void exelAktar()
        {

        }
        public void riskMatExelAktar()
        {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XLS files (*.xls)|*.xls|XLT files (*.xlt)|*.xlt|XLSX files (*.xlsx)|*.xlsx|XLSM files (*.xlsm)|*.xlsm|XLTX (*.xltx)|*.xltx|XLTM (*.xltm)|*.xltm|ODS (*.ods)|*.ods|OTS (*.ots)|*.ots|CSV (*.csv)|*.csv|TSV (*.tsv)|*.tsv|HTML (*.html)|*.html|MHTML (.mhtml)|*.mhtml|PDF (*.pdf)|*.pdf|XPS (*.xps)|*.xps|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif|WMP (*.wdp)|*.wdp";
                saveFileDialog.FilterIndex = 3;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var workbook = new ExcelFile();
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    // From DataGridView to ExcelFile.
                    DataGridViewConverter.ImportFromDataGridView(worksheet, this.dataGridViewRiskMatrisi, new ImportFromDataGridViewOptions() { ColumnHeaders = true });

                    workbook.Save(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Excel'e aktarma işlemi başarısız!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
