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
	public partial class frmStokListesi: DevExpress.XtraEditors.XtraForm
	{
        Fonksiyonlar.DatabaseDataContext DB=new Fonksiyonlar.DatabaseDataContext();
        public bool Secim = false;
        int SecimId = -1;
        public frmStokListesi()
		{
            InitializeComponent();
		}

        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.Tbl_Stoklars
                      where s.StokAdı.Contains(txtStokAdi.Text) && s.StokBarkod.Contains(txtBarkod.Text) && s.StokKodu.Contains(txtStokKodu.Text)
                      select s;
            Liste.DataSource = lst;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtBarkod.Text = "";
            txtStokAdi.Text = "";
            txtStokKodu.Text = "";
        }

        void Sec()
        {
            try
            {
                SecimId = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            }
            catch(Exception)
            {
                SecimId = -1;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if(Secim && SecimId>0)
            {
                AnaForm.Aktarma = SecimId;
                this.Close();
            }
        }
    }
}