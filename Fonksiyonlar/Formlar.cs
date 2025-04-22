 using Otomasyon.Modul_Banka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomasyon.Fonksiyonlar
{
    class Formlar
    {
        public int StokListesi(bool Secim = false)
        {
            Modul_Stok.frmStokListesi frm = new Modul_Stok.frmStokListesi();

            if (Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }

        public int StokGruplari(bool Secim = false)
        {
            Modul_Stok.frmStokGruplari frm = new Modul_Stok.frmStokGruplari();
            if (Secim) frm.Secim = Secim;
            frm.ShowDialog();
            return AnaForm.Aktarma;
        }

        public void StokHareketleri(bool Ac = false)
        {

        }

        public void StokKarti(bool Ac = false)
        {
            Modul_Stok.frmStokKarti frm = new Modul_Stok.frmStokKarti();
            frm.ShowDialog();
        }



        public int CariGruplari(bool Secim = false)
        {
            Modul_Cari.frmCariGruplari frm = new Modul_Cari.frmCariGruplari();
            if (Secim) frm.Secim = Secim;
            frm.ShowDialog();
            return AnaForm.Aktarma;
        }

        public int CariListesi(bool Secim=false)
        {
            Modul_Cari.frmCariListesi frm = new Modul_Cari.frmCariListesi();
            if(Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
                return AnaForm.Aktarma;
        }

        public void CariAcilimKarti(bool Ac=false,int CariID=-1)
        {
            Modul_Cari.frmCariAcilisKarti frm = new Modul_Cari.frmCariAcilisKarti();
            if (Ac) frm.Ac(CariID);
            frm.ShowDialog();
        }

        public void KasaAcilisKarti()
        {
            Modul_Kasa.frmKasaAcilisKarti frm = new Modul_Kasa.frmKasaAcilisKarti();
            frm.ShowDialog();
        }

        public void KasaDevirİslemKarti(bool Ac=false ,int IslemID=-1)
        {
            Modul_Kasa.frmKasaDevirİslem frm = new Modul_Kasa.frmKasaDevirİslem();
            if (Ac) frm.Ac(IslemID);
            frm.ShowDialog();
        }

        public int KasaListesi(bool Secim=false)
        {
            Modul_Kasa.frmKasaListesi frm = new Modul_Kasa.frmKasaListesi();
            if(Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }

        public void KasaTahsilatOdemeKarti(bool Ac =false ,int ID=-1)
        {
            Modul_Kasa.frmKasaTahsilatOdeme frm = new Modul_Kasa.frmKasaTahsilatOdeme();
            if (Ac) frm.Ac(ID);
            frm.ShowDialog();
        }

        public void KasaHareketleri(bool Ac=false,int ID=-1)
        {
            Modul_Kasa.frmKasaHareketleri frm = new Modul_Kasa.frmKasaHareketleri();
            frm.MdiParent = AnaForm.ActiveForm;
            if (Ac) frm.Ac(ID);
            frm.Show();
        }


        public void BankaAcilisKarti()
        {
            Modul_Banka.frmBankaAcilisKarti frm = new Modul_Banka.frmBankaAcilisKarti();
            frm.ShowDialog();
        }

        public void BankaIslem(bool Ac = false, int ID = -1)
        {
            Modul_Banka.frmBankaİslem frm = new Modul_Banka.frmBankaİslem();
            if (Ac) frm.Ac(ID);
            frm.ShowDialog();
        }

        public int BankaListesi(bool Secim=false)
        {
            Modul_Banka.frmBankaListesi frm = new Modul_Banka.frmBankaListesi();
            if(Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }

        public void BankaParaTransfer(bool Ac =false ,int ID=-1)
        {
            Modul_Banka.frmParaTransferi frm = new Modul_Banka.frmParaTransferi();
            if (Ac) frm.Ac(ID);
            frm.ShowDialog();
        }

        public void BankaHareketleri(bool Ac =false ,int ID=-1)
        {
            Modul_Banka.frmBankaHareketleri frm = new Modul_Banka.frmBankaHareketleri();
            frm.MdiParent = AnaForm.ActiveForm;
            if (Ac) frm.BankaAc(ID);
            frm.Show();
        }

        public void KendiCekimiz(int ıd=0, bool Ac=false)
        {
            Modul_Cek.frmKendiCekimiz frm = new Modul_Cek.frmKendiCekimiz();
            // if(Ac);
            frm.ShowDialog();
        }

        public void MusteriCeki(int ıd=0,bool Ac=false)
        {
            Modul_Cek.frmMusteriCeki frm = new Modul_Cek.frmMusteriCeki();
            // if(Ac)
            frm.ShowDialog();
        }

        public void CariyeCekCikisi()
        {
            Modul_Cek.frmCariyeCekCikisi frm = new Modul_Cek.frmCariyeCekCikisi();
            frm.ShowDialog();
        }


        public void BankayaCekCikisi()
        {
            Modul_Cek.frmBankayaCekCikisi frm = new Modul_Cek.frmBankayaCekCikisi();
            frm.ShowDialog();
        }




    }
}
