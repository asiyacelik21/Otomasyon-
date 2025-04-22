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

namespace Otomasyon.Modul_Cari
{
	public partial class frmCariGruplari: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();

        public bool Secim = false;
        bool Edit = false;
        int SecimID = -1;
        public frmCariGruplari()
		{
            InitializeComponent();
		}

        void Temizle()
        {
            txtGrupAdi.Text = "";
            txtGrupKodu.Text = "";
            Edit = false;
            SecimID = -1;
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.Tbl_CariGruplaris
                      select s;
            liste.DataSource=lst;
        }

        void Sec()
        {
            try
            {
                Edit = true;
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtGrupAdi.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtGrupKodu.Text = gridView1.GetFocusedRowCellValue("ID").ToString();

            }
            catch (Exception)
            {
                Edit = false;
                SecimID = -1;
            }
        }

        void Guncelle()
        {
            try
            {
                Fonksiyonlar.Tbl_CariGruplari Grup = DB.Tbl_CariGruplaris.First(s => s.ID == SecimID);
                Grup.GrupAdı = txtGrupAdi.Text;
                Grup.GrupKodu = txtGrupKodu.Text;
                Grup.EditDate = DateTime.Now;
                Grup.EditUser = AnaForm.UserID;
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
                DB.Tbl_CariGruplaris.DeleteOnSubmit(DB.Tbl_CariGruplaris.First(s => s.ID == SecimID));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }

        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_CariGruplari Grup = new Fonksiyonlar.Tbl_CariGruplari();
                Grup.GrupAdı = txtGrupAdi.Text;
                Grup.GrupKodu = txtGrupKodu.Text;
                Grup.SaveDate = DateTime.Now;
                Grup.SaveUser = AnaForm.UserID;
                DB.Tbl_CariGruplaris.InsertOnSubmit(Grup);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("Yeni cari grup kaydı oluşturuldu");
                Temizle();
            }
            catch (Exception e)
            {
                Mesajlar.Hata(e);
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && SecimID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && SecimID > 0 && Mesajlar.Sil() == DialogResult.Yes) Sil();

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmCariGruplari_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim && SecimID > 0)
            {
                AnaForm.Aktarma = SecimID;
                this.Close();
            }

        }
    }
}