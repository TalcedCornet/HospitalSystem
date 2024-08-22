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
namespace HastahaneSistemi
{
    public partial class DoktorPaneli : Form
    {
        public DoktorPaneli()
        {
            InitializeComponent();
        }
        Sql conn =new Sql();
        private void DoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Doktorlar", conn.connection());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            //Branşları cmb aktarma
            SqlCommand cmd2 = new SqlCommand("Select BransAd From Tbl_Branslar", conn.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            conn.connection().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("Insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)",conn.connection());
            cmd.Parameters.AddWithValue("@d1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@d3", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@d4", MskTc.Text);
            cmd.Parameters.AddWithValue("@d5", TxtSifre.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Doktor Eklendi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[select].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[select].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[select].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[select].Cells[5].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From Tbl_Doktorlar where DoktorTC=@d1",conn.connection());
            cmd.Parameters.AddWithValue("@d1",MskTc.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorTC=@d4,DoktorSifre=@d5 where DoktorTC=@d4", conn.connection());
            cmd.Parameters.AddWithValue("@d1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@d3", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@d4", MskTc.Text);
            cmd.Parameters.AddWithValue("@d5", TxtSifre.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Kayıt Güncellendi");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
