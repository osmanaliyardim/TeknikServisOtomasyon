using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Forms
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var values = from x in db.TBLURUNKABUL
                         select new
                         {
                             x.ISLEMID,
                             //ÜRÜN = x.TBLURUN.ADI,
                             CARİ = x.TBLCARI.AD +" "+ x.TBLCARI.SOYAD,
                             PERSONEL = x.TBLPERSONEL.AD +" "+x.TBLPERSONEL.SOYAD,
                             x.GELISTARIHI,
                             x.CIKISTARIHI,
                             x.URUNSERINO
                         };
            gridControl1.DataSource = values.ToList();
        }
    }
}
