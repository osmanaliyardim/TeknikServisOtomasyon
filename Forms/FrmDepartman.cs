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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        public void Listele()
        {
            var values = from departman in db.TBLDEPARTMAN
                         select new
                         {
                             departman.ID,
                             departman.AD,
                             departman.ACIKLAMA,
                         };
            gridControl1.DataSource = values.ToList();
        }

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            Listele();
            lblToplamDepartman.Text = db.TBLDEPARTMAN.Count().ToString();
            lblToplamPersonel.Text = db.TBLPERSONEL.Count().ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();
            if (txtDepAdi.Text.Length <= 50 && txtDepAdi.Text != "" && txtAciklama.Text.Length >= 1) 
            {
                t.AD = txtDepAdi.Text;
                t.ACIKLAMA = txtAciklama.Text;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Depatman adı 50 karaterden uzun olamaz ve alanlar boş geçilemez!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtDepAdi.Text = "";
            txtAciklama.Text = "";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            int Id = Convert.ToInt32(txtId.Text);
            var value = db.TBLDEPARTMAN.Find(Id);
            db.TBLDEPARTMAN.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtDepAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            int Id = Convert.ToInt32(txtId.Text);
            var value = db.TBLDEPARTMAN.Find(Id);
            value.AD = txtDepAdi.Text;
            value.ACIKLAMA = txtAciklama.Text;
            db.SaveChanges();
            MessageBox.Show("Depatman bilgileri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
