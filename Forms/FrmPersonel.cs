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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        public void Listele()
        {
            var values = from personel in db.TBLPERSONEL
                         select new
                         {
                             personel.ID,
                             personel.AD,
                             personel.SOYAD,
                             personel.MAIL,
                             personel.TELEFON
                         };
            gridControl1.DataSource = values.ToList();
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();

            lookUpEdit1.Properties.DataSource = (from departman in db.TBLDEPARTMAN
                                                select new
                                                {
                                                    departman.ID,
                                                    departman.AD
                                                }).ToList();

            //1.PERSONEL
            string ad1, soyad1;
            ad1 = db.TBLPERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            lblAdSoyad.Text = ad1 + " " + soyad1;
            lblDepartman.Text = db.TBLPERSONEL.First(x => x.ID == 1).TBLDEPARTMAN.AD;
            lblMail.Text = db.TBLPERSONEL.First(x => x.ID == 1).MAIL;

            //2.PERSONEL
            string ad2, soyad2;
            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            lblAdSoyad2.Text = ad2 + " " + soyad2;
            lblDepartman2.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;
            lblMail2.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;

            //3.PERSONEL
            string ad3, soyad3;
            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            lblAdSoyad3.Text = ad3 + " " + soyad3;
            lblDepartman3.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;
            lblMail3.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;

            //4.PERSONEL
            string ad4, soyad4;
            ad4 = db.TBLPERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 4).SOYAD;
            lblAdSoyad4.Text = ad4 + " " + soyad4;
            lblDepartman4.Text = db.TBLPERSONEL.First(x => x.ID == 4).TBLDEPARTMAN.AD;
            lblMail4.Text = db.TBLPERSONEL.First(x => x.ID == 4).MAIL;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = txtAd.Text;
            t.SOYAD = txtSoyad.Text;
            t.MAIL = txtMail.Text;
            t.TELEFON = txtTelefon.Text;
            t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            //t.FOTOGRAF = txtFotograf.Text;
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            var value = db.TBLPERSONEL.Find(Id);
            db.TBLPERSONEL.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            //txtFotograf.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            //txtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            //lookUpEdit1.EditValue = gridView1.GetFocusedRowCellValue("DEPARTMAN").ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtFotograf.Text = "";
            txtMail.Text = "";
            txtTelefon.Text = "";
            lookUpEdit1.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            var value = db.TBLPERSONEL.Find(Id);
            value.AD = txtAd.Text;
            value.SOYAD = txtSoyad.Text;
            value.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            //value.FOTOGRAF = txtFotograf.Text;
            value.MAIL = txtMail.Text;
            value.TELEFON = txtTelefon.Text;
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
