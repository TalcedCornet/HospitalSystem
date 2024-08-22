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
    public partial class Brans : Form
    {
        public Brans()
        {
            InitializeComponent();
        }
        Sql conn =new Sql();
        private void Brans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar",conn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("Insert into Tbl_Branslar(BransAd)values(@b1)",conn.connection());
            cmd.Parameters.AddWithValue("@b1",TxtAd.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Branş başarıyla eklenmiştir");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[select].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From Tbl_Branslar where Bransid=@d1", conn.connection());
            cmd.Parameters.AddWithValue("@d1", TxtID.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Branslar set BransAd=@b1 where Bransid=@b2", conn.connection());
            cmd.Parameters.AddWithValue("@b1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@b2",TxtID.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Kayıt Güncellendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
