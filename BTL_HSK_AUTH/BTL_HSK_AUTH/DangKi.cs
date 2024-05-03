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
    public partial class DangKi : Form
    {
        public DangKi()
        {
            InitializeComponent();
        }

        private void LinkText_DangKi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            this.Visible = false;
            dangNhap.ShowDialog();
            this.Close();
            
        }
        Modify modify = new Modify();
        private void BTN_DangKi_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = TBX_TaiKhoan.Text;
            string matKhau = TBX_MatKhau.Text;
            string re_matKhau = TBX_RE_MatKhau.Text;
            if(tenTaiKhoan.Trim()=="" || matKhau.Trim()=="" || re_matKhau.Trim() == "")
            {
                MessageBox.Show("Yêu cầu bạn nhập dầy đủ thông tin!");
            }
            else
            {
                if (matKhau == re_matKhau)
                {
                    
                    modify.add_TaiKhoan(tenTaiKhoan, matKhau);
                    MessageBox.Show("Đăng kí thành công!");
                }
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu không khớp!");
                }
            }
        }

        private void TBX_MatKhau_TextChanged(object sender, EventArgs e)
        {
            TBX_MatKhau.PasswordChar = '*';
        }

        private void TBX_RE_MatKhau_TextChanged(object sender, EventArgs e)
        {
            TBX_RE_MatKhau.PasswordChar = '*';
        }
    }
}
