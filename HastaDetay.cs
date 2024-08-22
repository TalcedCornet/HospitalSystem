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
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }
        public string tcNo;
        Sql conn=new Sql();
        private void HastaDetay_Load(object sender, EventArgs e)
        {
            //Tc çekme
            LblTC.Text = tcNo;
            //Ad Soyad Çekme
            SqlCommand cmd= new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar where HastaTC=@t1",conn.connection());
            cmd.Parameters.AddWithValue("@t1",LblTC.Text);
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                LBlAd.Text = dr[0].ToString();
                LblSoyad.Text = dr[1].ToString();
            }
            
            conn.connection().Close();
            //Randevu geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select * From Tbl_Randevu where HastaTC= " +tcNo, conn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //Branş çekme
            SqlCommand cmd2 = new SqlCommand("Select  BransAd From Tbl_Branslar ", conn.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add (dr2[0]);
            }
            conn.connection().Close();
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand cmd3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@b1", conn.connection());

            cmd3.Parameters.AddWithValue ("@b1", CmbBrans.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                CmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            conn.connection().Close();

        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevu Where RandevuBrans='" + CmbBrans.Text + "'" + " and RandevuDoktor='"+CmbDoktor.Text + "'and RandevuDurum=0", conn.connection());
            da.Fill (dt);
            dataGridView2.DataSource = dt;
        }

        private void LnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BilgiDuzenle bd = new BilgiDuzenle();
            bd.TcNo = LblTC.Text;

            bd.Show();


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView2.SelectedCells[0].RowIndex;
            TxtId.Text = dataGridView2.Rows[select].Cells[0].Value.ToString();
          
        }

        private void BtnRandevu_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("Update Tbl_Randevu Set RandevuDurum=1,HastaTC=@r1,HastaSikayet=@r2 where Randevuid=@r3",conn.connection());
            cmd.Parameters.AddWithValue("@r1",LblTC.Text);
            cmd.Parameters.AddWithValue("@r2", RchSikayet.Text);
            cmd.Parameters.AddWithValue("@r3", TxtId.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Randevunuz Oluşturuldu");
        }
    }
}
