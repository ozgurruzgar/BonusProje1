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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS-PC\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }
         void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Btn_Listele_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into TBLKULUPLER (KULUPAD) values (@P1)",baglanti);
            komut.Parameters.AddWithValue("@P1",Txt_Ad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Eklendi!!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightYellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txt_Id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Txt_Ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM TBLKULUPLER WHERE KULUPID=@P1",baglanti);
            komut.Parameters.AddWithValue("@P1",Txt_Id.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Silindi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            liste();
        }

        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBLKULUPLER set KULUPAD=@P1 where KULUPID=@P2",baglanti);
            komut.Parameters.AddWithValue("@P1",Txt_Ad.Text);
            komut.Parameters.AddWithValue("@P2",Txt_Id.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Güncellendi!!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();
        }
    }
}
