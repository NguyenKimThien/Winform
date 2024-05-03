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
    public partial class QLSP : Form
    {
        DataView dv_SP = new DataView();
        public QLSP()
        {
            InitializeComponent();
        }

        private void QLSP_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }
        public void LoadDataToGridView()
        {
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT_SP";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {
                        dataAdapter.SelectCommand = sqlCommand;
                        using(DataTable dataTable = new DataTable())
                        {
                            dataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                dv_SP = dataTable.DefaultView;
                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = dv_SP;

                            }
                            else
                            {
                                MessageBox.Show("Không có sản phẩm nào!");
                            }
                        }
                    }
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            TBX_maSP.Text = dataGridView1.Rows[index].Cells["sMaSanPham"].Value.ToString();
            TBX_TenSP.Text = dataGridView1.Rows[index].Cells["sTenSanPham"].Value.ToString();
            TBX_DonGia.Text = dataGridView1.Rows[index].Cells["fDonGia"].Value.ToString();
            TBX_NSX.Text = dataGridView1.Rows[index].Cells["sNuocSX"].Value.ToString();
            TBX_MaNSX.Text= dataGridView1.Rows[index].Cells["sMaNSX"].Value.ToString();
            TBX_MaLoai.Text = dataGridView1.Rows[index].Cells["sMaLoai"].Value.ToString();
            TBX_MaNCC.Text = dataGridView1.Rows[index].Cells["sMaNCC"].Value.ToString();
            TBX_SoLuong.Text = dataGridView1.Rows[index].Cells["fSoLuongKho"].Value.ToString();
        }

        private void BTN_BoQua_Click(object sender, EventArgs e)
        {
            TBX_MaNSX.Text = TBX_DonGia.Text = TBX_MaLoai.Text = TBX_MaNCC.Text = TBX_maSP.Text = TBX_SoLuong.Text = TBX_NSX.Text = TBX_TenSP.Text = "";
            LoadDataToGridView();
        }
        Modify modify = new Modify();

        private void btn_themSP_Click(object sender, EventArgs e)
        {
            if (TBX_DonGia.Text == "" || TBX_MaLoai.Text == "" || TBX_MaNCC.Text == "" || TBX_MaNSX.Text == "" || TBX_maSP.Text == "" || TBX_NSX.Text == "" || TBX_SoLuong.Text == "" || TBX_TenSP.Text == "")
            {
                MessageBox.Show("Yêu cầu bạn nhập đầy đủ thông tin!");
            }
            else
            {
                string masp, tensp, nuocsx, mansx, maloai, mancc;
                float dongia, soluong;
                masp = TBX_maSP.Text;
                tensp = TBX_TenSP.Text;
                nuocsx = TBX_NSX.Text;
                mansx = TBX_MaNSX.Text;
                maloai = TBX_MaLoai.Text;
                mancc = TBX_MaNCC.Text;
                dongia = float.Parse(TBX_DonGia.Text);
                soluong = float.Parse(TBX_SoLuong.Text);
                if(modify.check_primary_key("tblSanPham", "sMaSanPham", masp) == false)
                {
                    modify.INSERT_SP(masp, tensp, dongia, nuocsx, mansx, maloai, mancc, soluong);
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadDataToGridView();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!");
                }


            }
        }

        private void btn_fixSP_Click(object sender, EventArgs e)
        {
            if (TBX_DonGia.Text == "" || TBX_MaLoai.Text == "" || TBX_MaNCC.Text == "" || TBX_MaNSX.Text == "" || TBX_maSP.Text == "" || TBX_NSX.Text == "" || TBX_SoLuong.Text == "" || TBX_TenSP.Text == "")
            {
                MessageBox.Show("Yêu cầu bạn nhập đầy đủ thông tin!");
            }
            else
            {
                string masp, tensp, nuocsx, mansx, maloai, mancc;
                float dongia, soluong;
                masp = TBX_maSP.Text;
                tensp = TBX_TenSP.Text;
                nuocsx = TBX_NSX.Text;
                mansx = TBX_MaNSX.Text;
                maloai = TBX_MaLoai.Text;
                mancc = TBX_MaNCC.Text;
                dongia = float.Parse(TBX_DonGia.Text);
                soluong = float.Parse(TBX_SoLuong.Text);
                if (modify.check_primary_key("tblSanPham", "sMaSanPham", masp) == true)
                {
                    modify. Update_SP(masp, tensp, dongia, nuocsx, mansx, maloai, mancc, soluong);
                    MessageBox.Show("Sửa thông tin sản phẩm thành công!");
                    LoadDataToGridView();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm cần sửa không tồn tại!");
                }


            }
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            if (TBX_maSP.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập mã sản phẩm cần xóa!");
            }
            else
            {
                string ma;
                ma = TBX_maSP.Text;
                if(modify.check_primary_key("tblSanPham", "sMaSanPham", ma) == true)
                {
                    modify.DELETE_SP(ma);
                    MessageBox.Show("Đã xóa sản phẩm thành công");
                    LoadDataToGridView();
                }
                else
                {
                    MessageBox.Show("mã sản phẩm cần xóa không tồn tại!");
                }
            }
        }

        private void btn_searchSP_Click(object sender, EventArgs e)
        {
            if (TBX_maSP.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập mã sản phẩm cần xóa!");
            }
            else
            {
                string ma;
                ma = TBX_maSP.Text;
                if (modify.check_primary_key("tblSanPham", "sMaSanPham", ma) == true)
                {
                    using(SqlConnection sqlConnection = connection.getSQLconnection())
                    {
                        sqlConnection.Open();
                        using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                        {
                            sqlCommand.CommandText = "SEARCH_SP";
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@MA", ma);
                            using(SqlDataAdapter dataAdapter = new SqlDataAdapter())
                            {
                                dataAdapter.SelectCommand = sqlCommand;
                                using (DataTable dataTable = new DataTable())
                                {
                                    dataAdapter.Fill(dataTable);
                                    dataGridView1.DataSource = dataTable;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại!");
                }
            }
        }
    }
}
