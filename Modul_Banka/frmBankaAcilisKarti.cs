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
	public partial class frmBankaAcilisKarti: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        bool Edit = false;
        int SecimId = -1;
        public frmBankaAcilisKarti()
		{
            InitializeComponent();
		}

        private void frmBankaAcilisKarti_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Temizle()
        {
            txtAdres.Text = "";
            txtBankaAdi.Text = "";
            txtHesapAdi.Text = "";
            txtHesapNo.Text = "";
            txtIban.Text = "";
            txtBankaSubesi.Text = "";
            txtSubeTel.Text = "";
            txtYetkiliTemsilci.Text = "";
            txtYTEmail.Text = "";
            Edit = false;
            SecimId = -1;
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.Tbl_Bankalars
                      select s;
            Liste.DataSource = lst;
        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_Bankalar Banka = new Fonksiyonlar.Tbl_Bankalar();
                Banka.Adres = txtAdres.Text;
                Banka.BankaAdi = txtBankaAdi.Text;
                Banka.HesapAdi = txtHesapAdi.Text;
                Banka.HesapNo = txtHesapNo.Text;
                Banka.Iban = txtIban.Text;
                Banka.Sube = txtBankaSubesi.Text;
                Banka.Tel = txtSubeTel.Text;
                Banka.Temsilci = txtYetkiliTemsilci.Text;
                Banka.TemsilciEmail = txtYTEmail.Text;
                Banka.SaveDate = DateTime.Now;
                Banka.SaveUser = AnaForm.UserID;
                DB.Tbl_Bankalars.InsertOnSubmit(Banka);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("Yeni Banka Kaydı Oluşturulmuştur");
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
                Fonksiyonlar.Tbl_Bankalar Banka = DB.Tbl_Bankalars.First(s => s.ID == SecimId);
                Banka.Adres = txtAdres.Text;
                Banka.BankaAdi = txtBankaAdi.Text;
                Banka.HesapAdi = txtHesapAdi.Text;
                Banka.HesapNo = txtHesapNo.Text;
                Banka.Iban = txtIban.Text;
                Banka.Sube = txtBankaSubesi.Text;
                Banka.Tel = txtSubeTel.Text;
                Banka.Temsilci = txtYetkiliTemsilci.Text;
                Banka.TemsilciEmail = txtYTEmail.Text;
                Banka.EditDate = DateTime.Now;
                Banka.EditUser = AnaForm.UserID;
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
                DB.Tbl_Bankalars.DeleteOnSubmit(DB.Tbl_Bankalars.First(s => s.ID == SecimId));
                DB.SubmitChanges();
                Temizle();
            }
            catch(Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void Sec()
        {
            try
            {
                Edit = true;
                SecimId = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                if (SecimId > 0) Ac();
            }
            catch(Exception e)
            {
                Edit = false;
                SecimId = -1;
            }
        }

        void Ac()
        {
            try
            {
                Fonksiyonlar.Tbl_Bankalar Banka = DB.Tbl_Bankalars.First(s => s.ID == SecimId);
                txtAdres.Text = Banka.Adres;
                txtBankaAdi.Text = Banka.BankaAdi;
                txtHesapAdi.Text = Banka.HesapAdi;
                txtHesapNo.Text = Banka.HesapNo;
                txtIban.Text = Banka.Iban;
                txtBankaSubesi.Text = Banka.Sube;
                txtSubeTel.Text = Banka.Tel;
                txtYetkiliTemsilci.Text = Banka.Temsilci;
                txtYTEmail.Text = Banka.TemsilciEmail;
            }
            catch(Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && SecimId > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && SecimId > 0 && Mesajlar.Sil() == DialogResult.Yes) Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}