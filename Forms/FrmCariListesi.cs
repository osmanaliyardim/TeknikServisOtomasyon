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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        public void Listele()
        {
            var values = from cari in db.TBLCARI
                         select new
                         {
                             cari.ID,
                             cari.AD,
                             cari.SOYAD,
                             cari.TELEFON,
                             cari.IL,
                             cari.ILCE,
                             cari.BANKA,
                             cari.VERGIDAIRESI,
                             cari.VERGINO,
                             cari.STATU,
                             cari.ADRES
                         };
            gridControl1.DataSource = values.ToList();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
