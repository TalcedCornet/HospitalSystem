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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }
        Sql conn = new Sql();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@s1 and HastaSifre=@s2",conn.connection());
            command.Parameters.AddWithValue("@s1", MskTC.Text);
            command.Parameters.AddWithValue("@s2", TxtSifre.Text);
            SqlDataReader dr= command.ExecuteReader();
            if (dr.Read())
            {
                
                HastaDetay hd = new HastaDetay();
                hd.tcNo=MskTC.Text;
                hd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
            conn.connection().Close();

        }

        private void LnkKayıtOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayitOl hkl = new HastaKayitOl();
            hkl.Show();
            
        }

        private void Hasta_Load(object sender, EventArgs e)
        {

        }
    }
}
