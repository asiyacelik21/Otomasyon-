using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Kasa
{
	public partial class frmKasaAcilisKarti: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar Mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numaralar Numaralar = new Fonksiyonlar.Numaralar();

        bool Edit = false;
        int SecimID = -1;
        public frmKasaAcilisKarti()
		{
            InitializeComponent();
		}

        private void frmKasaAcilisKarti_Load(object sender, EventArgs e)
        {
            txtKasaKodu.Text = Numaralar.KasaKodNumarasi();
            Listele();
        }

        void Temizle()
        {
            txtKasaKodu.Text = Numaralar.KasaKodNumarasi();
            txtKasaAdi.Text = "";
            txtAciklama.Text = "";
            Edit = false;
            SecimID = -1;
            Listele();
        }

        void YeniKaydet()
        {
            try
            {
                Fonksiyonlar.Tbl_Kasalar Kasa = new Fonksiyonlar.Tbl_Kasalar();
                Kasa.Aciklama = txtAciklama.Text;
                Kasa.KasaAdi = txtKasaAdi.Text;
                Kasa.KasaKodu = txtKasaKodu.Text;
                Kasa.SaveDate = DateTime.Now;
                Kasa.SaveUser = AnaForm.UserID;
                DB.Tbl_Kasalars.InsertOnSubmit(Kasa);
                DB.SubmitChanges();
                Mesajlar.YeniKayit("Yeni kasa kaydı oluşturulmuştur");
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
                Fonksiyonlar.Tbl_Kasalar Kasa = DB.Tbl_Kasalars.First(s => s.ID == SecimID);
                Kasa.Aciklama = txtAciklama.Text;
                Kasa.KasaAdi = txtKasaAdi.Text;
                Kasa.KasaKodu = txtKasaKodu.Text;
                Kasa.SaveDate = DateTime.Now;
                Kasa.SaveUser = AnaForm.UserID;
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
                DB.Tbl_Kasalars.DeleteOnSubmit(DB.Tbl_Kasalars.First(s => s.ID == SecimID));
                Temizle();
                DB.SubmitChanges();
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
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtKasaKodu.Text = gridView1.GetFocusedRowCellValue("KasaKodu").ToString();
                txtKasaAdi.Text = gridView1.GetFocusedRowCellValue("KasaAdi").ToString();
                txtAciklama.Text = gridView1.GetFocusedRowCellValue("Aciklama").ToString();
            }
            catch(Exception e)
            {
                Mesajlar.Hata(e);
            }
        }

        void Listele()
        {
            var lst = from s in DB.Tbl_Kasalars
                      select s;
            Liste.DataSource = lst;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKasaAdi.Text != "" && txtAciklama.Text != "")
            {
                if (Edit && SecimID > 0 && Mesajlar.Guncelle() == DialogResult.Yes) Guncelle();
                else YeniKaydet();
            }
            else MessageBox.Show("Kasa adı ve açıklama girilmesi gereklidir", "İşlem hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && SecimID > 0 && Mesajlar.Sil() == DialogResult.Yes) Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}