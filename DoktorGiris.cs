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
    public partial class DoktorGiris : Form
    {
        public DoktorGiris()
        {
            InitializeComponent();
        }
        Sql conn =new Sql();
        private void DoktorGiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTc=@d1 and DoktorSifre=@d2", conn.connection());
            cmd.Parameters.AddWithValue("@d1", MskTC.Text);
            cmd.Parameters.AddWithValue("@d2", TxtSifre.Text);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                DoktorDetay dt= new DoktorDetay();
                dt.tc=MskTC.Text;
                dt.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC Kimlik No ve Şifre eksik veya hatalı girildi !!! ");
            }
            conn.connection().Close();
        }
    }
}
