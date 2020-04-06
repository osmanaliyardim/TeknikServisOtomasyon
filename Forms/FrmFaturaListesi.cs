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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
            var values = from x in db.TBLFATURABILGI
                         select new
                         {
                             x.ID,
                             x.SERI,
                             SIRA_NO = x.SIRANO,
                             x.TARIH,
                             x.SAAT,
                             VERGI_DAIRESI = x.VERGIDAIRESI,
                             MUSTERI = x.TBLCARI.AD,
                             PERSONEL = x.TBLPERSONEL.AD
                         };
            gridControl1.DataSource = values.ToList();
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            Listele();

            lookUpEdit1.Properties.DataSource = (from musteri in db.TBLCARI
                                                 select new
                                                 {
                                                     musteri.ID,
                                                     AD_SOYAD = musteri.AD + " " + musteri.SOYAD
                                                 }).ToList();

            lookUpEdit2.Properties.DataSource = (from personel in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     personel.ID,
                                                     AD_SOYAD = personel.AD + " " + personel.SOYAD
                                                 }).ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERI = txtSeri.Text;
            t.SIRANO = txtSiraNo.Text;
            t.TARIH = Convert.ToDateTime(txtTarih.Text);
            t.SAAT = txtSaat.Text;
            t.VERGIDAIRESI = txtVergiDairesi.Text;
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura girişi başarıyla tamamlandı, kalem girişi yapabilirsiniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
