using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BTL_HSK_AUTH
{
    class Modify
    {
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public Modify()
        {
    
        }
        public List<TaiKhoan> listTaiKhoan(string query) {
            List<TaiKhoan> listTaiKhoan = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    listTaiKhoan.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }

                sqlConnection.Close();
            }
                return listTaiKhoan;
        } 
        public bool check_primary_key(string table, string colum, string value)
        {
            using(SqlConnection sqlConnection = connection.getSQLconnection())
            {
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "CheckPrimaryKeyExists";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@tableName",table);
                    sqlCommand.Parameters.AddWithValue("@columnName", colum);
                    sqlCommand.Parameters.AddWithValue("@value", value);
                    sqlConnection.Open();
                    int result = (int)sqlCommand.ExecuteScalar();
                    sqlConnection.Close();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public void add_TaiKhoan(string taikhoan, string matkhau)

        { 
            string query = "INSERT INTO TaiKhoan (sTaiKhoan, sMatKhau) VALUES (@taikhoan, @matkhau)";
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@taikhoan", taikhoan);
                sqlCommand.Parameters.AddWithValue("@matkhau", matkhau);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void add_NhanVien(string maNV, string tenNV, string diaChi, string cccd, string ngaysinh, string ngayvaolam, string luongcoban, string phucap)

        {
            string query = "INSERT INTO tblNhanVien (sMaNV, sTenNV, sDiaChi, dNgaySinh, dNgayVaoLam, sCCCD, fLuongCoBan, fPhuCap) VALUES (@maNV, @TenNV, @DiaChi, @NgaySinh, @NgayVaoLam, @CCCD, @luongcoban, @phucap )";
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@maNV", maNV);
                sqlCommand.Parameters.AddWithValue("@TenNV", tenNV);
                sqlCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                sqlCommand.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                sqlCommand.Parameters.AddWithValue("@NgayVaoLam", ngayvaolam);
                sqlCommand.Parameters.AddWithValue("@CCCD", cccd);
                sqlCommand.Parameters.AddWithValue("@luongcoban", luongcoban );
                sqlCommand.Parameters.AddWithValue("@phucap", phucap);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void Update_NhanVien(string maNV, string tenNV, string diaChi, string cccd, string ngaysinh, string ngayvaolam, string luongcoban, string phucap)
        {
            string query = "UPDATE tblNhanVien SET sTenNV=@TenNV, sDiaChi=@DiaChi, dNgaySinh=@NgaySinh, dNgayVaoLam=@NgayVaoLam, sCCCD=@CCCD, fLuongCoBan=@luongcoban, fPhuCap=@phucap WHERE sMaNV=@maNV";
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@maNV", maNV);
                sqlCommand.Parameters.AddWithValue("@TenNV", tenNV);
                sqlCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                sqlCommand.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                sqlCommand.Parameters.AddWithValue("@NgayVaoLam", ngayvaolam);
                sqlCommand.Parameters.AddWithValue("@CCCD", cccd);
                sqlCommand.Parameters.AddWithValue("@luongcoban", luongcoban);
                sqlCommand.Parameters.AddWithValue("@phucap", phucap);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void Delete_NhanVien(string maNV)
        {
            using(SqlConnection sql = connection.getSQLconnection())
            {            
                using(SqlCommand command = sql.CreateCommand())
                {
                    command.CommandText = "DELETE_NV";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MA", maNV);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void INSERT_KH(string ma, string ten, string diachi, string ngaysinh, string sdt, string gioitinh)
        {
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "INSERT_KH";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@sMa", ma);
                    sqlCommand.Parameters.AddWithValue("@sTen", ten);
                    sqlCommand.Parameters.AddWithValue("@sdiachi", diachi);
                    sqlCommand.Parameters.AddWithValue("@dngaysinh", ngaysinh);
                    sqlCommand.Parameters.AddWithValue("@ssdt", sdt);
                    sqlCommand.Parameters.AddWithValue("@sgioitinh", gioitinh);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
        public void DELETE_KH(string ma)
        {
            using(SqlConnection sqlConnection = connection.getSQLconnection())
             {
                 sqlConnection.Open();
                 using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                 {
                     sqlCommand.CommandText = "DELETE_KH";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                     sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                     sqlCommand.Parameters.AddWithValue("@MA", ma);
                     sqlCommand.ExecuteNonQuery();
                 }
                 sqlConnection.Close();
             }
            /*
            string query = "DELETE FROM tblKhachHang WHERE sMaKH=@maKH";
            using (SqlConnection sql = connection.getSQLconnection())
            {
                sql.Open();
                sqlCommand = new SqlCommand(query, sql);
                sqlCommand.Parameters.AddWithValue("@maKH", ma);
                sqlCommand.ExecuteNonQuery();
                sql.Close();
            }*/
        }
        public void Update_KH(string maKH, string tenKH, string diaChi, string ngaysinh, string sdt , string gioitinh)
        {
            string query = "UPDATE tblKhachHang SET sTenKh=@TenKH, sDiaChi=@DiaChi, dNgaySinh=@NgaySinh, sSDT=@sdt, sGioiTinh=@gioitinh WHERE sMaKH=@ma";
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ma", maKH);
                sqlCommand.Parameters.AddWithValue("@TenKH", tenKH);
                sqlCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                sqlCommand.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                sqlCommand.Parameters.AddWithValue("@sdt",sdt );
                sqlCommand.Parameters.AddWithValue("@gioitinh", gioitinh);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void Insert_HoaDon(string soHD, string maNV, string maKH, string ngaylap)
        {
            using(SqlConnection sqlConnection = connection.getSQLconnection())

            {
                sqlConnection.Open();
                using(SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "INSERT_HD";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SO", soHD);
                    command.Parameters.AddWithValue("@MA1", maNV);
                    command.Parameters.AddWithValue("@MA2", maKH);
                    command.Parameters.AddWithValue("@dngaylap", ngaylap);

                    command.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
        public void Update_HD(string soHD, string maNV, string mKH, string ngaylap)
        {
            string query = "UPDATE tblHoaDon SET  sMaNV=@manv, sMaKH=@makh, dNgayLap=@ngaylap WHERE sSoHD=@so";
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@so", soHD);
                sqlCommand.Parameters.AddWithValue("@manv", maNV);
                sqlCommand.Parameters.AddWithValue("@makh", mKH);
                sqlCommand.Parameters.AddWithValue("@ngaylap", ngaylap);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void DELETE_HD(string sohd)
        {
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "DELETE_HD";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SO", sohd);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
        public void INSERT_SP(string masp, string tensp, float dongia, string nuocsx, string mansx, string maloai, string mancc, float soluong)
        {
            using(SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "INSERT_SP";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@masp", masp);
                    sqlCommand.Parameters.AddWithValue("@tensp", tensp);
                    sqlCommand.Parameters.AddWithValue("@dongia", dongia);
                    sqlCommand.Parameters.AddWithValue("@nuocsx", nuocsx);
                    sqlCommand.Parameters.AddWithValue("@mansx", mansx);
                    sqlCommand.Parameters.AddWithValue("@maloai", maloai);
                    sqlCommand.Parameters.AddWithValue("@mancc", mancc);
                    sqlCommand.Parameters.AddWithValue("@soluong", soluong);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
        public void Update_SP(string masp, string tensp, float dongia, string nuocsx, string mansx, string maloai, string mancc, float soluong)
        {
            string query = "UPDATE tblSanPham SET sTenSanPham=@tensp, fDonGia=@dongia, sNuocSX=@nuocsx, sMaNSX=@mansx, sMaLoai=@maloai, sMaNCC=@mancc, fSoLuongKho=@soluong WHERE sMaSanPham=@masp";
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@masp", masp);
                sqlCommand.Parameters.AddWithValue("@tensp", tensp);
                sqlCommand.Parameters.AddWithValue("@dongia", dongia);
                sqlCommand.Parameters.AddWithValue("@nuocsx", nuocsx);
                sqlCommand.Parameters.AddWithValue("@mansx", mansx);
                sqlCommand.Parameters.AddWithValue("@maloai", maloai);
                sqlCommand.Parameters.AddWithValue("@mancc", mancc);
                sqlCommand.Parameters.AddWithValue("@soluong", soluong);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void DELETE_SP(string ma)
        {
            using(SqlConnection sqlConnection = connection.getSQLconnection())
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "DELETE_SP";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@masp", ma);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
    }
}