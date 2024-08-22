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
    public partial class BilgiDuzenle : Form
    {
        public BilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TcNo;
        Sql conn=new Sql();
        private void BilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTcNo.Text = TcNo;

            SqlCommand cmd = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@l1", conn.connection());
            cmd.Parameters.AddWithValue("@l1", MskTcNo.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelNo.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();   
                CmbCinsiyet.Text = dr[6].ToString();
            }
            conn.connection().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@j1,HastaSoyad=@j2,HastaTelefon=@j3,HastaSifre=@j4,HastaCinsiyet=@j5 where HastaTC=@j6", conn.connection());
            cmd2.Parameters.AddWithValue("@j1",TxtAd.Text);
            cmd2.Parameters.AddWithValue("@j2", TxtSoyad.Text);
            cmd2.Parameters.AddWithValue("@j3", MskTelNo.Text);
            cmd2.Parameters.AddWithValue("@j4", TxtSifre.Text);
            cmd2.Parameters.AddWithValue("@j5", CmbCinsiyet.Text);
            cmd2.Parameters.AddWithValue("@j6", MskTcNo.Text);
            cmd2.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Bilgileriniz güncellenmiştir");
        }  
    }
}
