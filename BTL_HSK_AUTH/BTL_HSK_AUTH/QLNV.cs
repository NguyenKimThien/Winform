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

namespace BTL_HSK_AUTH
{
    public partial class QLNV : Form
    {
        public QLNV()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string maNV, tenNV, diaChi, cccd, ngaySinh, ngayvaolam, luongcoban, phucap;
                maNV = item.SubItems[1].Text;
                tenNV = item.SubItems[2].Text;
                diaChi = item.SubItems[3].Text;
                cccd = item.SubItems[4].Text;
                ngaySinh = item.SubItems[5].Text;
                ngayvaolam = item.SubItems[6].Text;
                luongcoban = item.SubItems[7].Text;
                phucap = item.SubItems[8].Text;
                TBX_maNV.Text = maNV;
                TBX_Ten.Text = tenNV;
                TBX_Diachi.Text = diaChi;
                TBX_CCCD.Text = cccd;
                string datetimeformat = "yyyy/MM/dd";
                DateTime date1, date2;
                date1 = DateTime.ParseExact(ngaySinh, datetimeformat, null);
                dateTimePicker_NgaySinh.Value = date1;
                date2 = DateTime.ParseExact(ngayvaolam, datetimeformat, null);
                dateTimePicker_ngayvaolam.Value = date2;
                TBX_luongCB.Text = luongcoban;
                TBX_PhuCap.Text = phucap;
            }


        }

        private void QLNV_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tblNhanVien";
            SqlCommand sqlCommand;
            SqlDataReader dataReader;
            int i = 0;

            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    i++;
                    ListViewItem item = new ListViewItem(i.ToString());
                    item.SubItems.Add(dataReader["sMaNV"].ToString());
                    item.SubItems.Add(dataReader["sTenNV"].ToString());
                    item.SubItems.Add(dataReader["sDiaChi"].ToString());
                    item.SubItems.Add(dataReader["sCCCD"].ToString());
                    item.SubItems.Add(dataReader["dNgaySinh"].ToString());
                    item.SubItems.Add(dataReader["dNgayVaoLam"].ToString());
                    item.SubItems.Add(dataReader["fLuongCoBan"].ToString());
                    item.SubItems.Add(dataReader["fPhuCap"].ToString());
                    listView1.Items.Add(item);

                }
                sqlConnection.Close();
            }
        }
        Modify modify = new Modify();

        private void button1_Click(object sender, EventArgs e)

        {
            if (TBX_maNV.Text == "" || TBX_Ten.Text == "" || TBX_luongCB.Text == "" || TBX_Diachi.Text == "" || TBX_PhuCap.Text == "" || TBX_CCCD.Text == "" || dateTimePicker_NgaySinh.Text == "" || dateTimePicker_ngayvaolam.Text == "")
            {
                MessageBox.Show("Yêu cầu bạn nhập đầy đủ thông tin trước khi chỉnh sửa!");
            }
            else
            {
                string maNV, tenNV, DiaChi, cccd, ngaysinh, ngayvaolam, luongcoban, phucap;
                maNV = TBX_maNV.Text;
                tenNV = TBX_Ten.Text;
                DiaChi = TBX_Diachi.Text;
                cccd = TBX_CCCD.Text;
                ngaysinh = dateTimePicker_NgaySinh.Value.ToString("yyyy/MM/dd");
                ngayvaolam = dateTimePicker_ngayvaolam.Value.ToString("yyyy/MM/dd");
                luongcoban = TBX_luongCB.Text;
                phucap = TBX_PhuCap.Text;
                if(modify.check_primary_key("tblNhanVien", "sMaNV", maNV) == false)
                {
                    modify.add_NhanVien(maNV, tenNV, DiaChi, cccd, ngaysinh, ngayvaolam, luongcoban, phucap);
                    MessageBox.Show("Thêm nhân viên thành công!");
                    int k = listView1.Items.Count;
                    k++;
                    ListViewItem item = new ListViewItem(k.ToString());
                    item.SubItems.Add(maNV);
                    item.SubItems.Add(tenNV);
                    item.SubItems.Add(DiaChi);
                    item.SubItems.Add(cccd);
                    item.SubItems.Add(ngaysinh);
                    item.SubItems.Add(ngayvaolam);
                    item.SubItems.Add(luongcoban);
                    item.SubItems.Add(phucap);
                    listView1.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                }
            }
          
        }
        public void update_listview()
        {
            listView1.Items.Clear();
            string query = "SELECT * FROM tblNhanVien";
            SqlCommand sqlCommand;
            SqlDataReader dataReader;
            int i = 0;

            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    i++;
                    ListViewItem item = new ListViewItem(i.ToString());
                    item.SubItems.Add(dataReader["sMaNV"].ToString());
                    item.SubItems.Add(dataReader["sTenNV"].ToString());
                    item.SubItems.Add(dataReader["sDiaChi"].ToString());
                    item.SubItems.Add(dataReader["sCCCD"].ToString());
                    item.SubItems.Add(dataReader["dNgaySinh"].ToString());
                    item.SubItems.Add(dataReader["dNgayVaoLam"].ToString());
                    item.SubItems.Add(dataReader["fLuongCoBan"].ToString());
                    item.SubItems.Add(dataReader["fPhuCap"].ToString());
                    listView1.Items.Add(item);

                }
                sqlConnection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TBX_maNV.Text == "" || TBX_Ten.Text == "" || TBX_luongCB.Text == "" || TBX_Diachi.Text == "" || TBX_PhuCap.Text == "" || TBX_CCCD.Text == "" || dateTimePicker_NgaySinh.Text == "" || dateTimePicker_ngayvaolam.Text == "")
            {
                MessageBox.Show("Yêu cầu bạn nhập đầy đủ thông tin trước khi chỉnh sửa!");
            }
            else
            {
                string maNV, tenNV, DiaChi, cccd, ngaysinh, ngayvaolam, luongcoban, phucap;
                maNV = TBX_maNV.Text;
                tenNV = TBX_Ten.Text;
                DiaChi = TBX_Diachi.Text;
                cccd = TBX_CCCD.Text;
                ngaysinh = dateTimePicker_NgaySinh.Value.ToString("yyyy/MM/dd");
                ngayvaolam = dateTimePicker_ngayvaolam.Value.ToString("yyyy/MM/dd");
                luongcoban = TBX_luongCB.Text;
                phucap = TBX_PhuCap.Text;
                modify.Update_NhanVien(maNV, tenNV, DiaChi, cccd, ngaysinh, ngayvaolam, luongcoban, phucap);
                int f=0;
                for (int i = 0; i <= listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == maNV)
                    {
                        f = i+1;
                        break;
                    }
                }
                ListViewItem item = new ListViewItem(f.ToString());
                item.SubItems.Add(maNV);
                item.SubItems.Add(tenNV);
                item.SubItems.Add(DiaChi);
                item.SubItems.Add(cccd);
                item.SubItems.Add(ngaysinh);
                item.SubItems.Add(ngayvaolam);
                item.SubItems.Add(luongcoban);
                item.SubItems.Add(phucap);
                for (int i=0; i<=listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == maNV)
                    {
                        item.SubItems.Add((i + 1).ToString());
                        listView1.Items[i] = item;
                        break;
                    }
                }
                MessageBox.Show("Chỉnh sửa thông tin nhân viên thành công!");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maNV;
            maNV = TBX_maNV.Text;
            modify.Delete_NhanVien(maNV);
            update_listview();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormBaoCaoNV formBaoCaoNV = new FormBaoCaoNV();
            formBaoCaoNV.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TBX_maNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên cần tìm kiếm!");
            }
            else
            {

                listView1.Items.Clear();
                int i = 0;
                string ma = TBX_maNV.Text;
                using (SqlConnection sqlConnection = connection.getSQLconnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand command = sqlConnection.CreateCommand())
                    {
                        command.CommandText = "SEARCH_NV";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MA", ma);
                        SqlDataReader dataReader = command.ExecuteReader();
                        dataReader.Read();
                        i++;
                        ListViewItem item = new ListViewItem(i.ToString());
                        item.SubItems.Add(dataReader["sMaNV"].ToString());
                        item.SubItems.Add(dataReader["sTenNV"].ToString());
                        item.SubItems.Add(dataReader["sDiaChi"].ToString());
                        item.SubItems.Add(dataReader["sCCCD"].ToString());
                        item.SubItems.Add(dataReader["dNgaySinh"].ToString());
                        item.SubItems.Add(dataReader["dNgayVaoLam"].ToString());
                        item.SubItems.Add(dataReader["fLuongCoBan"].ToString());
                        item.SubItems.Add(dataReader["fPhuCap"].ToString());
                        listView1.Items.Add(item);
                        

                    }
                    sqlConnection.Close();
                }
            }
           
        }

        private void BTN_BoQua_Click(object sender, EventArgs e)
        {
            TBX_maNV.Text = "";
            TBX_Ten.Text = "";
            TBX_luongCB.Text = "";
            TBX_CCCD.Text = "";
            TBX_Diachi.Text = "";
            TBX_PhuCap.Text = "";
            update_listview();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string reportFilter = TBX_maNV.Text;
            FormBaoCaoTTNV form = new FormBaoCaoTTNV();
            form.Show();
            form.ShowReport_TTNV();
        }
    }
}


































































































//string reportFilter = TBX_maNV.Text;
//FormBaoCaoTTNV form = new FormBaoCaoTTNV();
//form.Show();
//form.ShowReport_TTNV();