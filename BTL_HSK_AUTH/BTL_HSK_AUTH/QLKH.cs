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
    public partial class QLKH : Form
    {
        private DataView dv_KhachHang = new DataView();
        Modify modify = new Modify();
        public QLKH()
        {
            InitializeComponent();
        }
        private void loadDataToGridView()
        {
            using(SqlConnection sqlConnection = connection.getSQLconnection())
            {
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT_KHACHHANG";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        using(DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                dv_KhachHang = dataTable.DefaultView;
                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = dv_KhachHang;
                            }
                            else
                            {
                                MessageBox.Show("Khong co khach hang nao!");
                            }
                        }
                    }
                }
            }
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = "Solanmua";
            column.HeaderText = "Số lần mua";
            dataGridView1.Columns.Add(column);
            SqlDataReader dataReader;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                using (SqlConnection sqlConnection = connection.getSQLconnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = "so_lan_mua";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        string ma = dataGridView1.Rows[i].Cells["sMaKH"].Value.ToString();
                        sqlCommand.Parameters.AddWithValue("@ma", ma);
                        dataReader = sqlCommand.ExecuteReader();
                        while (dataReader.Read())
                        {
                            dataGridView1.Rows[i].Cells["Solanmua"].Value = dataReader.GetInt32(0).ToString();
                        }
                    }

                    sqlConnection.Close();
                }
            }
        }
 

        private void QLKH_Load(object sender, EventArgs e)
        {
            loadDataToGridView();
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            DateTime date;
            TBX_maKH.Text = dataGridView1.Rows[index].Cells["sMaKH"].Value.ToString();
            TBX_TenKH.Text  = dataGridView1.Rows[index].Cells["sTenKH"].Value.ToString();
            TBX_DiachiKH.Text = dataGridView1.Rows[index].Cells["sDiaChi"].Value.ToString();
            string k =  dataGridView1.Rows[index].Cells["dNgaySinh"].Value.ToString();
            date = DateTime.ParseExact(k, "yyyy/MM/dd", null);
            dateTimePicker_NgaySinhKH.Value = date;
            TBX_SDT.Text = dataGridView1.Rows[index].Cells["sSDT"].Value.ToString();
            string gioitinh = dataGridView1.Rows[index].Cells["sGioiTinh"].Value.ToString();
            gioitinh = gioitinh.ToLower();
            if(gioitinh == "nam")
            {
                checkBoxNam.Checked = true;
                checkBoxNu.Checked = false;
            }
            else
            {
                checkBoxNu.Checked = true;
                checkBoxNam.Checked = false;
            }
            MessageBox.Show(dataGridView1.Rows[index].Cells["Solanmua"].Value.ToString());
        }

        private void checkBoxNam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNam.Checked == true)
            {
                checkBoxNu.Checked = false;
            }
            else
            {
                checkBoxNu.Checked = true;
                checkBoxNam.Checked = false;
            }
        }

        private void checkBoxNu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNu.Checked == true)
            {
                checkBoxNam.Checked = false;
            }
            else
            {
                checkBoxNam.Checked = true;
                checkBoxNu.Checked = false;
            }
        }

        private void btn_ThêmKhachHang_Click(object sender, EventArgs e)
        {
            string ma, ten, diachi, sdt, gioitinh = "", ngaysinh;
            ma = TBX_maKH.Text;
            ten = TBX_TenKH.Text;
            diachi = TBX_DiachiKH.Text;
            ngaysinh = dateTimePicker_NgaySinhKH.Value.ToString("yyyy/MM/dd");
            sdt = TBX_SDT.Text;
            if(checkBoxNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            if(checkBoxNu.Checked == true)
            {
                gioitinh = "Nữ";
            }
            if(modify.check_primary_key("tblKhachHang", "sMaKH", ma) == true)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!");
            }
            else
            {
                modify.INSERT_KH(ma, ten, diachi, ngaysinh, sdt, gioitinh);
               
                MessageBox.Show("Thêm thành công!");
                loadDataToGridView();

            }
        }

        private void btn_XoaKH_Click(object sender, EventArgs e)
        {
            if (TBX_maKH.Text == "")
            {
                MessageBox.Show("Mời bạn nhập hoặc chọn mã khách hàng cần xóa!");
            }
            else
            {
                string k = TBX_maKH.Text;
                modify.DELETE_KH(k);
                MessageBox.Show("Xóa khách hàng thành công!");
                loadDataToGridView();
            }

        }

        private void btn_fixKH_Click(object sender, EventArgs e)
        {
            if(TBX_maKH.Text == "" || TBX_TenKH.Text=="" || TBX_DiachiKH.Text=="" || TBX_SDT.Text=="" || (checkBoxNam.Checked==false && checkBoxNu.Checked == false))
            {
                MessageBox.Show("Yeu cau ban nhap day du thong tin!");
            }
            else
            {
                string ma, ten, diachi, ngaysinh, sdt, gioitinh;
                ma = TBX_maKH.Text;
                ten = TBX_TenKH.Text;
                diachi = TBX_DiachiKH.Text;
                ngaysinh = dateTimePicker_NgaySinhKH.Value.ToString("yyyy/mm/dd");
                sdt = TBX_SDT.Text;
                if (checkBoxNam.Checked == true)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                modify.Update_KH(ma,ten,diachi,ngaysinh,sdt, gioitinh);
                MessageBox.Show("Sửa thông tin thành công");
                loadDataToGridView();
                
            }
        }

        private void btn_DSKH_Click(object sender, EventArgs e)
        {
            FormBaoCaoDSKH formBaoCaoDSKH = new FormBaoCaoDSKH();
            formBaoCaoDSKH.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BTN_BoQua_Click(object sender, EventArgs e)
        {
            loadDataToGridView();
            TBX_maKH.Text = "";
            TBX_TenKH.Text = "";
            TBX_DiachiKH.Text = "";
            TBX_SDT.Text = "";
        }

        private void btn_searchKH_Click(object sender, EventArgs e)
        {
            if (TBX_maKH.Text == "")
            {
                MessageBox.Show("Mời bạn điền mã khách hàng cần tìm!");
            }
            else
            {
                string ma = TBX_maKH.Text.Trim();
                using(SqlConnection sqlConnection = connection.getSQLconnection())
                {
                    using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = "SEARCH_KH";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@MA", ma);
                        using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                        {
                            sqlDataAdapter.SelectCommand = sqlCommand;
                            using(DataTable dataTable = new DataTable())
                            {
                                sqlDataAdapter.Fill(dataTable);
                                dataGridView1.DataSource = dataTable;
                            }
                        }
                    }
                }
            }
        }
        public bool IsNumber(string strValue)
        {
            foreach (Char ch in strValue)
            {
                if (!Char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        private void btn_ThêmKhachHang_TextChanged(object sender, EventArgs e)
        {
            if ((TBX_maKH.Text!="" && TBX_DiachiKH.Text!="" && TBX_SDT.Text!="" && TBX_TenKH.Text!="" && dateTimePicker_NgaySinhKH.Text != "") && IsNumber(TBX_SDT.Text) == true)
            {
                btn_ThêmKhachHang.Enabled = true;
            }
            else
            {
                btn_ThêmKhachHang.Enabled = false;
                MessageBox.Show("Yêu cầu nhập đầy đủ và đúng dữ liệuuu");
            }
            {

            }
            {

            }
        }
    }
}
