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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        public void Listele()
        {
            var values = from kategori in db.TBLKATEGORI
                         select new
                         {
                             kategori.ID,
                             KATEGORI = kategori.AD,
                         };
            gridControl1.DataSource = values.ToList();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            /*var values = db.TBLKATEGORI.ToList();
            gridControl1.DataSource = values;*/
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //txtId.Text = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtUrunAd.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = txtUrunAd.Text;
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori ekleme işlemi başarılı!","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            byte Id = byte.Parse(txtId.Text);
            var values = db.TBLKATEGORI.Find(Id);
            db.TBLKATEGORI.Remove(values);
            db.SaveChanges();
            MessageBox.Show("Kategori silme işlemi başarılı!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            byte Id = byte.Parse(txtId.Text);
            var values = db.TBLKATEGORI.Find(Id);
            values.AD = txtUrunAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncelleme işlemi başarılı!", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtUrunAd.Text = "";
        }
    }
}
