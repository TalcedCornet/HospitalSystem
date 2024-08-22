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
    public partial class DoktorDetay : Form
    {
        public DoktorDetay()
        {
            InitializeComponent();
        }
        Sql conn = new Sql();
        public string tc;
        private void DoktorDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;
            //Doktor Ad Soyad Kaydı
            SqlCommand cmd = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorTC=@d1", conn.connection());
            cmd.Parameters.AddWithValue("@d1",LblTc.Text);
            SqlDataReader dr=cmd.ExecuteReader();
            while(dr.Read())
            {
               LblAdSoyad.Text = dr[0]+ " "+ dr[1];
               
            }
            conn.connection().Close();
            //Randevular
           DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevu where RandevuDoktor='" + LblAdSoyad.Text + "'" , conn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DoktorBilgiDuzenle dbd=new DoktorBilgiDuzenle();
            dbd.TcNo=LblTc.Text;
            dbd.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular duyurular=new Duyurular();
            duyurular.Show();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[select].Cells[7].Value.ToString();
        }
    }
}
