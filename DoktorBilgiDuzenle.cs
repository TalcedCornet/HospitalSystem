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
    public partial class DoktorBilgiDuzenle : Form
    {
        public DoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        Sql conn = new Sql();
        public string   TcNo;
        private void DoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
           MskTcNo.Text= TcNo;

            SqlCommand cmd = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@d1", conn.connection());
            cmd.Parameters.AddWithValue("@d1", MskTcNo.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                CmbBrans.Text = dr[3].ToString();
                TxtSifre.Text = dr[5].ToString();
               
            }
            conn.connection().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d4 where DoktorTC=@d5", conn.connection());
            cmd.Parameters.AddWithValue("@d1",TxtAd.Text);
            cmd.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@d3", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@d4", TxtSifre.Text);
            cmd.Parameters.AddWithValue("@d5", MskTcNo.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Bilgiler Güncellendi");
        }
    }
    
}
