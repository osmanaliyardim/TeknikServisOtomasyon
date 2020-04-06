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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();

            lblToplamUrun.Text = db.TBLURUN.Count().ToString(); //TOPLAM ÜRÜN
            lblTopMSayisi.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString(); //TOPLAM MARKA SAYISI
            lblEYFMarka.Text = (from x in db.TBLURUN
                                 orderby x.SATISFIYATI descending
                                 select x.MARKA).FirstOrDefault(); //EN YÜKSEK FİYATLI MARKA
            lblEFUOMarka.Text = (from x in db.TBLURUN
                                 orderby x.STOK descending
                                 select x.MARKA).FirstOrDefault(); //EN FAZLA ÜRÜNE SAHİP MARKA

            //CHART 1
            chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("A", 6);
            chartControl1.Series["Series 1"].Points.AddPoint("B", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("C", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("D", 4);

            //CHART2
            chartControl2.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Bilgisayar", 3);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Televizyon", 1);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Telefon", 5);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 6);
        }

    }
}
