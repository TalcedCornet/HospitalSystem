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
    public partial class SekreterGiris : Form
    {
        public SekreterGiris()
        {
            InitializeComponent();
        }
        Sql conn =new Sql();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("Select*From Tbl_Sekreter where SekreterTC=@s1 and SekreterSifre=@s2",conn.connection());
            cmd.Parameters.AddWithValue("@s1",MskTC.Text);
            cmd.Parameters.AddWithValue("@s2", TxtSifre.Text);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if(dataReader.Read())
            {
                SekreterDetay sd= new SekreterDetay();
                sd.TcNo=MskTC.Text;
                sd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC No veya Şifre");
            }
            conn.connection().Close();
        }
    }
}
