using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastahaneSistemi
{
    public partial class GirisSecimPaneli : Form
    {
        public GirisSecimPaneli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hasta hs = new Hasta();
            hs.Show();
            this.Hide();
        }

        private void BtnDoktorGiris_Click(object sender, EventArgs e)
        {
            DoktorGiris dg= new DoktorGiris();
            dg.Show();
            this.Hide();
        }

        private void BtnSekreterGiris_Click(object sender, EventArgs e)
        {
            SekreterGiris sekgiris= new SekreterGiris();
            sekgiris.Show();
            this.Hide();
        }
    }
}
