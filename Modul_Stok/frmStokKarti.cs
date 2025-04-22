using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Otomasyon.Fonksiyonlar;
using DevExpress.XtraLayout.Resizing;

namespace Otomasyon.Modul_Stok
{
	public partial class frmStokKarti: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numaralar Numaralar = new Fonksiyonlar.Numaralar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Resimleme Resimleme = new Fonksiyonlar.Resimleme();

        bool Edit = false;
        bool Resim = false;
        OpenFileDialog Dosya =new OpenFileDialog();
        int GrupID = -1;
        int StokID = -1;
        public frmStokKarti()
		{
            InitializeComponent();
		}

        private void frmStokKarti_Load(object sender, EventArgs e)
        {
            txtStokKodu.Text = Numaralar.StokKodNumarasi();
            Mesajlar.FormAcilis(this.Text);
        }

        void Temizle()
        {
            txtStokKodu.Text = Numaralar.StokKodNumarasi();
            txtStokAdi.Text = "";
            txtSatisKDV.Text = "0";
            txtSatisFiyati.Text = "0";
            txtGrupKodu.Text = "";
            txtGrupAdi.Text = "";
            txtBirim.SelectedIndex = 0;
            txtBarkod.Text = "";
            txtAlisKDV.Text = "0";
            txtAlisFiyati.Text = "0";
            pictureBox1.Image = null;
            Edit = false;
            Resim = false;
            GrupID = -1;
            StokID = -1;
            AnaForm.Aktarma = -1;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void ResimSec()
        {
            Dosya.Filter = "Jpg(*.jpg)|*.jpg|Jpeg(*.jpeg)|*.jpeg";
            if (Dosya.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = Dosya.FileName;
                Resim = true;
            }
        }
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            ResimSec();
        }

        public void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_Stoklar Stok = new Fonksiyonlar.Tbl_Stoklar();
                Stok.StokAdı = txtStokAdi.Text;
                Stok.StokAlısFiyat = decimal.Parse(txtAlisFiyati.Text);
                Stok.StokAlısKdv = decimal.Parse(txtAlisKDV.Text);
                Stok.StokBarkod = txtBarkod.Text;
                Stok.StokBirim = txtBirim.Text;
                Stok.StokGrupID = GrupID;
                Stok.StokKodu = txtStokKodu.Text;
                Stok.StokResim = new System.Data.Linq.Binary(Resimleme.ResimYukleme(pictureBox1.Image));
                Stok.StokSatısFiyat = decimal.Parse(txtSatisFiyati.Text);
                Stok.StokSatısKdv = Decimal.Parse(txtSatisKDV.Text);
                Stok.StokSaveDate = DateTime.Now;
                Stok.StokSaveUser = AnaForm.UserID;
                DB.Tbl_Stoklars.InsertOnSubmit(Stok);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("yeni stok kaydı oluşturuldu");
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void Guncelle()
        {
            try
            {
                Fonksiyonlar.Tbl_Stoklar Stok = DB.Tbl_Stoklars.First(s => s.ID == StokID);
                Stok.StokAdı = txtStokAdi.Text;
                Stok.StokAlısFiyat = decimal.Parse(txtAlisFiyati.Text);
                Stok.StokAlısKdv = decimal.Parse(txtAlisKDV.Text);
                Stok.StokBarkod = txtBarkod.Text;
                Stok.StokBirim = txtBirim.Text;
                Stok.StokGrupID = GrupID;
                Stok.StokKodu = txtStokKodu.Text;
                if (Resim) Stok.StokResim = new System.Data.Linq.Binary(Resimleme.ResimYukleme(pictureBox1.Image));
                Stok.StokSatısFiyat = decimal.Parse(txtSatisFiyati.Text);
                Stok.StokSatısKdv = Decimal.Parse(txtSatisKDV.Text);
                Stok.StokEditDate = DateTime.Now;
                Stok.StokEditUser = AnaForm.UserID;
                DB.SubmitChanges();
                Mesajlar.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }
        void Sil()
        {
            try
            {
                DB.Tbl_Stoklars.DeleteOnSubmit(DB.Tbl_Stoklars.First(s => s.ID == StokID));
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }
        void GrupAc(int ID)
        {
            GrupID = ID;
            txtGrupAdi.Text = DB.Tbl_StokGruplaris.First(s => s.ID == GrupID).GrupAdı;
            txtGrupKodu.Text = DB.Tbl_StokGruplaris.First(s => s.ID == GrupID).GrupKodu;
        }

        public void Ac(int ID)
        {
            Edit = true;
            StokID = ID;
            Fonksiyonlar.Tbl_Stoklar Stok = DB.Tbl_Stoklars.First(s => s.ID == StokID);
            GrupAc(Stok.StokGrupID.Value);
            pictureBox1.Image = Resimleme.ResimGetirme(Stok.StokResim.ToArray());
            txtAlisFiyati.Text = Stok.StokAlısFiyat.ToString();
            txtAlisKDV.Text = Stok.StokAlısKdv.ToString();
            txtBarkod.Text = Stok.StokBarkod;
            txtBirim.Text = Stok.StokBirim;
            pictureBox1.Image = null;
            txtSatisFiyati.Text = Stok.StokSatısFiyat.ToString();
            txtSatisKDV.Text = Stok.StokSatısKdv.ToString();
            txtStokAdi.Text = Stok.StokAdı;
            txtStokKodu.Text = Stok.StokKodu;

        }

        private void txtGrupKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.StokGruplari(true);
            if (ID > 0)
            {
                GrupAc(ID);
            }
            AnaForm.Aktarma = -1;

        }

        private void txtStokKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.StokListesi(true);
            if (ID > 0)
            {
                Ac(ID);

            }
            AnaForm.Aktarma = -1;

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && StokID > 0 && Mesajlar.Sil() == DialogResult.Yes) Sil();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && StokID > 0 && Mesajlar.Guncelle() == DialogResult.Yes)
            {
                Guncelle();
            }
            else
            {
                YeniKaydet();
            }

        }
    }
}