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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        public void Listele()
        {
            var values = from urun in db.TBLURUN
                         select new
                         {
                             urun.ID,
                             urun.ADI,
                             urun.MARKA,
                             KATEGORI = urun.TBLKATEGORI.AD,
                             urun.STOK,
                             urun.ALISFIYATI,
                             urun.SATISFIYATI
                         };
            gridControl1.DataSource = values.ToList();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            /*LinQ ile listeleme ToList
            var values = db.TBLURUN.ToList();
            gridControl1.DataSource = values;*/

            Listele();

            //lookUpEdit'e verileri getirme
            lueKategori.Properties.DataSource = (from urun in db.TBLURUN
                                                 select new
                                                 {
                                                     urun.ID,
                                                     urun.TBLKATEGORI.AD,
                                                 }).ToList(); ;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.ADI = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.ALISFIYATI = decimal.Parse(txtAlisFiyat.Text);
            t.SATISFIYATI = decimal.Parse(txtSatisFiyat.Text);
            t.STOK = short.Parse(txtStok.Text);
            t.DURUM = false;
            t.KATEGORI = byte.Parse(lueKategori.EditValue.ToString());
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            /*var values = db.TBLURUN.ToList();
            gridControl1.DataSource = values;*/
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //txtId.Text = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtUrunAd.Text = gridView1.GetFocusedRowCellValue("ADI").ToString();
            txtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            txtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYATI").ToString();
            txtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYATI").ToString();
            txtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            int Id = Convert.ToInt32(txtId.Text);
            var value = db.TBLURUN.Find(Id);
            db.TBLURUN.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            int Id = Convert.ToInt32(txtId.Text);
            var value = db.TBLURUN.Find(Id);
            value.ADI = txtUrunAd.Text;
            value.MARKA = txtMarka.Text;
            value.ALISFIYATI = decimal.Parse(txtAlisFiyat.Text);
            value.SATISFIYATI = decimal.Parse(txtSatisFiyat.Text);
            value.STOK = short.Parse(txtStok.Text);
            value.KATEGORI = byte.Parse(lueKategori.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtUrunAd.Text = "";
            txtMarka.Text = "";
            txtAlisFiyat.Text = "";
            txtSatisFiyat.Text = "";
            txtStok.Text = "";
            lueKategori.Text = "";
        }
    }
}
