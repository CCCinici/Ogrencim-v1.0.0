using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using BusinessLogicLayer;
using FacadeLayer;

namespace Ogrencim_v1._0._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Listele()
        {
            List<EntityOgrenci> ogrListe = BLLOgrenci.Listele();
            dataGridView1.DataSource = ogrListe;
            this.Text = "Öğrenci Listesi";
        }
        void KulupListele()
        {
            List<EntityKulup> klpListe = BLLKulup.Listele();
            dataGridView1.DataSource = klpListe;
            this.Text = "Kulüp Listesi";
        }
        void ComboKulupListele()
        {
            List<EntityKulup> klpListe = BLLKulup.Listele();
            cmbKulup.ValueMember = "KuluplerID";
            cmbKulup.DisplayMember = "KulupAdi";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            ComboKulupListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityOgrenci entOgrenci = new EntityOgrenci();
            entOgrenci.Ad = txtAd.Text;
            entOgrenci.Soyad = txtSoyad.Text;
            entOgrenci.Fotograf = txtFotograf.Text;
            entOgrenci.KulupID = Convert.ToInt32(cmbKulup.SelectedValue);
            BLLOgrenci.Ekle(entOgrenci);
            MessageBox.Show("Öğrenci kaydı yapıldı");
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //İlişkili tablolarda silme işlemi yapılmaz. Kayıt aktif pasif olarak değiştirilir.
            EntityOgrenci entOgr = new EntityOgrenci();
            entOgr.Mezun = 0;
            BLLOgrenci.Guncelle(entOgr);
            MessageBox.Show("Öğrenci silinmedi, ancak durumu 'Mezun oldu' olarak güncellendi");
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                EntityOgrenci ent_guncelle = new EntityOgrenci();
                ent_guncelle.Ad = txtAd.Text;
                ent_guncelle.Soyad = txtSoyad.Text;
                ent_guncelle.Fotograf = txtFotograf.Text;
                ent_guncelle.KulupID = Convert.ToInt32(cmbKulup.SelectedValue);
                ent_guncelle.OgrencilerID = Convert.ToInt32(txtID.Text);
                BLLOgrenci.Guncelle(ent_guncelle);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçtiğiniz değerlerin doğruluğundan emin olun");
            }
            
            MessageBox.Show("Öğrenci bilgileri güncellendi");
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Burası bilgileri çekerken sp'den değil. Direk tablodan çekiyor.
            if (this.Text == "Öğrenci Listesi")
            {
                //seçilen satırın 0. değeri.
                int secilen = (int)dataGridView1.CurrentRow.Cells[0].Value;
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtFotograf.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cmbKulup.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            if (this.Text == "Not Listesi")
            {
                int secilen = (int)dataGridView1.CurrentRow.Cells[0].Value;
                txtNotID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtS1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txts2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtS3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtProje.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtOrt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtDurum.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            if (this.Text == "Kulüp Listesi")
            {
                int secilen = (int)dataGridView1.CurrentRow.Cells[0].Value;
                txtKulupID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtKulupAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtMevcut.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }


        }
        void NotListele()
        {
            List<EntityNotlar> entNot = BLLNotlar.Listele();
            dataGridView1.DataSource = entNot;
            this.Text = "Not Listesi";
        }
        private void btnNotListele_Click(object sender, EventArgs e)
        {
            NotListele();
        }

        private void btnNotGuncelle_Click(object sender, EventArgs e)
        {
            EntityNotlar entNot = new EntityNotlar();
            entNot.OgrenciID = Convert.ToInt32(txtNotID.Text);
            entNot.Sinav1 = Convert.ToInt32(txtS1.Text);
            entNot.Sinav2 = Convert.ToInt32(txts2.Text);
            entNot.Sinav3 = Convert.ToInt32(txtS3.Text);
            entNot.Ortalama = Convert.ToInt32(txtOrt.Text);
            entNot.Proje = Convert.ToInt32(txtProje.Text);
            entNot.Durum = txtDurum.Text;

            BLLNotlar.Guncelle(entNot);
            MessageBox.Show("Notlar Güncellendi");
            NotListele();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, proje;
            double ortalama;
            string durum;

            s1 = Convert.ToInt32(txtS1.Text);
            s2 = Convert.ToInt32(txts2.Text);
            s3 = Convert.ToInt32(txtS3.Text);
            proje = Convert.ToInt32(txtProje.Text);

            ortalama = (s1 + s2 + s3 + proje) / 4;
            txtOrt.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }
            txtDurum.Text = durum;
        }

        private void btnKulupListele_Click(object sender, EventArgs e)
        {
            KulupListele();
            this.Text = "Kulüp Listesi";
        }

        private void btnKulupKaydet_Click(object sender, EventArgs e)
        {
            EntityKulup entKulup = new EntityKulup();
            entKulup.KulupAdi = txtKulupAd.Text;
            entKulup.Mevcut = Convert.ToInt32(txtMevcut.Text);
            BLLKulup.Ekle(entKulup);
            KulupListele();
        }

        private void btnKulupSil_Click(object sender, EventArgs e)
        {
            EntityKulup entKulup = new EntityKulup();
            entKulup.KuluplerID = Convert.ToInt32(txtKulupID.Text);
            //entKulup hepsini istiyor. sadece id gondermemiz yeterli
            BLLKulup.Sil(entKulup.KuluplerID);
            KulupListele();
        }

        private void btnKulupGuncelle_Click(object sender, EventArgs e)
        {
            EntityKulup entGuncelle = new EntityKulup();
            entGuncelle.KuluplerID = Convert.ToInt32(txtKulupID.Text);
            entGuncelle.KulupAdi = txtKulupAd.Text;
            entGuncelle.Mevcut = Convert.ToInt32(txtMevcut.Text);
            BLLKulup.Guncelle(entGuncelle);
            MessageBox.Show("Kulüp bilgileri güncellendi");
            KulupListele();
        }
    }
}
