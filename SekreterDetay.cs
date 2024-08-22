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
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }
        Sql conn=new Sql();
        public string TcNo,tarih,brans,saat,doktor,id;
        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text= TcNo;
            //Ad Soyad
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@p1", conn.connection());
            cmd.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
           while (rdr.Read())
            {
                LblAd.Text = rdr[0].ToString();
                LblSoyad.Text = rdr[1].ToString();
            }
            conn.connection().Close();
            //2.form DataGridden veri çekme
            Txid.Text = id;
            MskTc.Text = TcNo;
            MskTarih.Text = tarih;
            CmbBrans.Text = brans;
            MskSaat.Text = saat;
            CmbDoktor.Text = doktor;

            //Branşları DataGride aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select * From Tbl_Branslar",conn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //Doktorları listeye aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' +DoktorSoyad) as 'Doktorlar' ,DoktorBrans From Tbl_Doktorlar", conn.connection());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            //Branş cmb aktarma
            SqlCommand cmd2 = new SqlCommand("Select BransAd From Tbl_Branslar", conn.connection());
            SqlDataReader dr2= cmd2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            conn.connection().Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsave = new SqlCommand("Insert into Tbl_Randevu (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor)values (@r1,@r2,@r3,@r4)", conn.connection());
            cmdsave.Parameters.AddWithValue("@r1", MskTarih.Text);
            cmdsave.Parameters.AddWithValue("@r2", MskSaat.Text);
            cmdsave.Parameters.AddWithValue("@r3",CmbBrans.Text);
            cmdsave.Parameters.AddWithValue("@r4", CmbDoktor.Text);
            cmdsave.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", conn.connection());
            cmd.Parameters.AddWithValue("@p1",CmbBrans.Text);
            SqlDataReader dr2= cmd.ExecuteReader();
            while (dr2.Read())
            {
                CmbDoktor.Items.Add(dr2[0]+ " " + dr2[1]);
            }
            conn.connection().Close();
        }

        private void BtnOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand cmd=new SqlCommand("Insert into Tbl_Duyurular (duyuru) values (@d1)",conn.connection());
            cmd.Parameters.AddWithValue("@d1", RchDuyuru.Text);
            cmd.ExecuteNonQuery();
            conn.connection().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void BtnDoktorlar_Click(object sender, EventArgs e)
        {
            DoktorPaneli dp= new DoktorPaneli();
            dp.Show();
            
        }

        private void BtnBransSaat_Click(object sender, EventArgs e)
        {
            Brans bs= new Brans();
            bs.Show();
        }

        private void BtnRandevuListe_Click(object sender, EventArgs e)
        {
            RandevuListesi rl= new RandevuListesi();
            rl.Show();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular d= new Duyurular();
            d.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' +DoktorSoyad) as 'Doktorlar' ,DoktorBrans From Tbl_Doktorlar", conn.connection());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            conn.connection().Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", conn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.connection().Close();
        }
    }
}
