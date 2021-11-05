using System;
using System.Collections;
using System.Windows.Forms;

namespace kararDestek
{
    public partial class ilacEkle : Form
    {
        riskDeger form1 = new riskDeger();
        public ArrayList kriterler = new ArrayList();
        public ArrayList alternatifler = new ArrayList();
        public string hastalikIsmi;
        int duzenleIndex;
        public ilacEkle()
        {
            InitializeComponent();
        }
        private void ilacOzellikEkle()
        {
            try
            {
                if (txtilacOzellik.Text == "")
                {
                    MessageBox.Show("Özellik girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for (int i = 0; i < kriterler.Count; i++)
                    {
                        if (txtilacOzellik.Text == kriterler[i].ToString())
                        {
                            MessageBox.Show("Lütfen farklı Özellikler giriniz!", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    listBoxOzellik.Items.Add(txtilacOzellik.Text);

                    kriterler.Add(txtilacOzellik.Text);
                    //eklendikten sonra butonları aktif etsin
                    buttonilacOzellikSil.Enabled = true;
                    buttonilacOzellikDuzenle.Enabled = true;
                    panelKriter.Visible = true;
                    //ekledikten sonra textbox ın içini temizleyip imleci oraya fokuslasın
                    txtilacOzellik.Clear();
                    txtilacOzellik.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Özellik ekleme işlemi başarısız!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void ilacOzellikDuzenle()
        {
            try
            {
                if (txtilacOzellik.Text == "")
                {
                    MessageBox.Show("Özellik girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    listBoxOzellik.Items.RemoveAt(duzenleIndex);
                    listBoxOzellik.Items.Insert(duzenleIndex, txtilacOzellik.Text);
                    kriterler.RemoveAt(duzenleIndex);
                    kriterler.Insert(duzenleIndex, txtilacOzellik.Text);
                    //eklendikten sonra butonları aktif etsin
                    buttonilacOzellikSil.Enabled = true;
                    buttonilacOzellikDuzenle.Enabled = true;
                    //ekledikten sonra textbox ın içini temizleyip imleci oraya fokuslasın
                    txtilacOzellik.Clear();
                    txtilacOzellik.Focus();

                    buttonilacOzellikEkle.Text = "Ekle";//guncelle text degistir
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Özellik güncelleme işlemi başarısız!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void ozellikSil()
        {
            try
            {
                int secili = listBoxOzellik.SelectedIndex;
                kriterler.RemoveAt(secili);
                listBoxOzellik.Items.RemoveAt(secili);

                if (listBoxOzellik.Items.Count == 0)
                {
                    txtilacOzellik.Focus();
                    buttonilacOzellikSil.Enabled = false;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen silmek istediğiniz özelliği seçiniz!", "Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void ilacKaydet()
        {
            try
            {
                for (int i = 0; i < alternatifler.Count; i++)
                {
                    if (txtilac.Text == alternatifler[i].ToString())
                    {
                        MessageBox.Show("Lütfen farklı ilaç giriniz!", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (txtilac.Text == "")
                {
                    MessageBox.Show("İlaç girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    listBoxilac.Items.Add(txtilac.Text);
                    alternatifler.Add(txtilac.Text);
                    //alternatif eklendikten sonra butonları aktif etsin
                    buttonilacSil.Enabled = true;
                    buttonilacDüzenle.Enabled = true;
                    panelAlternatif.Visible = true;
                    panelKriter.Visible = true;
                    //ekledikten sonra textbox ın içini temizleyip imleci oraya fokuslasın
                    txtilac.Clear();
                    txtilac.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void ilacDuzenle()
        {
            try
            {
                if (txtilac.Text == "")
                {
                    MessageBox.Show("İlaç girmeden ekleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    listBoxilac.Items.RemoveAt(duzenleIndex);
                    listBoxilac.Items.Insert(duzenleIndex, txtilac.Text);
                    alternatifler.RemoveAt(duzenleIndex);
                    alternatifler.Insert(duzenleIndex, txtilac.Text);
                    //alternatif eklendikten sonra butonları aktif etsin
                    buttonilacSil.Enabled = true;
                    buttonilacDüzenle.Enabled = true;
                    //ekledikten sonra textbox ın içini temizleyip imleci oraya fokuslasın
                    txtilac.Clear();
                    txtilac.Focus();
                    panelAlternatif.Visible = true;
                    panelKriter.Visible = true;
                }
                txtilac.Clear();
                txtilac.Focus();

                buttonilacEkle.Text = "Ekle";
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void ilacSil()
        {
            try
            {
                int secili = listBoxilac.SelectedIndex;
                alternatifler.RemoveAt(secili);
                listBoxilac.Items.RemoveAt(secili);

                txtilac.Focus();

                if (listBoxilac.Items.Count == 0)
                {
                    buttonilacSil.Enabled = false;
                    txtilac.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ilacı seçiniz!", "Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void buttonilacOzellikEkle_Click(object sender, EventArgs e)
        {
            if (buttonilacOzellikEkle.Text == "Ekle")
            {
                ilacOzellikEkle();
            }
            else if (buttonilacOzellikEkle.Text == "Güncelle")
            {
                ilacOzellikDuzenle();
            }
        }
        private void buttonilacOzellikDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (SayiMi(listBoxOzellik.SelectedIndex + "") == false)
                {
                    MessageBox.Show("Kriter seçili olmadan güncelleme yapamazsınız !", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                duzenleIndex = listBoxOzellik.SelectedIndex;
                txtilacOzellik.Text = kriterler[duzenleIndex].ToString();
                buttonilacOzellikEkle.Text = "Güncelle";
            }
            catch (Exception)
            {
                return;
            }
        }
        private void buttonilacOzellikSil_Click(object sender, EventArgs e)
        {
            ozellikSil();
        }
        private void buttonilacEkle_Click(object sender, EventArgs e)
        {
            if (buttonilacEkle.Text == "Ekle")
            {
                ilacKaydet();
            }
            else if (buttonilacEkle.Text == "Güncelle")
            {
                ilacDuzenle();
            }
        }
        private void buttonilacDüzenle_Click(object sender, EventArgs e)
        {
            duzenleIndex = listBoxilac.SelectedIndex;
            txtilac.Text = alternatifler[duzenleIndex].ToString();
            buttonilacEkle.Text = "Güncelle";
        }
        private void buttonilacSil_Click(object sender, EventArgs e)
        {
            ilacSil();
        }
        private void buttonİlaçRiskDegeri_Click(object sender, EventArgs e)
        {
            form1.ilacOzellikleri = kriterler;
            form1.ilaclar = alternatifler;
            form1.hastalikIsmi = textBoxHastalik.Text;
            this.Close();
            form1.ShowDialog();
        }
    }
}
