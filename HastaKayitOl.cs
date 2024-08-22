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
    public partial class HastaKayitOl : Form
    {
        public HastaKayitOl()
        {
            InitializeComponent();
        }
        //Class bağlantısı
        Sql conn=new Sql();
        private void BtnKayıt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values  (@h1,@h2,@h3,@h4,@h5,@h6)",conn.connection());
            cmd.Parameters.AddWithValue("@h1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@h2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@h3", MskTcNo.Text);
            cmd.Parameters.AddWithValue("@h4", MskTelNo.Text);
            cmd.Parameters.AddWithValue("@h5",TxtSifre.Text);
            cmd.Parameters.AddWithValue("@h6",CmbCinsiyet.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Kaydınız Tamamlanmıştır. Şifreniz: " + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
        }
    }
}
