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

namespace Otomasyon.Modul_Kasa
{
    public partial class frmKasaDevirİslem : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();


        bool Edit = false;
        int KasaID = -1;
        int IslemID = -1;
        public frmKasaDevirİslem()
        {
            InitializeComponent();
        }

        private void frmKasaDevirİslem_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
       

        void Temizle()
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtAciklama.Text = "";
            txtBelgeNo.Text = "";
            txtKasaAdi.Text = "";
            txtKasaKodu.Text = "";
            txtTutar.Text = "";
            Edit = false;
            KasaID = -1;
            IslemID = -1;
            AnaForm.Aktarma = -1;
        }
        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_KasaHareketleri Hareket = new Fonksiyonlar.Tbl_KasaHareketleri();
                Hareket.Aciklama = txtAciklama.Text;
                Hareket.BelgeNo = txtBelgeNo.Text;
                Hareket.EvrakTuru = "Kasa Devir Kartı";
                if (rbtnCikis.Checked) Hareket.GCKodu = "C";
                if (rbtnGiris.Checked) Hareket.GCKodu = "G";
                Hareket.KasaID = KasaID;
                Hareket.Tarih = DateTime.Parse(txtTarih.Text);
                Hareket.Tutar = decimal.Parse(txtTutar.Text);
                Hareket.SaveDate = DateTime.Now;
                Hareket.SaveUser = AnaForm.UserID;
                DB.Tbl_KasaHareketleris.InsertOnSubmit(Hareket);
                DB.SubmitChanges();
                mesajlar.YeniKayit("Devir Kartı Hareket Kaydı İşlenmiştir");
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
                Fonksiyonlar.Tbl_KasaHareketleri Hareket = DB.Tbl_KasaHareketleris.First(s => s.ID == IslemID);
                Hareket.Aciklama = txtAciklama.Text;
                Hareket.BelgeNo = txtBelgeNo.Text;
                Hareket.EvrakTuru = "Kasa Devir Kartı";
                if (rbtnCikis.Checked) Hareket.GCKodu = "C";
                if (rbtnGiris.Checked) Hareket.GCKodu = "G";
                Hareket.KasaID = KasaID;
                Hareket.Tarih = DateTime.Parse(txtTarih.Text);
                Hareket.Tutar = decimal.Parse(txtTutar.Text);
                Hareket.SaveDate = DateTime.Now;
                Hareket.SaveUser = AnaForm.UserID;
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
                DB.Tbl_KasaHareketleris.DeleteOnSubmit(DB.Tbl_KasaHareketleris.First(s => s.ID == IslemID));
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
                IslemID = ID;
                Edit = true;
                Fonksiyonlar.Tbl_KasaHareketleri Hareket = DB.Tbl_KasaHareketleris.First(s => s.ID == IslemID);
                txtAciklama.Text = Hareket.Aciklama;
                txtBelgeNo.Text = Hareket.BelgeNo;
                KasaAc(Hareket.KasaID.Value);
                txtTarih.Text = Hareket.Tarih.Value.ToShortDateString();
                txtTutar.Text = Hareket.Tutar.Value.ToString();
                if (Hareket.GCKodu == "G") rbtnGiris.Checked = true;
                if (Hareket.GCKodu == "C") rbtnCikis.Checked = true;

            }
            catch(Exception e)
            {
                mesajlar.Hata(e);
            }
        }

        void KasaAc(int ID)

        {
            try
            {
                KasaID = ID;
                txtKasaAdi.Text = DB.Tbl_Kasalars.First(s => s.ID == KasaID).KasaAdi;
               txtKasaKodu.Text = DB.Tbl_Kasalars.First(s => s.ID == KasaID).KasaKodu;
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

        private void txtKasaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = formlar.KasaListesi(true);
            if(ID>0)
            {
                KasaAc(ID);
                AnaForm.Aktarma = -1;
            }
        }

    }
}