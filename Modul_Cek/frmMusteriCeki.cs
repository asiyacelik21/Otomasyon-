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

namespace Otomasyon.Modul_Cek
{
    public partial class frmMusteriCeki : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesajlar = new Fonksiyonlar.Mesajlar();

        int CariID = -1;
        int CekID = -1;
        bool Edit = false;
        public frmMusteriCeki()
        {
            InitializeComponent();
        }
        void Temizle()
        {
            txtAciklama.Text = "";
            txtAsilBorclu.Text = "";
            txtBanka.Text = "";
            txtBelgeNo.Text = "";
            txtCariAdi.Text = "";
            txtCariKodu.Text = "";
            txtCekNo.Text = "";
            txtCekTuru.SelectedIndex = 0;
            txtHesapNo.Text = "";
            txtSube.Text = "";
            txtTutar.Text = "";
            txtVadeTarihi.Text = DateTime.Now.ToShortDateString();
            CariID = -1;
            CekID = -1;
            Edit = false;
            AnaForm.Aktarma = -1;
        }
        private void frmMusteriCeki_Load(object sender, EventArgs e)
        {
            txtVadeTarihi.Text = DateTime.Now.ToShortDateString();
        }

        void YeniCekKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_Cekler Cek = new Fonksiyonlar.Tbl_Cekler();
                Cek.Aciklama = txtAciklama.Text;
                if (txtCekTuru.SelectedIndex == 0) Cek.AcKodu = "A";
                if (txtCekTuru.SelectedIndex == 1) Cek.AcKodu = "C";
                Cek.AlinanCariID = CariID;
                Cek.Banka = txtBanka.Text;
                Cek.BelgeNo = txtBelgeNo.Text;
                Cek.CekNo = txtCekNo.Text;
                Cek.Durumu = "Potföy";
                Cek.HesapNo = txtHesapNo.Text;
                Cek.Sube = txtSube.Text;
                Cek.Tahsil = "Hayır";
                Cek.VadeTarihi = DateTime.Parse(txtVadeTarihi.Text);
                Cek.Tutar = decimal.Parse(txtTutar.Text);
                Cek.TİPİ = "Müşteri Çeki";
                Cek.SaveDate = DateTime.Now;
                Cek.SaveUser = AnaForm.UserID;
                DB.Tbl_Ceklers.InsertOnSubmit(Cek);
                DB.SubmitChanges();
                mesajlar.YeniKayit(txtCekNo.Text + "No'lu müşteri çeki kaydı gerçekleşmiştir.");
                Fonksiyonlar.Tbl_CariHareketleri cariHareketleri = new Fonksiyonlar.Tbl_CariHareketleri();
                cariHareketleri.Aciklama = txtBelgeNo.Text + " Belge Numaralı ve " + txtCekNo.Text + "Çek Numaralı Müşteri Çeki";
                cariHareketleri.CariID = CariID;
                cariHareketleri.EvrakID = Cek.ID;
                cariHareketleri.EvrakTuru = "Müşteri Çeki";
                cariHareketleri.Tarih = DateTime.Now;
                cariHareketleri.Tipi = "MÇ";
                cariHareketleri.SaveDate = DateTime.Now;
                cariHareketleri.SaveUser = AnaForm.UserID;
                DB.Tbl_CariHareketleris.InsertOnSubmit(cariHareketleri);
                DB.SubmitChanges();
                mesajlar.YeniKayit(txtCekNo.Text + "No'lu müşteri çeki cari kaydı gerçekleşmiştir.");
                Temizle();
            }
            catch (Exception e)
            {
                mesajlar.Hata(e);
            }


        }

        void Guncelle()
        {
            try
            {
                Fonksiyonlar.Tbl_Cekler Cek = DB.Tbl_Ceklers.First(s => s.ID == CekID);
                Cek.Aciklama = txtAciklama.Text;
                if (txtCekTuru.SelectedIndex == 0) Cek.AcKodu = "A";
                if (txtCekTuru.SelectedIndex == 1) Cek.AcKodu = "C";
                Cek.AlinanCariID = CariID;
                Cek.Banka = txtBanka.Text;
                Cek.BelgeNo = txtBelgeNo.Text;
                Cek.CekNo = txtCekNo.Text;
                Cek.Durumu = "Potföy";
                Cek.HesapNo = txtHesapNo.Text;
                Cek.Sube = txtSube.Text;
                Cek.Tahsil = "Hayır";
                Cek.VadeTarihi = DateTime.Parse(txtVadeTarihi.Text);
                Cek.Tutar = decimal.Parse(txtTutar.Text);
                Cek.TİPİ = "Müşteri Çeki";
                Cek.EditDate = DateTime.Now;
                Cek.EditUser = AnaForm.UserID;
                DB.SubmitChanges();
                Fonksiyonlar.Tbl_CariHareketleri cariHareketleri = DB.Tbl_CariHareketleris.First(s => s.EvrakID == CekID && s.EvrakTuru == "Müşteri Çeki"&& s.Tipi=="MÇ");
                cariHareketleri.Aciklama = txtBelgeNo.Text + " Belge Numaralı ve " + txtCekNo.Text + "Çek Numaralı Müşteri Çeki";
                cariHareketleri.CariID = CariID;
                cariHareketleri.EvrakID = Cek.ID;
                cariHareketleri.EvrakTuru = "Müşteri Çeki";
                cariHareketleri.Tarih = DateTime.Now;
                cariHareketleri.Tipi = "MÇ";
                cariHareketleri.EditDate = DateTime.Now;
                cariHareketleri.EditUser = AnaForm.UserID;
                DB.SubmitChanges();
                mesajlar.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                mesajlar.Hata(e);
            }

        }

        void CariAc(int ID)
        {
            CariID = ID;
            Fonksiyonlar.Tbl_Cariler Cari = DB.Tbl_Carilers.First(s => s.ID == CariID);
            txtCariAdi.Text = Cari.CariAdi;
            txtCariKodu.Text = Cari.CariKodu;
        }
    }
}