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
	public partial class frmBankaHareketleri: DevExpress.XtraEditors.XtraForm
	{

        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesajlar = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();

        int IslemID = -1;
        int BankaID = -1;
        string evrakTuru;
        public frmBankaHareketleri()
		{
            InitializeComponent();
		}

        private void frmBankaHareketleri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.VW_BankaHareketleris
                      where s.BankaID==BankaID
                      select s;
            Liste.DataSource = lst;
        }

      public void BankaAc(int ID)
        {
            try
            {
                BankaID = ID;
                Fonksiyonlar.VW_BankaListesi Banka = DB.VW_BankaListesis.First(s => s.ID == BankaID);
                txtHesapAdi.Text = Banka.HesapAdi;
                txtHesapNo.Text = Banka.HesapNo;
                txtGiris.Text = Banka.GİRİS.Value.ToString();
                txtCikis.Text = Banka.CİKİS.Value.ToString();
                txtBakiye.Text = Banka.BAKİYE.Value.ToString();
                Listele();
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

        void Sec()
        {
            try
            {
                IslemID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                evrakTuru = gridView1.GetFocusedRowCellValue("evrakTuru").ToString();

            }
            catch(Exception)
            {
                IslemID = -1;
                evrakTuru = "";
            }
        }

        private void SagTik_Opening(object sender, CancelEventArgs e)
        {
            Sec();
            if (IslemID > 0)
            {
                if (evrakTuru == "Banka İşlem")
                {
                    BankaIsleminiDuzenle.Enabled = true;
                    bankaParaTransferiniDuzenle.Enabled = false;
                }
                else if (evrakTuru == "Banka EFT" || evrakTuru == "Banka Havale")
                {
                    BankaIsleminiDuzenle.Enabled = false;
                    bankaParaTransferiniDuzenle.Enabled = true;
                }
            }
        }

        private void BankaIsleminiDuzenle_Click(object sender, EventArgs e)
        {
            formlar.BankaIslem(true, IslemID);
            Listele();
        }

        private void bankaParaTransferiniDuzenle_Click(object sender, EventArgs e)
        {
            formlar.BankaParaTransfer(true, IslemID);
            Listele();
        }
    }
}