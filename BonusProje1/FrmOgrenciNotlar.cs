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

namespace BonusProje1
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti =new SqlConnection(@"Data Source=ASUS-PC\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DERSAD,SINAV1,SINAV2,SINAV3,ORTALAMA,DURUM FROM TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRENCIID = @p1",baglanti);
            komut.Parameters.AddWithValue("@p1",numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Öğrenci Ad Soyadı Çekme
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select OGRAD,OGRSOYAD FROM TBLOGRENCILER INNER JOIN TBLNOTLAR ON TBLOGRENCILER.OGRID = TBLNOTLAR.OGRENCIID  WHERE OGRID = @p1", baglanti);
            komut1.Parameters.AddWithValue("@p1",numara);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0] + " " + dr[1];
            }
            baglanti.Close();
        }
    }
}
