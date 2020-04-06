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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();
            if (txtDepatmanAdi.Text.Length <= 50 && txtDepatmanAdi.Text != "")
            {
                t.AD = txtDepatmanAdi.Text;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Depatman adı 50 karaterden uzun olamaz ve alanlar boş geçilemez!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
