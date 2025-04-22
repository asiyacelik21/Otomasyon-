using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Otomasyon.Fonksiyonlar
{
    class Mesajlar
    {
        AnaForm MesajForm = new AnaForm();
        public void YeniKayit(string mesaj)
        {
            MesajForm.Mesaj("Yeni Kayıt Girişi ", mesaj);
        }
        public DialogResult Guncelle()
        {
            return MessageBox.Show("seçili alan kalıcı olarak güncellenecektir\n Güncelleme işlemini onaylıyor musunuz ?", "Güncelleme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }

        public DialogResult Sil()
        {
            return MessageBox.Show("seçili alan kalıcı olarak silinecektir\n Silme işlemini onaylıyor musunuz ?", "silme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public void Guncelle(bool Guncelleme)
        {
            MesajForm.Mesaj("Kayıt Güncelleme", "Kayıt Güncellenmiştir.");
        }

        public void Hata(Exception Hata)
        {
            MesajForm.Mesaj("Hata Oluştu", Hata.Message);
        }
        public void FormAcilis(string FormAdi)
        {
            MesajForm.Mesaj("", FormAdi + "Formu Açıldı.");
        }
    }
}
