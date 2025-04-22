using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Otomasyon
{
	public partial class AnaForm: DevExpress.XtraBars.Ribbon.RibbonForm
	{
        Fonksiyonlar.Formlar formlar = new Fonksiyonlar.Formlar();

        public static int UserID = -1;
        public static int Aktarma = -1;
        public AnaForm()
		{
            InitializeComponent();
		}

        private void AnaForm_Load(object sender, EventArgs e)
        {

        }

        private void barbtnStokKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.StokKarti();
        }

        private void barbtnStokListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.StokListesi();
        }

        private void barbtnStokGruplari_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.StokGruplari();
        }

        private void barbtnStokHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.StokHareketleri();
        }

        private void barbtnAcilisKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.CariAcilimKarti();
        }

        private void barbtnCariGruplari_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.CariGruplari();
        }

        private void barbtnCariListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.CariListesi();
        }

        private void barbtnCariHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barbtnKasaAcilisKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.KasaAcilisKarti();
        }

        private void barbtnKasaListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.KasaListesi();
        }

        private void barbtnKasaDevirİslem_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.KasaDevirİslemKarti();
        }

        private void barbtnKasaTahsilatOdeme_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.KasaTahsilatOdemeKarti();
        }

        private void barbtnKasaHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.KasaHareketleri();
        }

        private void barbtnBankaAcilisKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.BankaAcilisKarti();
        }

        private void barbtnBankaİslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.BankaIslem();
        }

        private void barbtnBankaListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.BankaListesi();
        }

        private void barbtnParaTransferi_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.BankaParaTransfer();
        }

        private void barbtnBankaHaraketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.BankaHareketleri();
        }

        private void navBtnStokKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.StokKarti();
        }

        private void navBtnStokListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.StokListesi();
        }

        private void navBtnStokGruplari_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.StokGruplari();
        }

        private void navBtnStokHareketleri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.StokHareketleri();
        }

        private void navBtnCariHareketleri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void navBtnCariListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.CariListesi();
        }

        private void navBtnCariGruplari_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.CariGruplari();
        }

        private void navBtnCariAcilisKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.CariAcilimKarti();
        }

        private void navBtnBankaAcilisKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaAcilisKarti();
        }

        private void navBtnParaTransferi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaParaTransfer();
        }

        private void navBtnBankaListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaListesi();
        }

        private void navBtnBankaİslem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaIslem();
        }

        private void navBtnBankaHareketleri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.BankaHareketleri();
        }

        private void navBtnKasaTahsilat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaTahsilatOdemeKarti();
        }

        private void navBtnKasaDevir_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaDevirİslemKarti();
        }

        private void navBtnKasaListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaListesi();
        }

        private void navBtnKasaAcilisKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formlar.KasaAcilisKarti();
        }

        public void Mesaj(string Baslik,string Mesaj)
        {
            ALC.Show(this, Baslik, Mesaj);
        }

        private void barbtnMusteriCeki_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.MusteriCeki();
        }

        private void barbtnKendiCekimiz_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.KendiCekimiz();
        }

        private void barbtnBankayaCekCikisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.BankayaCekCikisi();
        }

        private void barbtnCariyeCekCikisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            formlar.CariyeCekCikisi();
        }
    }
}