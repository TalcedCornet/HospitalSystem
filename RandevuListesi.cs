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
    public partial class RandevuListesi : Form
    {
        public RandevuListesi()
        {
            InitializeComponent();
        }
        Sql conn=new Sql();
        private void RandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select * From Tbl_Randevu",conn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SekreterDetay sd= new SekreterDetay();
            sd.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id=Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Randevuid"].FormattedValue.ToString());
            SqlCommand cmd = new SqlCommand("Delete Tbl_Randevu where Randevuid='"+id+"'",conn.connection());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Randevu başarıyla silindi");
            conn.connection().Close();
        }
    }
}
