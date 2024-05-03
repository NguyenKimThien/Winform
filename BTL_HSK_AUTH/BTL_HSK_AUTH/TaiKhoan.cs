using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK_AUTH
{
    class TaiKhoan
    {
        private string tentaiKhoan;
        private string matKhau;

 

        public TaiKhoan(string taiKhoan, string matKhau)
        {
            this.tentaiKhoan = taiKhoan;
            this.matKhau = matKhau;
        }
        public TaiKhoan()
        {
        }
        public string TenTaiKhoan { get => tentaiKhoan; set => tentaiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }


    }
}
