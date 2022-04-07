using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void Btn_Ekle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(Txt_Ad.Text);
            MessageBox.Show("Yeni Ders Eklendi!!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void Btn_Listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(Txt_Id.Text));
            MessageBox.Show("Ders Silindi!!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(Txt_Ad.Text,byte.Parse(Txt_Id.Text));
            MessageBox.Show("Yeni Ders Eklendi!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txt_Id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Txt_Ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
