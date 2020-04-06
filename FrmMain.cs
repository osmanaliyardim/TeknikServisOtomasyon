using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmUrunListesi fr = new Forms.FrmUrunListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmYeniUrun fr = new Forms.FrmYeniUrun();
            //fr.MdiParent = this; POP-UP
            fr.Show();
        }

        private void btnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmKategori fr = new Forms.FrmKategori();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmYeniKategori fr = new Forms.FrmYeniKategori();
            fr.Show();
        }

        private void btnIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmIstatistik fr = new Forms.FrmIstatistik();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnMarkaIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmMarkalar fr = new Forms.FrmMarkalar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmCariListesi fr = new Forms.FrmCariListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnCariIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmCariSehirler fr = new Forms.FrmCariSehirler();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnCariEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmCariEkle fr = new Forms.FrmCariEkle();
            fr.Show();
        }

        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmDepartman fr = new Forms.FrmDepartman();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmYeniDepartman fr = new Forms.FrmYeniDepartman();
            fr.Show();
        }

        private void btnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmPersonel fr = new Forms.FrmPersonel();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void btnDovizKurlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmDovizKurlari fr = new Forms.FrmDovizKurlari();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        private void btnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmYoutube fr = new Forms.FrmYoutube();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnNotListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmNotlar fr = new Forms.FrmNotlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmArizaListesi fr = new Forms.FrmArizaListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmUrunSatis fr = new Forms.FrmUrunSatis();
            fr.Show();
        }

        private void btnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmSatislar fr = new Forms.FrmSatislar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmArizaliUrunKaydi fr = new Forms.FrmArizaliUrunKaydi();
            fr.Show();
        }

        private void btnArizaAciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmArizaDetay fr = new Forms.FrmArizaDetay();
            fr.Show();
        }

        private void btnArizaliUrunDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmArizaliUrunDetayListesi fr = new Forms.FrmArizaliUrunDetayListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmQRCode fr = new Forms.FrmQRCode();
            fr.Show();
        }

        private void btnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmFaturaListesi fr = new Forms.FrmFaturaListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnFaturaKalemGiris_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmFaturaKalem fr = new Forms.FrmFaturaKalem();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnFaturaAra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.FrmFaturaKalemleri fr = new Forms.FrmFaturaKalemleri();
            fr.MdiParent = this;
            fr.Show();
        }
    }
}
