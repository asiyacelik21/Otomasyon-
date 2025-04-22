using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Banka
{
	public partial class frmBankaİslem: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();

        bool Edit = false;
        int IslemID = -1;
        int BankaID = -1;
        public frmBankaİslem()
		{
            InitializeComponent();
		}

        private void frmBankaİslem_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        void Temizle()
        {
            txtAciklama.Text = "";
            txtBelgeNo.Text = "";
            txtHesapAdi.Text = "";
            txtHesapNo.Text = "";
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "0";
            Edit = false;
            IslemID = -1;
            BankaID = -1;
            AnaForm.Aktarma = -1;

        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_BankaHareketleri Hareket = new Fonksiyonlar.Tbl_BankaHareketleri();
                Hareket.Aciklama = txtAciklama.Text;
                Hareket.BankaID = BankaID;
                Hareket.BelgeNo = txtBelgeNo.Text;
                Hareket.EvrakTuru = "Banka İşlem";
                if (rbtnGiris.Checked) Hareket.GCKodu = "G";
                if (rbtnCikis.Checked) Hareket.GCKodu = "C";
                Hareket.Tarih = DateTime.Parse(txtTarih.Text);
                Hareket.Tutar = decimal.Parse(txtTutar.Text);
                Hareket.SaveDate = DateTime.Now;
                Hareket.SaveUser = AnaForm.UserID;
                DB.Tbl_BankaHareketleris.InsertOnSubmit(Hareket);
                DB.SubmitChanges();
                mesajlar.YeniKayit("Banka İşlemi Kaydı Yapılmıştır");
                Temizle();

                   
            }
            catch(Exception e)
            {
                mesajlar.Hata(e);
            }
        }

        void Guncelle()
        {
            try
            {
                Fonksiyonlar.Tbl_BankaHareketleri Hareket = DB.Tbl_BankaHareketleris.First(s => s.ID == IslemID);
                Hareket.Aciklama = txtAciklama.Text;
                Hareket.BankaID = BankaID;
                Hareket.BelgeNo = txtBelgeNo.Text;
                Hareket.EvrakTuru = "Banka İşlem";
                if (rbtnGiris.Checked) Hareket.GCKodu = "G";
                if (rbtnCikis.Checked) Hareket.GCKodu = "C";
                Hareket.Tarih = DateTime.Parse(txtTarih.Text);
                Hareket.Tutar = decimal.Parse(txtTutar.Text);
                Hareket.EditDate = DateTime.Now;
                Hareket.EditUser = AnaForm.UserID;
                DB.SubmitChanges();
                mesajlar.Guncelle(true);
                Temizle();


            }
            catch (Exception e)
            {
                mesajlar.Hata(e);
            }
        }

        void Sil()
        {
            try
            {
                DB.Tbl_BankaHareketleris.DeleteOnSubmit(DB.Tbl_BankaHareketleris.First(s => s.ID == IslemID));
                DB.SubmitChanges();
                Temizle();
            }
            catch(Exception e)
            {
                mesajlar.Hata(e);
            }
           
        }

        public void Ac(int ID)
        {
            try
            {
                Edit = true;
                IslemID = ID;
                Fonksiyonlar.Tbl_BankaHareketleri Hareket = DB.Tbl_BankaHareketleris.First(s => s.ID == IslemID);
                BankaAc(Hareket.BankaID.Value);
                txtAciklama.Text = Hareket.Aciklama;
                txtBelgeNo.Text = Hareket.BelgeNo;
                txtTarih.Text = Hareket.Tarih.Value.ToShortDateString();
                txtTutar.Text = Hareket.Tutar.ToString();
                if (Hareket.GCKodu == "G") rbtnGiris.Checked = true;
                if (Hareket.GCKodu == "C") rbtnCikis.Checked = true;
            }
            catch(Exception e)
            {
                mesajlar.Hata(e);
            }
        }

        public void BankaAc(int ID)
        {
            try
            {
                BankaID = ID;
                txtHesapAdi.Text = DB.Tbl_Bankalars.First(s => s.ID == BankaID).HesapAdi;
                txtHesapNo.Text = DB.Tbl_Bankalars.First(s => s.ID == BankaID).HesapNo;

            }
            catch(Exception e)
            {
                mesajlar.Hata(e);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0 && mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0 && mesajlar.Sil() == DialogResult.Yes) Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHesapAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = formlar.BankaListesi(true);
            if (ID > 0) BankaAc(ID);
            AnaForm.Aktarma = -1;
        }
    }
}