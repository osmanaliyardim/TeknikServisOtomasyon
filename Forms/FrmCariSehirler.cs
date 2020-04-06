using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Forms
{
    public partial class FrmCariSehirler : Form
    {
        public FrmCariSehirler()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7AALTGU\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void FrmCariSehirler_Load(object sender, EventArgs e)
        {
            /*chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 10);
            chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 15);
            chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 12);
            chartControl1.Series["Series 1"].Points.AddPoint("Adana", 7);*/

            gridControl1.DataSource = db.TBLCARI.OrderBy(x => x.IL).GroupBy(y => y.IL).Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT IL, COUNT(*) FROM TBLCARI GROUP BY IL", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            con.Close();
        }
    }
}
