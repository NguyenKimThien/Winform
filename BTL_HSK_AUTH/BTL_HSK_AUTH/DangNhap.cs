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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void BTN_DangNhap_Click(object sender, EventArgs e)
        {
            string tenTk = TBX_TaiKhoan.Text;
            string matKhau = TBX_MatKhau.Text;
            if (tenTk.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập tài khoản");
            }
            else
            {
                if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Mời bạn nhập mật khẩu");      
                }
                else
                {
                    string query = "SELECT sTaiKhoan, sMatKhau FROM TaiKhoan WHERE sTaiKhoan = '"+tenTk+"' AND sMatKhau='"+matKhau+"'";
                    if (modify.listTaiKhoan(query).Count != 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        TrangChu trangChu = new TrangChu();
                        this.Visible = false;
                        trangChu.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKi dangki = new DangKi();
            this.Visible = false;
            dangki.ShowDialog();
            this.Close();
        }

        private void TBX_MatKhau_TextChanged(object sender, EventArgs e)
        {
            TBX_MatKhau.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
