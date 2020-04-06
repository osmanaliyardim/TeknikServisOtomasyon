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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void Listele()
        {
            var okunmusnotlar = from not in db.TBLNOTLARIM
                         where not.DURUM == true
                         select new
                         {
                             not.ID,
                             not.BASLIK,
                             not.DURUM,
                             not.ICERIK
                         };

            var okunmamisnotlar = from not in db.TBLNOTLARIM
                               where not.DURUM == false
                               select new
                               {
                                   not.ID,
                                   not.BASLIK,
                                   not.DURUM,
                                   not.ICERIK
                               };
            
            gridControl1.DataSource = okunmusnotlar.ToList();
            gridControl2.DataSource = okunmamisnotlar.ToList();
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM t = new TBLNOTLARIM();

            if (chcDurum.Checked == true)
            {
                t.BASLIK = txtBaslik.Text;
                t.DURUM = true;
                t.ICERIK = txtAciklama.Text;
                db.TBLNOTLARIM.Add(t);
                db.SaveChanges();
                MessageBox.Show("Not başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else
            {
                t.BASLIK = txtBaslik.Text;
                t.DURUM = false;
                t.ICERIK = txtAciklama.Text;
                db.TBLNOTLARIM.Add(t);
                db.SaveChanges();
                MessageBox.Show("Not başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtBaslik.Text = "";
            txtAciklama.Text = "";
            chcDurum.Checked = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var value = db.TBLNOTLARIM.Find(int.Parse(txtId.Text));
            db.TBLNOTLARIM.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Not başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtBaslik.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            txtAciklama.Text = gridView1.GetFocusedRowCellValue("ICERIK").ToString();
            chcDurum.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("DURUM"));
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView2.GetFocusedRowCellValue("ID").ToString();
            txtBaslik.Text = gridView2.GetFocusedRowCellValue("BASLIK").ToString();
            txtAciklama.Text = gridView2.GetFocusedRowCellValue("ICERIK").ToString();
            chcDurum.Checked = Convert.ToBoolean(gridView2.GetFocusedRowCellValue("DURUM"));
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (chcDurum.Checked == true)
            {
                int Id = int.Parse(txtId.Text);
                var value = db.TBLNOTLARIM.Find(Id);
                value.BASLIK = txtBaslik.Text;
                value.ICERIK = txtAciklama.Text;
                value.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                int Id = int.Parse(txtId.Text);
                var value = db.TBLNOTLARIM.Find(Id);
                value.BASLIK = txtBaslik.Text;
                value.ICERIK = txtAciklama.Text;
                value.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Not başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
