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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS-PC\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Cmb_Kulup.DisplayMember = "KULUPAD";
            Cmb_Kulup.ValueMember = "KULUPID";
            Cmb_Kulup.DataSource = dt;
            baglanti.Close();
        }
        string c = "";
        private void Btn_Ekle_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            if(radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
            ds.OgrenciEkle(Txt_Ad.Text,Txt_Soyad.Text,byte.Parse(Cmb_Kulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Eklendi!!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Cmb_Kulup_SelectedIndexChanged(object sender, EventArgs e)
        {
       //     Txt_Id.Text = Cmb_Kulup.SelectedValue.ToString();
        }

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(Txt_Id.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txt_Id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Txt_Ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Txt_Soyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Cmb_Kulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "KIZ" || dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Kız")
            {
                radioButton1.Checked = true;
            }
            else if(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Erkek" || dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "ERKEK")
            {
                radioButton2.Checked = true;
            }
        }

        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            ds.OgreciGuncelle(Txt_Ad.Text,Txt_Soyad.Text,byte.Parse(Cmb_Kulup.SelectedValue.ToString()),c,int.Parse(Txt_Id.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void Btn_Ara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(Txt_Ara.Text);
        }

        private void Btn_Listele_Click(object sender, EventArgs e)
        {
            ds.OgrenciListesi();
        }
    }
}
