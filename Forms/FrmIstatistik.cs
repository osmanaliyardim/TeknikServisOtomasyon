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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            //Linq ile SQL Sorguları
            lblToplamUrun.Text = db.TBLURUN.Count().ToString(); //TOPLAM ÜRÜN
            lblToplamKategori.Text = db.TBLKATEGORI.Count().ToString(); //TOPLAM KATEGORİ
            lblTopSSayisi.Text = db.TBLURUN.Sum(x => x.STOK).ToString(); //TOPLAM STOK SAYISI

            lblEFSUrun.Text = (from y in db.TBLURUN
                               orderby y.STOK descending
                               select y.ADI).FirstOrDefault(); //EN FAZLA STOKLU ÜRÜN

            lblEASUrun.Text = (from z in db.TBLURUN
                               orderby z.STOK ascending
                               select z.ADI).FirstOrDefault(); //EN AZ STOKLU ÜRÜN

            lblEYFUrun.Text = (from x in db.TBLURUN
                               orderby x.SATISFIYATI descending
                               select x.ADI).FirstOrDefault(); //EN YÜKSEK FİYATLI ÜRÜN

            lblEDFUrun.Text = (from x in db.TBLURUN
                               orderby x.SATISFIYATI ascending
                               select x.ADI).FirstOrDefault(); //EN DÜŞÜK FİYATLI ÜRÜN

            lblKritikSeviye.Text = "10"; //KRİTİK SEVİYE (DEĞİŞECEK)
            lblBeyazEsya.Text = db.TBLURUN.Count(x => x.KATEGORI == 3).ToString(); //TOPLAM BEYAZ EŞYA
            lblBilgisayar.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString(); //TOPLAM BİLGİSAYAR
            lblKucukEvAletleri.Text = db.TBLURUN.Count(x => x.KATEGORI == 5).ToString(); //TOPLAM KÜÇÜK EV ALETLERİ
            lblTopMSayisi.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString(); //TOPLAM MARKA SAYISI
        }
    }
}
