using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



namespace kararDestek
{
    public partial class Form1 : Form
    {
        string text = "Eklemek istediğiniz kriteri giriniz";
        string text2 = "Eklemek istediğiniz alternatifi giriniz";
        public static ArrayList kriterler = new ArrayList(); //
        public static ArrayList alternatifler = new ArrayList();//
        public static ArrayList agirliklar = new ArrayList();//
        public static ArrayList maxList = new ArrayList();
        public static ArrayList minList = new ArrayList();
        public static ArrayList kriterMaxMin = new ArrayList(); //
        int duzenleIndex;
        double max, min, agirlikToplam;

        public Form1()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
            gridTasarimSirasiz(dataGridViewKararMat);
            gridTasarimSirasiz(dataGridViewNormalize);
            gridTasarimSirasiz(dataGridViewKriterAgirlik);
            gridTasarimSirasiz(dataGridViewAgirlikliNormalizeKMat);
            gridTasarimSirasiz(dataGridViewIdealCozumMat);
            gridTasarimSirasiz(dataGridViewIdealUzaklik);
            gridTasarimSirasiz(dataGridViewNegatifIdealUzaklık);
            gridTasarimSirasiz(dataGridViewTopsisSonuc);
        }
        public void gridTasarim(DataGridView datagridview)
        {
            datagridview.RowHeadersVisible = false;  //ilk sutunu gizleme
            datagridview.BorderStyle = BorderStyle.None;
            datagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSlateGray;//varsayılan arka plan rengi verme
            datagridview.DefaultCellStyle.SelectionBackColor = Color.Silver; //seçilen hücrenin arkaplan rengini belirleme
            datagridview.DefaultCellStyle.SelectionForeColor = Color.White;  //seçilen hücrenin yazı rengini belirleme
            datagridview.EnableHeadersVisualStyles = false; //başlık özelliğini değiştirme
            datagridview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //başlık çizgilerini ayarlama
            datagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; //başlık arkaplan rengini belirleme

            datagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;  //başlık yazı rengini belirleme
            datagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;                                                                   // datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //satırı tamamen seçmeyi sağlama
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //her hangi bir sutunun genişliğini o sutunda yer alan en  uzun yazının genişliğine göre ayarlama

            datagridview.AllowUserToAddRows = false;  //ilk sutunu gizleme
            datagridview.AllowUserToOrderColumns = true;

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

        //kriter islemleri
        private void btnKriterEkle_Click(object sender, EventArgs e)
        {
            if (buttonKriterEkle.Text == "Ekle")
            {
                kriterEkle();
            }

            else if (buttonKriterEkle.Text == "Güncelle")
            {
                kriterDuzenle();
            }
        }
        public void kriterDuzenle()
        {

            try
            {
                if (txtKriter.Text == text)
                {
                    MessageBox.Show("Kriter girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (txtKriter.Text == "")
                    {
                        MessageBox.Show("Kriter girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //uyarı
                    if (rbtnMax.Checked == false && rbtnMin.Checked == false)
                    {
                        MessageBox.Show("Lütfen kriter tipini seçiniz!", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //listbox a ekleme
                    if (rbtnMax.Checked == true)
                    {
                        listBoxKriter.Items.RemoveAt(duzenleIndex);
                        listBoxKriter.Items.Insert(duzenleIndex, txtKriter.Text + "  (" + rbtnMax.Text + ")");
                    }
                    if (rbtnMin.Checked == true)
                    {
                        listBoxKriter.Items.RemoveAt(duzenleIndex);
                        listBoxKriter.Items.Insert(duzenleIndex, txtKriter.Text + "  (" + rbtnMin.Text + ")");
                    }


                    kriterler.RemoveAt(duzenleIndex);
                    kriterler.Insert(duzenleIndex, txtKriter.Text);
                    //eklendikten sonra butonları aktif etsin
                    buttonKriterSil.Enabled = true;
                    buttonKriterDuzenle.Enabled = true;

                    //max ve min kriterlerini arrayliste ekleme

                    if (rbtnMax.Checked == true)
                    {
                        kriterMaxMin.RemoveAt(duzenleIndex);
                        kriterMaxMin.Insert(duzenleIndex, rbtnMax.Text);
                    }
                    if (rbtnMin.Checked == true)
                    {
                        kriterMaxMin.RemoveAt(duzenleIndex);
                        kriterMaxMin.Insert(duzenleIndex, rbtnMin.Text);
                    }

                    //ekledikten sonra textbox ın içini temizleyip imleci oraya fokuslasın
                    txtKriter.Clear();
                    txtKriter.Focus();

                    buttonKriterEkle.Text = "Ekle";

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Kriter güncelleme işlemi başarısız!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void kriterEkle()
        {
            try
            {
                if (txtKriter.Text == text)
                {
                    MessageBox.Show("Kriter girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for (int i = 0; i < kriterler.Count; i++)
                    {
                        if (txtKriter.Text == kriterler[i].ToString())
                        {
                            MessageBox.Show("Lütfen farklı kriterler giriniz!", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (txtKriter.Text == "")
                    {
                        MessageBox.Show("Kriter girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //uyarı
                    if (rbtnMax.Checked == false && rbtnMin.Checked == false)
                    {
                        MessageBox.Show("Lütfen kriter tipini seçiniz!", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //listbox a ekleme
                    if (rbtnMax.Checked == true)
                    {
                        listBoxKriter.Items.Add(txtKriter.Text + "  (" + rbtnMax.Text + ")");
                    }
                    if (rbtnMin.Checked == true)
                    {
                        listBoxKriter.Items.Add(txtKriter.Text + "  (" + rbtnMin.Text + ")");
                    }


                    kriterler.Add(txtKriter.Text);
                    //eklendikten sonra butonları aktif etsin
                    buttonKriterSil.Enabled = true;
                    buttonKriterDuzenle.Enabled = true;

                    //max ve min kriterlerini arrayliste ekleme

                    if (rbtnMax.Checked == true)
                    {
                        kriterMaxMin.Add(rbtnMax.Text);
                    }
                    if (rbtnMin.Checked == true)
                    {
                        kriterMaxMin.Add(rbtnMin.Text);
                    }

                    panelKriter.Visible = true;
                    //ekledikten sonra textbox ın içini temizleyip imleci oraya fokuslasın
                    txtKriter.Clear();
                    txtKriter.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kriter ekleme işlemi başarısız!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void butonKriterDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (SayiMi(listBoxKriter.SelectedIndex + "") == false)
                {
                    MessageBox.Show("Kriter seçili olmadan güncelleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                duzenleIndex = listBoxKriter.SelectedIndex;
                txtKriter.Text = kriterler[duzenleIndex].ToString();
                buttonKriterEkle.Text = "Güncelle";

            }
            catch (Exception)
            {
                return;
            }
        }
        bool SayiMi(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        private void butonKriterSil_Click(object sender, EventArgs e)
        {
            kriterSil();
        }
        public void kriterSil()
        {
            try
            {
                int secili = listBoxKriter.SelectedIndex;
                kriterler.RemoveAt(secili);
                listBoxKriter.Items.RemoveAt(secili);

                if (listBoxKriter.Items.Count == 0)
                {
                    txtKriter.Focus();
                    buttonKriterSil.Enabled = false;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kriteri seçiniz!", "Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void buttonAlternatifEkle_Click(object sender, EventArgs e)
        {
            if (buttonAlternatifEkle.Text == "Ekle")
            {
                alternatifEkle();
            }
            else if (buttonAlternatifEkle.Text == "Güncelle")
            {
                alternatifDuzenle();
            }
        }
        public void alternatifEkle()
        {
            try
            {
                for (int i = 0; i < alternatifler.Count; i++)
                {
                    if (txtAlternatif.Text == alternatifler[i].ToString())
                    {
                        MessageBox.Show("Lütfen farklı alternatifler giriniz!", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (txtAlternatif.Text == text2)
                {
                    MessageBox.Show("Alternatif girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else if (txtAlternatif.Text == "")
                {
                    MessageBox.Show("Alternatif girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    listBoxAlternatif.Items.Add(txtAlternatif.Text);
                    alternatifler.Add(txtAlternatif.Text);
                    //alternatif eklendikten sonra butonları aktif etsin
                    buttonAlternatifSil.Enabled = true;
                    buttonAlternatifDüzenle.Enabled = true;

                    panelAlternatif.Visible = true;
                    panelKriter.Visible = true;
                    //ekledikten sonra textbox ın içini temizleyip imleci oraya fokuslasın
                    txtAlternatif.Clear();
                    txtAlternatif.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void alternatifDuzenle()
        {
            try
            {
                if (txtAlternatif.Text == text2)
                {
                    MessageBox.Show("Alternatif girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtAlternatif.Text == "")
                {
                    MessageBox.Show("Alternatif girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    listBoxAlternatif.Items.RemoveAt(duzenleIndex);
                    listBoxAlternatif.Items.Insert(duzenleIndex, txtAlternatif.Text);
                    alternatifler.RemoveAt(duzenleIndex);
                    alternatifler.Insert(duzenleIndex, txtAlternatif.Text);
                    //alternatif eklendikten sonra butonları aktif etsin
                    buttonAlternatifSil.Enabled = true;
                    buttonAlternatifDüzenle.Enabled = true;
                    //ekledikten sonra textbox ın içini temizleyip imleci oraya fokuslasın

                    txtAlternatif.Clear();
                    txtAlternatif.Focus();
                    panelAlternatif.Visible = true;
                    panelKriter.Visible = true;
                }
                txtAlternatif.Clear();
                txtAlternatif.Focus();

                buttonAlternatifEkle.Text = "Ekle";
            }
            catch (Exception)
            {

                MessageBox.Show("Hata!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void buttonAlternatifDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (SayiMi(listBoxAlternatif.SelectedIndex + "") == false)
                {
                    MessageBox.Show("Kriter seçili olmadan güncelleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                duzenleIndex = listBoxAlternatif.SelectedIndex;
                txtAlternatif.Text = alternatifler[duzenleIndex].ToString();
                buttonAlternatifEkle.Text = "Güncelle";
            }
            catch (Exception)
            {

                return;
            }

        }
        private void buttonAlternatifSil_Click(object sender, EventArgs e)
        {
            alternatifSil();
        }
        public void alternatifSil()
        {
            try
            {
                int secili = listBoxAlternatif.SelectedIndex;
                alternatifler.RemoveAt(secili);
                listBoxAlternatif.Items.RemoveAt(secili);

                txtAlternatif.Focus();

                if (listBoxAlternatif.Items.Count == 0)
                {
                    buttonAlternatifSil.Enabled = false;
                    txtAlternatif.Focus();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen silmek istediğiniz alternatifi seçiniz!", "Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        private void buttonAlternatifDüzenle_Click(object sender, EventArgs e)
        {
            duzenleIndex = listBoxAlternatif.SelectedIndex;
            txtAlternatif.Text = alternatifler[duzenleIndex].ToString();
            buttonAlternatifEkle.Text = "Güncelle";

        }
        private void buttonAlternatifSil_Click_1(object sender, EventArgs e)
        {
            alternatifSil();
        }
        private void buttonKararMatrisOlustur_Click(object sender, EventArgs e)
        {
            kararMatrisiOlustur();

        }
        private void kararMatrisiOlustur()
        {
            try
            {
                dataGridViewKararMat.Rows.Clear();
                tabControl1.SelectedTab = tabPageKararMatrisi;
                dataGridViewKararMat.ColumnCount = kriterler.Count + 1;
                dataGridViewKararMat.Columns[0].Name = " ";

                int j = 1;
                for (int i = 0; i < kriterler.Count; i++)
                {
                    dataGridViewKararMat.Columns[j].Name = kriterler[i].ToString();
                    j++;
                }

                for (int i = 0; i < alternatifler.Count; i++)
                {

                    dataGridViewKararMat.Rows.Add(alternatifler[i].ToString());
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
                if (kriterMaxMin[j - 1].ToString() == rbtnMax.Text)
                {
                    dataGridViewKararMat.Columns[j].HeaderCell.Style.BackColor = Color.LightBlue;

                }
                else if (kriterMaxMin[j - 1].ToString() == rbtnMin.Text)
                {
                    dataGridViewKararMat.Columns[j].HeaderCell.Style.BackColor = Color.Plum;

                }
                else
                {
                    MessageBox.Show("boş");
                    return;
                }

            }
        }
        private void buttonNormalizeMat_Click(object sender, EventArgs e)
        {
            //boş hücre kontrolü
            for (int i = 0; i < alternatifler.Count; i++) //satır
            {
                for (int j = 1; j < kriterler.Count + 1; j++) //sutun
                {
                    if (dataGridViewKararMat.Rows[i].Cells[j].Value == null)
                    {
                        //dataGridViewKararMat.Visible = false;
                        MessageBox.Show("Lütfen boş hücreleri doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }

            topsisNormalize();
            tabControl1.SelectedTab = tabPageNormalizeMat;

        }
        public void MatrisExelAktar(DataGridView datagridview)
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
                    DataGridViewConverter.ImportFromDataGridView(worksheet, datagridview, new ImportFromDataGridViewOptions() { ColumnHeaders = true });

                    workbook.Save(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Excel'e aktarma işlemi başarısız!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void buttonKararMatExelAktar_Click(object sender, EventArgs e)
        {
            MatrisExelAktar(this.dataGridViewKararMat);
        }
        public void topsisNormalize()
        {
            try
            {
                MatCerceve(dataGridViewNormalize);
                

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
                dataGridView.ColumnCount = kriterler.Count + 1; //alternatif sutunuda bulunması gerektiğinden kriterler+1 tane sutun ekledim
                dataGridView.Columns[0].Name = " ";

                for (int i = 0; i < kriterler.Count; i++)
                {
                    dataGridView.Columns[i + 1].Name = kriterler[i].ToString();
                }
                for (int i = 0; i < alternatifler.Count; i++)
                {
                    dataGridView.Rows.Add(alternatifler[i].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Normalize matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    for (int i = 0; i < alternatifler.Count; i++)
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
                    if (kriterMaxMin[i].ToString() == rbtnMax.Text)
                    {
                        dataGridViewIdealCozumMat.Rows[0].Cells[i + 1].Value = Convert.ToDouble(maxList[i]);
                        dataGridViewIdealCozumMat.Rows[1].Cells[i + 1].Value = Convert.ToDouble(minList[i]);
                    }
                    else if (kriterMaxMin[i].ToString() == rbtnMin.Text)
                    {
                        dataGridViewIdealCozumMat.Rows[0].Cells[i + 1].Value = Convert.ToDouble(minList[i]);
                        dataGridViewIdealCozumMat.Rows[1].Cells[i + 1].Value = Convert.ToDouble(maxList[i]);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("İdeal ve negatif ideal çözüm değerleri belirlenemedi!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void buttonUzaklikDeger_Click(object sender, EventArgs e)
        {
            negatifIdealUzaklık();
            idealUzaklik();
            tabControl1.SelectedTab = tabPageIdealUzaklık;

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
        public void normalizeMaxMin() //AĞIRLIKLANDIRILMIŞ NORMALİZE MATRİSİNDEKİ HER SUTUNDAKİ MAX VE MİN DEĞERLERİ BULUP ARRAYLİSTLERE ATAN METOD
        {
            //ağırlıklandırılmış normalize matrisindeki bir sutundaki max ve min değerleri bulan döngüler
            for (int j = 1; j < kriterler.Count + 1; j++)
            {
                max = Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[0].Cells[j].Value);
                min = Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[0].Cells[j].Value);

                for (int i = 0; i < alternatifler.Count; i++)
                {
                    if (Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value) > max)
                    {
                        max = Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value);
                    }
                }
                maxList.Add(max);

                for (int i = 0; i < alternatifler.Count; i++)
                {
                    if (Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value) < min)
                    {
                        min = Convert.ToDouble(dataGridViewAgirlikliNormalizeKMat.Rows[i].Cells[j].Value);
                    }
                }
                minList.Add(min);
            }
        }
        public void negatifIdealUzaklık()
        {
            try
            {
                negatifIdealUzaklikMatCerceve();
                for (int i = 0; i < alternatifler.Count; i++)
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
        public void negatifIdealUzaklikMatCerceve()
        {
            try
            {
                dataGridViewNegatifIdealUzaklık.Rows.Clear();
                dataGridViewNegatifIdealUzaklık.ColumnCount = 2;
                dataGridViewNegatifIdealUzaklık.Columns[0].Name = " ";
                dataGridViewNegatifIdealUzaklık.Columns[1].Name = "Si-";

                for (int i = 0; i < alternatifler.Count; i++)
                {
                    dataGridViewNegatifIdealUzaklık.Rows.Add(alternatifler[i].ToString());
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Negatif ideal uzaklık matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void idealUzaklik()
        {
            try
            {
                idealUzaklikMatCerceve();
                for (int i = 0; i < alternatifler.Count; i++)
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
        public void idealUzaklikMatCerceve()
        {
            try
            {
                dataGridViewIdealUzaklik.Rows.Clear();
                dataGridViewIdealUzaklik.ColumnCount = 2;
                dataGridViewIdealUzaklik.Columns[0].Name = " ";
                dataGridViewIdealUzaklik.Columns[1].Name = "Si*";

                for (int i = 0; i < alternatifler.Count; i++)
                {
                    dataGridViewIdealUzaklik.Rows.Add(alternatifler[i].ToString());
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
        public void idealCozumGoreliYakinlik()
        {
            try
            {
                idealCozumGoreliYakinlikMatCerceve();
                for (int i = 0; i < alternatifler.Count; i++)
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
                for (int i = 0; i < alternatifler.Count; i++)
                {
                    dataGridViewTopsisSonuc.Rows.Add(alternatifler[i].ToString());
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("İdeal çözüme göreli yakınlık matrisi oluşturulamadı!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageKararMatOlusturma;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                radioButtonExelMin.Checked = true;
                //uyarı//ilaç ekledigimiz icin min olması gerekiyor
                if (radioButtonExelMax.Checked == false && radioButtonExelMin.Checked == false)
                {
                    MessageBox.Show("Lütfen kriterlerin tipini seçiniz!", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //tumunuTemizle();
                kararMatImport();
                importKararMatDoldur();
                kararMatImportListeDoldurma();
                kararMatColumnsRenklendir();
                tabControl1.SelectedTab = tabPageKararMatrisi;

                gridTasarimSirasiz(dataGridViewKararMat);
            }
            catch
            {
                MessageBox.Show("Dosya seçilmedi", "Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void kararMatImport()
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var workbook = ExcelFile.Load(openFileDialog.FileName);

                    // From ExcelFile to DataGridView.
                    DataGridViewConverter.ExportToDataGridView(workbook.Worksheets.ActiveWorksheet, this.dataGridViewImport, new ExportToDataGridViewOptions() { ColumnHeaders = false });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Karar matrisi yüklenemedi!" + ex.Message, "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void buttonTopsisSonucExelAktar_Click(object sender, EventArgs e)
        {
            MatrisExelAktar(this.dataGridViewTopsisSonuc);
        }

        private void buttonNormalizeMatExelAktar_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewNormalize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void importKararMatDoldur()
        {
            gridTasarimSirasiz(dataGridViewImport);
            dataGridViewKararMat.ColumnCount = dataGridViewImport.Columns.Count;
            dataGridViewKararMat.Columns[0].Name = " ";

            for (int i = 1; i < dataGridViewImport.Columns.Count; i++)
            {
                dataGridViewKararMat.Columns[i].Name = (dataGridViewImport.Rows[0].Cells[i].Value.ToString());
            }

            for (int i = 1; i < dataGridViewImport.Rows.Count; i++)
            {

                dataGridViewKararMat.Rows.Add(dataGridViewImport.Rows[i].Cells[0].Value.ToString());
            }

            for (int i = 1; i < dataGridViewImport.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewImport.Columns.Count; j++)
                {

                    dataGridViewKararMat.Rows[i - 1].Cells[j].Value = dataGridViewImport.Rows[i].Cells[j].Value.ToString();


                }
            }
            dataGridViewImport.Visible = false;
        }
        public void kararMatImportListeDoldurma()
        {
            try
            {
                for (int i = 1; i < dataGridViewKararMat.Columns.Count; i++)
                {
                    kriterler.Add(dataGridViewKararMat.Columns[i].Name.ToString());
                }
                for (int i = 0; i < kriterler.Count; i++)
                {
                    if (radioButtonExelMax.Checked == true)
                    {
                        kriterMaxMin.Add(rbtnMax.Text);
                    }
                    else if (radioButtonExelMin.Checked == true)
                    {
                        kriterMaxMin.Add(rbtnMin.Text);
                    }

                }
                for (int i = 0; i < dataGridViewKararMat.Rows.Count; i++)
                {
                    alternatifler.Add(dataGridViewKararMat.Rows[i].Cells[0].Value.ToString());
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen boş hücreleri doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}

