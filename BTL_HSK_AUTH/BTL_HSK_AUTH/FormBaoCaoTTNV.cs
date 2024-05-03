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
using CrystalDecisions.CrystalReports.Engine;

namespace BTL_HSK_AUTH
{
    public partial class FormBaoCaoTTNV : Form
    {
        public FormBaoCaoTTNV()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
 
        }

        public void ShowReport_TTNV()
        {
            try
            {
                using (SqlConnection sqlConnection = connection.getSQLconnection())
                {
                    using (SqlCommand command = sqlConnection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM tblNhanVien Inner Join tblHoaDon On tblNhanVien.sMaNV=tblHoaDon.sMaNV";
                        command.CommandType = CommandType.Text;
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            using (DataTable dataTable = new DataTable())
                            {
                                adapter.Fill(dataTable);

                                //Nap report len reportViewer
                                ReportDocument reportDocument = new ReportDocument();
                                //string path = string.Format(@"C:\Users\DELL\source\repos\BTL_HSK_AUTH\BTL_HSK_AUTH\BaoCao\DSNV.rpt",
                                //    Application.StartupPath);
                                string path = @"C:\Users\DELL\source\repos\BTL_HSK_AUTH\BTL_HSK_AUTH\BaoCao\CrystalReport1.rpt";
                                reportDocument.Load(path);
                                //Thiet lap nguon du lieu cho bao cao
                                reportDocument.Database.Tables["HD_BY_MANV"].SetDataSource(dataTable);                         
                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
