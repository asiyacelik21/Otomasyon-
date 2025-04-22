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
using DevExpress.XtraEditors.Frames;

namespace Otomasyon.Modul_Banka
{
	public partial class frmParaTransferi: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();

        bool Edit = false;
        int BankaID = -1;
        int CariID = -1;
        int IslemID = -1;
        public frmParaTransferi()
		{
            InitializeComponent();
		}

        private void txtTransferTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtTransferTuru.SelectedIndex==0)
            {
                rbtnGelen.Text = "Gelen Havale";
                rbtnGiden.Text = "Giden Havale";
               
            }
            else if(txtTransferTuru.SelectedIndex==1)
            {
                rbtnGelen.Text = "Gelen EFT";
                rbtnGiden.Text = "Giden EFT";
               
            }
        }

        private void frmBankaListesi_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        void Temizle()
        {
            txtAciklama.Text = "";
            txtBelgeNo.Text = "";
            txtCariAdi.Text = "";
            txtCariKodu.Text = "";
            txtHesapAdi.Text = "";
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "0";
            Edit = false;
            BankaID = -1;
            CariID = -1;
            IslemID = -1;
            AnaForm.Aktarma = -1;
        }

        void BankaAc(int ID)
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

        void CariAc(int ID)
        {
            try
            {
                CariID = ID;
                txtCariKodu.Text = DB.Tbl_Carilers.First(s => s.ID == CariID).CariKodu;
                txtCariAdi.Text = DB.Tbl_Carilers.First(s => s.ID == CariID).CariAdi;
            }
            catch(Exception e)
            {
                mesajlar.Hata(e);
            }
        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_BankaHareketleri Banka = new Fonksiyonlar.Tbl_BankaHareketleri();
                Banka.Aciklama = txtAciklama.Text;
                Banka.BankaID = BankaID;
                Banka.BelgeNo = txtBelgeNo.Text;
                Banka.CariID = CariID;
                Banka.EvrakTuru = txtTransferTuru.SelectedItem.ToString();
                if (rbtnGelen.Checked) Banka.GCKodu = "G";
                if (rbtnGiden.Checked) Banka.GCKodu = "C";
                Banka.Tarih = DateTime.Parse(txtTarih.Text);
                Banka.Tutar = decimal.Parse(txtTutar.Text);
                Banka.SaveDate = DateTime.Now;
                Banka.SaveUser = AnaForm.UserID;
                DB.Tbl_BankaHareketleris.InsertOnSubmit(Banka);
                DB.SubmitChanges();
                Fonksiyonlar.Tbl_CariHareketleri Cari = new Fonksiyonlar.Tbl_CariHareketleri();
                Cari.Aciklama = txtAciklama.Text;
                if (rbtnGelen.Checked) Cari.Alacak = decimal.Parse(txtTutar.Text);
                if (rbtnGiden.Checked) Cari.Borc = decimal.Parse(txtTutar.Text);
                Cari.CariID = CariID;
                Cari.EvrakID = Banka.ID;
                Cari.EvrakTuru = txtTransferTuru.SelectedItem.ToString();
                Cari.Tarih = DateTime.Parse(txtTarih.Text);
                if (txtTransferTuru.SelectedIndex == 0) Cari.Tipi = "BH";
                if (txtTransferTuru.SelectedIndex == 1) Cari.Tipi = "EFT";
                Cari.SaveDate = DateTime.Now;
                Cari.SaveUser = AnaForm.UserID;
                DB.Tbl_CariHareketleris.InsertOnSubmit(Cari);
                DB.SubmitChanges();
                mesajlar.YeniKayit("para transfer kaydı işlendi");
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
                Fonksiyonlar.Tbl_BankaHareketleri Banka = DB.Tbl_BankaHareketleris.First(s => s.ID == IslemID);
                Banka.Aciklama = txtAciklama.Text;
                Banka.BankaID = BankaID;
                Banka.BelgeNo = txtBelgeNo.Text;
                Banka.CariID = CariID;
                Banka.EvrakTuru = txtTransferTuru.SelectedItem.ToString();
                if (rbtnGelen.Checked) Banka.GCKodu = "G";
                if (rbtnGiden.Checked) Banka.GCKodu = "C";
                Banka.Tarih = DateTime.Parse(txtTarih.Text);
                Banka.Tutar = decimal.Parse(txtTutar.Text);
                Banka.EditDate = DateTime.Now;
                Banka.EditUser = AnaForm.UserID;
                DB.SubmitChanges();
                Fonksiyonlar.Tbl_CariHareketleri Cari = DB.Tbl_CariHareketleris.First(s => s.EvrakTuru == txtTransferTuru.SelectedItem.ToString() && s.EvrakID == IslemID);
                Cari.Aciklama = txtAciklama.Text;
                if (rbtnGelen.Checked) Cari.Alacak = decimal.Parse(txtTutar.Text);
                if (rbtnGiden.Checked) Cari.Borc = decimal.Parse(txtTutar.Text);
                Cari.CariID = CariID;
                Cari.EvrakID = Banka.ID;
                Cari.EvrakTuru = txtTransferTuru.SelectedItem.ToString();
                Cari.Tarih = DateTime.Parse(txtTarih.Text);
                if (txtTransferTuru.SelectedIndex == 0) Cari.Tipi = "BH";
                if (txtTransferTuru.SelectedIndex == 1) Cari.Tipi = "EFT";
                Cari.EditDate = DateTime.Now;
                Cari.EditUser = AnaForm.UserID;
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
                DB.Tbl_CariHareketleris.DeleteOnSubmit(DB.Tbl_CariHareketleris.First(s => s.EvrakTuru == txtTransferTuru.SelectedItem.ToString() && s.EvrakID == IslemID));
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
                Edit = false;
                IslemID = ID;
                Fonksiyonlar.Tbl_BankaHareketleri Banka = DB.Tbl_BankaHareketleris.First(s => s.ID == IslemID);
                BankaAc(Banka.BankaID.Value);
                CariAc(Banka.CariID.Value);
                txtAciklama.Text = Banka.Aciklama;
                txtBelgeNo.Text = Banka.BelgeNo;
                txtTarih.Text = Banka.Tarih.Value.ToShortDateString();
                txtTransferTuru.Text = Banka.EvrakTuru;
                txtTutar.Text = Banka.Tutar.ToString();
                if (Banka.GCKodu == "G") rbtnGelen.Checked = true;
                if (Banka.GCKodu == "C") rbtnGiden.Checked = true;
            }
            catch(Exception e)
            {
                mesajlar.Hata(e);
            }
        }

        private void txtHesapAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = formlar.BankaListesi(true);
            if (ID > 0) BankaAc(ID);
            AnaForm.Aktarma = -1;
        }

        private void txtCariKodu_EditValueChanged(object sender, EventArgs e)
        {
            int ID = formlar.CariListesi(true);
            if (ID > 0) CariAc(ID);
            AnaForm.Aktarma = -1;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && CariID > 0 && BankaID > 0 && IslemID > 0 && mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && CariID > 0 && BankaID > 0 && IslemID > 0 && mesajlar.Sil() == DialogResult.Yes) Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}