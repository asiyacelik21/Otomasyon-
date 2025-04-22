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

namespace Otomasyon.Modul_Cari
{
    public partial class frmCariAcilisKarti : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Numaralar Numaralar = new Fonksiyonlar.Numaralar();

        bool Edit = false;
        int CariID = -1;
        int GrupID = -1;
        public frmCariAcilisKarti()
        {
            InitializeComponent();
        }

        private void frmCariAcilisKarti_Load(object sender, EventArgs e)
        {
            txtCariKodu.Text = Numaralar.CariKodNumarasi();
        }

        void Temizle()
        {
            foreach (Control CT in groupControl1.Controls)
                if (CT is DevExpress.XtraEditors.TextEdit || CT is DevExpress.XtraEditors.ButtonEdit) CT.Text = "";

            foreach (Control CE in groupControl2.Controls)
                if (CE is DevExpress.XtraEditors.TextEdit || CE is DevExpress.XtraEditors.ButtonEdit || CE is DevExpress.XtraEditors.MemoEdit) CE.Text = "";
            txtCariKodu.Text = Numaralar.CariKodNumarasi();
            Edit = false;
            CariID = 1;
            GrupID = -1;
            AnaForm.Aktarma = -1;
        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_Cariler Cari = new Fonksiyonlar.Tbl_Cariler();
                Cari.Adres = txtAdres.Text;
                Cari.CariAdi = txtCariAdi.Text;
                Cari.CariKodu = txtCariKodu.Text;
                Cari.Fax1 = txtFax1.Text;
                Cari.Fax2 = txtFax2.Text;
                Cari.GrupID = GrupID;
                Cari.Ilce = txtİlce.Text;
                Cari.Mailİnfo = txtMailİnfo.Text;
                Cari.Sehir = txtSehir.Text;
                Cari.Telefon1 = txtTelefon1.Text;
                Cari.Telefon2 = txtTelefon2.Text;
                Cari.Ulke = txtUlke.Text;
                Cari.VergiDairesi = txtVeriDairesi.Text;
                Cari.VergiNo = txtVeriNo.Text;
                Cari.WebAdres = txtWebAdres.Text;
                Cari.Yetkili1 = txtYetkili1.Text;
                Cari.Yetkili2 = txtYetkili2.Text;
                Cari.YetkiliEmail1 = txtYetkiliEmail1.Text;
                Cari.YetkiliEmail2 = txtYetkiliEmail2.Text;
                Cari.SaveDate = DateTime.Now;
                Cari.SaveUser = AnaForm.UserID;
                DB.Tbl_Carilers.InsertOnSubmit(Cari);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("yeni cari kaydı oluşturulmuştur");
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
                Fonksiyonlar.Tbl_Cariler Cari = DB.Tbl_Carilers.First(s => s.ID == CariID);
                Cari.Adres = txtAdres.Text;
                Cari.CariAdi = txtCariAdi.Text;
                Cari.CariKodu = txtCariKodu.Text;
                Cari.Fax1 = txtFax1.Text;
                Cari.Fax2 = txtFax2.Text;
                Cari.GrupID = GrupID;
                Cari.Ilce = txtİlce.Text;
                Cari.Mailİnfo = txtMailİnfo.Text;
                Cari.Sehir = txtSehir.Text;
                Cari.Telefon1 = txtTelefon1.Text;
                Cari.Telefon2 = txtTelefon2.Text;
                Cari.Ulke = txtUlke.Text;
                Cari.VergiDairesi = txtVeriDairesi.Text;
                Cari.VergiNo = txtVeriNo.Text;
                Cari.WebAdres = txtWebAdres.Text;
                Cari.Yetkili1 = txtYetkili1.Text;
                Cari.Yetkili2 = txtYetkili2.Text;
                Cari.YetkiliEmail1 = txtYetkiliEmail1.Text;
                Cari.YetkiliEmail2 = txtYetkiliEmail2.Text;
                Cari.EditDate = DateTime.Now;
                Cari.EditUser = AnaForm.UserID;
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
                DB.Tbl_Carilers.DeleteOnSubmit(DB.Tbl_Carilers.First(s => s.ID == CariID));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }

        }

        void GrupAc(int ID)
        {
            try
            {
                GrupID = ID;
                Fonksiyonlar.Tbl_CariGruplari Grup = DB.Tbl_CariGruplaris.First(s => s.ID == GrupID);
                txtCariGrupAdi.Text = Grup.GrupAdı;
                txtCariGrupKodu.Text = Grup.GrupKodu;

            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        public void Ac(int ID)
        {
            try
            {
                Edit = true;
                CariID = ID;
                Fonksiyonlar.Tbl_Cariler Cari = DB.Tbl_Carilers.First(s => s.ID == CariID);
                txtAdres.Text = Cari.Adres;
                txtCariAdi.Text = Cari.CariAdi;
                txtCariKodu.Text = Cari.CariKodu;
                txtFax1.Text = Cari.Fax1;
                txtFax2.Text = Cari.Fax2;
                txtİlce.Text = Cari.Ilce;
                txtMailİnfo.Text = Cari.Mailİnfo;
                txtSehir.Text = Cari.Sehir;
                txtTelefon1.Text = Cari.Telefon1;
                txtTelefon2.Text = Cari.Telefon2;
                txtUlke.Text = Cari.Ulke;
                txtVeriDairesi.Text = Cari.VergiDairesi;
                txtVeriNo.Text = Cari.VergiNo;
                txtWebAdres.Text = Cari.WebAdres;
                txtYetkili1.Text = Cari.Yetkili1;
                txtYetkili2.Text = Cari.Yetkili2;
                txtYetkiliEmail1.Text = Cari.YetkiliEmail1;
                txtYetkiliEmail2.Text = Cari.YetkiliEmail2;
                GrupAc(Cari.GrupID.Value);

            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && CariID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && CariID > 0 && Mesajlar.Sil() == DialogResult.Yes) Sil();

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCariGrupKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.CariGruplari(true);
            if (ID > 0)
            {
                GrupAc(ID);
            }
            AnaForm.Aktarma = -1;

        }

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Formlar.CariListesi(true);
            if (ID > 0)
            {
                Ac(ID);
            }
            AnaForm.Aktarma = -1;

        }
    }
}
    

    