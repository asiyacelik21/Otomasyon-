using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomasyon.Fonksiyonlar
{
    class Numaralar
    {
        DatabaseDataContext DB = new DatabaseDataContext();
        Mesajlar Mesajlar = new Mesajlar();

        public string StokKodNumarasi()
        {
            try
            {
                int Numara = int.Parse((from s in DB.Tbl_Stoklars
                                        orderby s.ID descending
                                        select s).First().StokKodu);
                Numara++;
                string Num = Numara.ToString().PadLeft(7, '0');
                return Num;
            }
            catch(Exception)
            {
                return "0000001";
            }
        }

        public string CariKodNumarasi()
        {
            try
            {
                int Numara = int.Parse((from s in DB.Tbl_Carilers
                                        orderby s.ID descending
                                        select s).First().CariKodu);
                Numara++;
                string Num = Numara.ToString().PadLeft(7, '0');
                return Num;
            }
            catch (Exception)
            {
                return "0000001";
            }
        }


        public string KasaKodNumarasi()
        {
            try
            {
                int Numara = int.Parse((from s in DB.Tbl_Kasalars
                                        orderby s.ID descending
                                        select s).First().KasaKodu);
                Numara++;
                string Num = Numara.ToString().PadLeft(7, '0');
                return Num;
            }
            catch (Exception)
            {
                return "0000001";
            }
        }
    }
}
