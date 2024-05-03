using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK_AUTH
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
        }

        private void btn_QLNV_Click(object sender, EventArgs e)
        {
            QLNV qLNV = new QLNV();
            this.Visible = false;
            qLNV.ShowDialog();
            this.Close();
        }

        private void bTN_QLKH_Click(object sender, EventArgs e)
        {
            QLKH qLKH = new QLKH();
            this.Visible = false;
            qLKH.ShowDialog();
            this.Close();

        }

        private void btn_QLSP_Click(object sender, EventArgs e)
        {
            QLSP qLSP = new QLSP();
            this.Visible = false;
            qLSP.ShowDialog();
            this.Close();
        }

        private void btn_QLHD_Click(object sender, EventArgs e)
        {
            QLHD qLHD = new QLHD();
            this.Visible = false;
            qLHD.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNV qLNV = new QLNV();
            qLNV.MdiParent = this;
            qLNV.FormBorderStyle = FormBorderStyle.None;
            qLNV.Dock = DockStyle.Fill;
            qLNV.WindowState = FormWindowState.Maximized;
            qLNV.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLKH qLKH = new QLKH();
            qLKH.MdiParent = this;
            qLKH.FormBorderStyle = FormBorderStyle.None;
            qLKH.Dock = DockStyle.Fill;
            qLKH.WindowState = FormWindowState.Maximized;
            qLKH.Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHD qLHD = new QLHD();
            qLHD.MdiParent = this;
            qLHD.FormBorderStyle = FormBorderStyle.None;
            qLHD.Dock = DockStyle.Fill;
            qLHD.WindowState = FormWindowState.Maximized;
            qLHD.Show();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSP qLSP = new QLSP();
            qLSP.MdiParent = this;
            qLSP.FormBorderStyle = FormBorderStyle.None;
            qLSP.Dock = DockStyle.Fill;
            qLSP.WindowState = FormWindowState.Maximized;
            qLSP.Show();
        }

        private void hỆTHỐNGToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
