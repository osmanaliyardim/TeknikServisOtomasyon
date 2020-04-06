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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
            var values = from x in db.TBLFATURADETAY
                         select new
                         {
                             DETAY_ID = x.FATURADETAYID,
                             x.URUN,
                             x.ADET,
                             x.FIYAT,
                             x.TUTAR,
                             FATURA_ID = x.FATURAID
                         };

            gridControl1.DataSource = values.ToList();
        }
        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUN = txtUrun.Text;
            t.ADET = short.Parse(txtAdet.Text);
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.TUTAR = decimal.Parse(txtTutar.Text);
            t.FATURAID = int.Parse(txtFaturaId.Text);
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura detay bilgisi baraşıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
