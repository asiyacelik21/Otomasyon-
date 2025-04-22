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
	public partial class frmKasaHareketleri: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();

        int HareketID = -1;
        int KasaID = -1;
        int evrakID = -1;
        string evrakTuru;

        public frmKasaHareketleri()
		{
            InitializeComponent();
		}

        private void frmKasaHareketleri_Load(object sender, EventArgs e)
        {
           
        }

        public void Ac(int ID)
        {
            try
            {
                KasaID = ID;
                txtKasaKodu.Text = DB.Tbl_Kasalars.First(s => s.ID == KasaID).KasaKodu;
                txtKasaAdi.Text = DB.Tbl_Kasalars.First(s => s.ID == KasaID).KasaAdi;
                DurumGetir();
                Listele();

            }
            catch (Exception e)
            {
                mesajlar.Hata(e);
            }
        }

        void DurumGetir()
        {
            Fonksiyonlar.VW_KasaDurum Kasa = DB.VW_KasaDurums.First(s => s.KasaID == KasaID);
            txtGiris.Text = Kasa.GİRİS.Value.ToString();
            txtCikis.Text = Kasa.CİKİS.Value.ToString();
            txtBakiye.Text = Kasa.BAKİYE.Value.ToString();
        }

        
        void Listele()
        {
            var lst = from s in DB.VW_KasaHareketleris
                      where s.KasaID == KasaID
                      select s;
            Liste.DataSource = lst;
        }

        private void txtKasaKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = formlar.KasaListesi(true);
            if(ID>0)
            {
                Ac(ID);
                AnaForm.Aktarma = -1;
            }
        }

        void Sec()
        {
            try
            {
                HareketID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                try
                {
                    evrakID=int.Parse(gridView1.GetFocusedRowCellValue("evrakID").ToString());
                }
                catch(Exception)
                {
                    evrakID = -1;
                }
                evrakTuru = gridView1.GetFocusedRowCellValue("evrakTuru").ToString();
            }
            catch(Exception)
            {
                HareketID = -1;
                evrakID = -1;
                evrakTuru = "";
            }
        }
        private void SagTik_Opening(object sender, CancelEventArgs e)
        {
            Sec();
            if(evrakTuru=="Kasa Devir Kartı")
            {
                DevirKartiDuzenle.Enabled = true;
                TahsilatOdemeDuzenle.Enabled = false;
            }
            else if(evrakTuru=="Kasa Tahsilat"||evrakTuru=="Kasa Ödeme")
            {
                DevirKartiDuzenle.Enabled = false;
                TahsilatOdemeDuzenle.Enabled = true;
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void DevirKartiDuzenle_Click(object sender, EventArgs e)
        {
            formlar.KasaDevirİslemKarti(true, HareketID);
            Listele();
        }

        private void TahsilatOdemeDuzenle_Click(object sender, EventArgs e)
        {
            formlar.KasaTahsilatOdemeKarti(true, HareketID);
            Listele();
        }
    }
}