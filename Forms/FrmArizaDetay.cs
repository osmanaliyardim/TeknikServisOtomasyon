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
    public partial class FrmArizaDetay : Form
    {
        public FrmArizaDetay()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = txtArizaDetay.Text;
            t.SERINO = txtSeriNo.Text;
            t.TARIH = DateTime.Parse(txtTarih.Text);
            db.TBLURUNTAKIP.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arızalı ürün detayı başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
