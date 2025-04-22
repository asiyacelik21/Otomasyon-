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

namespace Otomasyon.Modul_Stok
{
	public partial class frmStokGruplari: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();

        public bool Secim = false;
        int SecimID = -1;
        bool Edit = false;
        public frmStokGruplari()
		{
            InitializeComponent();
		}

        private void frmStokGruplari_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.Tbl_StokGruplaris
                      select s;
            liste.DataSource = lst;
        }

        void Temizle()
        {
            txtGrupKodu.Text = "";
            txtGrupAdi.Text = "";
            Listele();
            Edit = false;
        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_StokGruplari Grup = new Fonksiyonlar.Tbl_StokGruplari();
                Grup.GrupAdı = txtGrupAdi.Text;
                Grup.GrupKodu = txtGrupKodu.Text;
                Grup.GrupSaveDate = DateTime.Now;
                Grup.GrupSaveUser = AnaForm.UserID;
                DB.Tbl_StokGruplaris.InsertOnSubmit(Grup);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("yeni grup kaydı oluşturuldu");
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
                Fonksiyonlar.Tbl_StokGruplari Grup = DB.Tbl_StokGruplaris.First(s => s.ID == SecimID);
                Grup.GrupKodu = txtGrupKodu.Text;
                Grup.GrupAdı = txtGrupAdi.Text;
                Grup.GrupEditUser = AnaForm.UserID;
                Grup.GrupEditDate = DateTime.Now;
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
                DB.Tbl_StokGruplaris.DeleteOnSubmit(DB.Tbl_StokGruplaris.First(s => s.ID == SecimID));
                DB.SubmitChanges();
                Temizle();
            }
            catch(Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && SecimID > 0 && Mesajlar.Sil() == DialogResult.Yes)Sil();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && SecimID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();
        }

        void Sec()
        {
            try
            {
                Edit = true;
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtGrupAdi.Text = gridView1.GetFocusedRowCellValue("GrupAdı").ToString();
                txtGrupKodu.Text = gridView1.GetFocusedRowCellValue("GrupKodu").ToString();
            }
            catch(Exception)
            {
                Edit = false;
                SecimID = -1;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if(Secim&& SecimID>0)
            {
                AnaForm.Aktarma = SecimID;
                this.Close();
            }
        }
    }
}