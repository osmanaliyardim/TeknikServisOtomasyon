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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = txtAd.Text;
            t.SOYAD = txtSoyad.Text;
            t.IL = txtIl.Text;
            t.ILCE = txtIlce.Text;
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni cari, sisteme başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
