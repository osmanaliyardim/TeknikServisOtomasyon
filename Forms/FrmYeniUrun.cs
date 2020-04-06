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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            TBLURUN t = new TBLURUN();
            t.ADI = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.ALISFIYATI = decimal.Parse(txtAlisFiyat.Text);
            t.SATISFIYATI = decimal.Parse(txtSatisFiyat.Text);
            t.STOK = short.Parse(txtStok.Text);
            t.KATEGORI = byte.Parse(txtKategori.Text);
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
