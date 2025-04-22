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
using Otomasyon.Fonksiyonlar;

namespace Otomasyon.Modul_Kasa
{
	public partial class frmKasaTahsilatOdeme: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();

        bool Edit = false;
        int IslemID = -1;
        int CariID = -1;
        int CariHareketID = -1;
        int KasaID = -1;
        string IslemTuru = "Kasa Tahsilat";
        public frmKasaTahsilatOdeme()
		{
            InitializeComponent();
		}

        private void frmKasaTahsilatOdeme_Load(object sender, EventArgs e)
        {
            txtKTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void txtIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            IslemTuru = txtIslemTuru.SelectedItem.ToString();
        }

        void Temizle()
        {
            txtKAciklama.Text = "";
            txtBelgeNo.Text = "";
            txtCariAdi.Text = "";
            txtCariKodu.Text = "";
            txtIslemTuru.Text = "";
            txtKasaAdi.Text = "";
            txtKasaKodu.Text = "";
            txtKTarih.Text = DateTime.Now.ToShortDateString();
            txtKTutar.Text = "0";
            Edit = false;
            IslemID = -1;
            KasaID = -1;
            CariHareketID = -1;
            CariID = -1;
            AnaForm.Aktarma = -1;

;
        }

        void KasaAc(int ID)

        {
            try
            {
                KasaID = ID;
                txtKasaAdi.Text = DB.Tbl_Kasalars.First(s => s.ID == KasaID).KasaAdi;
                txtKasaKodu.Text = DB.Tbl_Kasalars.First(s => s.ID == KasaID).KasaKodu;
            }
            catch (Exception )
            {
                KasaID = -1;
            }

        }

        void CariAc(int ID)

