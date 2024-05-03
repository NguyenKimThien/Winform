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
    public partial class QLHD : Form
    {
        DataView dv_HD = new DataView();
        Modify modify = new Modify();
        public QLHD()   
        {
            InitializeComponent();
        }

        private void QLHD_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            using(SqlConnection sqlConnection = connection.getSQLconnection())
            {
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT_HD";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {
                        dataAdapter.SelectCommand = sqlCommand;
                        using(DataTable dataTable = new DataTable())
                        {
                            dataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                dv_HD = dataTable.DefaultView;
                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = dv_HD;
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
            TBX_soHD.Text = dataGridView1.Rows[index].Cells["sSoHD"].Value.ToString();
            TBX_maNV.Text = dataGridView1.Rows[index].Cells["sMaNV"].Value.ToString();
            TBX_maKH.Text = dataGridView1.Rows[index].Cells["sMaKH"].Value.ToString();
            DateTime date;
            string k = dataGridView1.Rows[index].Cells["dNgayLap"].Value.ToString();
            date = DateTime.ParseExact(k, "yyyy/MM/dd", null);
            dateTimePicker_NgayLapHD.Value = date;
        }

        private void BTN_BoQua_Click(object sender, EventArgs e)
        {
            TBX_maKH.Text = "";
            TBX_maNV.Text = "";
            TBX_soHD.Text = "";
            LoadDataGridView();
        }

        private void btn_ThêmKhachHang_Click(object sender, EventArgs e)
        {
            if(TBX_soHD.Text=="" || TBX_maNV.Text=="" || TBX_maKH.Text=="" || dateTimePicker_NgayLapHD.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin trước khi thêm!");
            }
            else
            {
                string so, makh, manv, ngaylap;
                so = TBX_soHD.Text;
                manv = TBX_maNV.Text;
                makh = TBX_maKH.Text;
                ngaylap = dateTimePicker_NgayLapHD.Value.ToString("yyyy/MM/dd");
                if(modify.check_primary_key("tblHoaDon", "sSoHD", so) == true)
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại !");
                }
                else
                {
                    modify.Insert_HoaDon(so, manv, makh, ngaylap);
                    MessageBox.Show("Thêm hóa đơn thành công!");
                    LoadDataGridView();
                }
            }
        }

        private void btn_DSKH_Click(object sender, EventArgs e)
        {
            FormBaoCaoHD form = new FormBaoCaoHD();
            form.Show();
        }

        private void btn_fixKH_Click(object sender, EventArgs e)
        {
            if(TBX_soHD.Text==""||TBX_maNV.Text==""|| TBX_maKH.Text == "" || dateTimePicker_NgayLapHD.Text == "")
            {
                MessageBox.Show("Yêu cầu bạn nhập đầy đủ dữ liệu trước khi sửa!");
            }
            else
            {
                string sohd, manv, makh, ngaylap;
                sohd = TBX_soHD.Text;
                manv = TBX_maNV.Text;
                makh = TBX_maKH.Text;
                ngaylap = dateTimePicker_NgayLapHD.Value.ToString("yyyy/MM/dd");
                if(modify.check_primary_key("tblHoaDon", "sSoHD", sohd) == true)
                {
                    modify.Update_HD(sohd, manv, makh, ngaylap);
                    MessageBox.Show("Sửa thông tin thành công !");
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Số hóa đơn không tồn tại");
                }
            }
        }

        private void btn_XoaKH_Click(object sender, EventArgs e)
        {
            if (TBX_soHD.Text == "")
            {
                MessageBox.Show("Bạn phải điền số hóa đơn cần xóa!");
            }
            else
            {
                string so = TBX_soHD.Text;
                if(modify.check_primary_key("tblHoaDon", "sSoHD", so) == true)
                {
                    modify.DELETE_HD(so);
                    MessageBox.Show("Đã xóa hóa dơn thành công!");
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Hóa đơn không tồn tại!");
                }
            }
        }

        private void btn_searchKH_Click(object sender, EventArgs e)
        {
            if (TBX_soHD.Text == "")
            {
                MessageBox.Show("Yêu cầu bạn nhập số hóa đơn cần tìm");
            }
            else
            {
                string so = TBX_soHD.Text;
                if(modify.check_primary_key("tblHoaDon", "sSoHD", so) == true)
                {
                    using(SqlConnection sqlConnection = connection.getSQLconnection())
                    {
                        sqlConnection.Open();
                        using(SqlCommand command = sqlConnection.CreateCommand())
                        {
                            command.CommandText = "SEARCH_HD";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@SO", so);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                            {
                                dataAdapter.SelectCommand = command;
                                using( DataTable dataTable = new DataTable())
                                {
                                    dataAdapter.Fill(dataTable);
                                    dataGridView1.DataSource = dataTable;
                                    
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