        {
            try
            {
                CariID = ID;
                txtCariAdi.Text = DB.Tbl_Carilers.First(s => s.ID == KasaID).CariAdi;
                txtCariKodu.Text = DB.Tbl_Carilers.First(s => s.ID == KasaID).CariKodu;
            }
            catch (Exception )
            {
                CariID = -1;
            }

        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_KasaHareketleri kasaHareketleri = new Fonksiyonlar.Tbl_KasaHareketleri();
                kasaHareketleri.Aciklama = txtKAciklama.Text;
                kasaHareketleri.BelgeNo = txtBelgeNo.Text;
                kasaHareketleri.CariID = CariID;
                kasaHareketleri.EvrakTuru = txtIslemTuru.SelectedItem.ToString();
                if (txtIslemTuru.SelectedIndex == 0) kasaHareketleri.GCKodu = "G";
                if (txtIslemTuru.SelectedIndex == 1) kasaHareketleri.GCKodu = "C";
                kasaHareketleri.KasaID = KasaID;
                kasaHareketleri.SaveDate = DateTime.Now;
                kasaHareketleri.SaveUser = AnaForm.UserID;
                kasaHareketleri.Tarih = DateTime.Parse(txtKTarih.Text);
                kasaHareketleri.Tutar = decimal.Parse(txtKTutar.Text);
                DB.Tbl_KasaHareketleris.InsertOnSubmit(kasaHareketleri);
                DB.SubmitChanges();
                Mesajlar.YeniKayit(txtIslemTuru.SelectedItem.ToString() + "yeni kasa hareketi olarak işlenmiştir");
                Fonksiyonlar.Tbl_CariHareketleri cariHareketleri = new Fonksiyonlar.Tbl_CariHareketleri();
                cariHareketleri.Aciklama = txtBelgeNo.Text + "belge numaralı" + txtIslemTuru.SelectedItem.ToString() + "İşlemi";
                if (txtIslemTuru.SelectedIndex == 0) cariHareketleri.Alacak = decimal.Parse(txtKTutar.Text);
                if (txtIslemTuru.SelectedIndex == 1) cariHareketleri.Borc = decimal.Parse(txtKTutar.Text);
                cariHareketleri.CariID = CariID;
                cariHareketleri.EvrakID = kasaHareketleri.ID;
                cariHareketleri.EvrakTuru = txtIslemTuru.SelectedItem.ToString();
                cariHareketleri.Tarih = DateTime.Parse(txtKTarih.Text);
                if (txtIslemTuru.SelectedIndex == 0) cariHareketleri.Tipi = "KT";
                if (txtIslemTuru.SelectedIndex == 1) cariHareketleri.Tipi = "KÖ";
                cariHareketleri.SaveDate = DateTime.Now;
                cariHareketleri.SaveUser = AnaForm.UserID;
                DB.Tbl_CariHareketleris.InsertOnSubmit(cariHareketleri);
                DB.SubmitChanges();
                Mesajlar.YeniKayit(txtIslemTuru.SelectedItem.ToString() + "yeni cari hareketi olarak işlenmiştir");
                Temizle();

            }
            catch(Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void Guncelle()
        {

            try
            {
                Fonksiyonlar.Tbl_KasaHareketleri kasaHareketleri = DB.Tbl_KasaHareketleris.First(s => s.ID == IslemID);
                kasaHareketleri.Aciklama = txtKAciklama.Text;
                kasaHareketleri.BelgeNo = txtBelgeNo.Text;
                kasaHareketleri.CariID = CariID;
                kasaHareketleri.EvrakTuru = txtIslemTuru.SelectedItem.ToString();
                if (txtIslemTuru.SelectedIndex == 0) kasaHareketleri.GCKodu = "G";
                if (txtIslemTuru.SelectedIndex == 1) kasaHareketleri.GCKodu = "C";
                kasaHareketleri.KasaID = KasaID;
                kasaHareketleri.SaveDate = DateTime.Now;
                kasaHareketleri.SaveUser = AnaForm.UserID;
                kasaHareketleri.Tarih = DateTime.Parse(txtKTarih.Text);
                kasaHareketleri.Tutar = decimal.Parse(txtKTutar.Text);
                DB.SubmitChanges();
                Mesajlar.Guncelle(true);
                Fonksiyonlar.Tbl_CariHareketleri cariHareketleri = DB.Tbl_CariHareketleris.First(s => s.ID == CariHareketID);
                cariHareketleri.Aciklama = txtBelgeNo.Text + "belge numaralı" + txtIslemTuru.SelectedItem.ToString() + "İşlemi";
                if (txtIslemTuru.SelectedIndex == 0) cariHareketleri.Alacak = decimal.Parse(txtKTutar.Text);
                if (txtIslemTuru.SelectedIndex == 1) cariHareketleri.Borc = decimal.Parse(txtKTutar.Text);
                cariHareketleri.CariID = CariID;
                cariHareketleri.EvrakID = kasaHareketleri.ID;
                cariHareketleri.EvrakTuru = txtIslemTuru.SelectedItem.ToString();
                cariHareketleri.Tarih = DateTime.Parse(txtKTarih.Text);
                if (txtIslemTuru.SelectedIndex == 0) cariHareketleri.Tipi = "KT";
                if (txtIslemTuru.SelectedIndex == 1) cariHareketleri.Tipi = "KÖ";
                cariHareketleri.SaveDate = DateTime.Now;
                cariHareketleri.SaveUser = AnaForm.UserID;
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
                DB.Tbl_KasaHareketleris.DeleteOnSubmit(DB.Tbl_KasaHareketleris.First(s => s.ID == IslemID));
                DB.Tbl_CariHareketleris.DeleteOnSubmit(DB.Tbl_CariHareketleris.First(s => s.ID == CariHareketID));
                Temizle();
            }
            catch(Exception e)
            {
                Mesajlar.Hata(e);
            }
            
        }

        public void Ac(int HareketID)
        {
            try
            {
                Edit = true;
                IslemID = HareketID;
                Fonksiyonlar.Tbl_KasaHareketleri kasaHareketleri = DB.Tbl_KasaHareketleris.First(s => s.ID == IslemID);
                CariHareketID = DB.Tbl_CariHareketleris.First(s => s.EvrakTuru == kasaHareketleri.EvrakTuru && s.EvrakID == IslemID).ID;
                MessageBox.Show("Cari Hareket ID :" + CariHareketID.ToString());
                txtKAciklama.Text = kasaHareketleri.Aciklama;
                txtBelgeNo.Text = kasaHareketleri.BelgeNo;
                if (kasaHareketleri.EvrakTuru == "kasa tahsilat") txtIslemTuru.SelectedIndex = 0;
                if (kasaHareketleri.EvrakTuru == "kasa ödeme") txtIslemTuru.SelectedIndex = 1;
                txtKTarih.Text = kasaHareketleri.Tarih.Value.ToShortDateString();
                KasaAc(kasaHareketleri.KasaID.Value);
                CariAc(kasaHareketleri.CariID.Value);
            }
            catch(Exception e)
            {
                Temizle();
                Mesajlar.Hata(e);
            }
        }

        private void txtKasaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.KasaListesi(true);
            if(ID>0)
            {
                KasaAc(ID);
                AnaForm.Aktarma = -1;
            }
        }

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.CariListesi(true);
            if (ID > 0)
            {
                CariAc(ID);
                AnaForm.Aktarma = -1;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0 && CariHareketID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0 &&  CariHareketID>0&& Mesajlar.Sil() == DialogResult.Yes) Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}