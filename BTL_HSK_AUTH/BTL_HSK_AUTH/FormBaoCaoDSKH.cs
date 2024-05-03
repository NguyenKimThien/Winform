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
    public partial class FormBaoCaoDSKH : Form
    {
        public FormBaoCaoDSKH()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            show_report_DSKH();

        }
        public void show_report_DSKH()
        {
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                using(SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "SELECT_KHACHHANG";
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlDataAdapter.SelectCommand = command;
                        using(DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);
                            ReportDocument reportDocument = new ReportDocument();
                            string path = @"C:\Users\DELL\source\repos\BTL_HSK_AUTH\BTL_HSK_AUTH\BaoCao\DSKH.rpt";
                            reportDocument.Load(path);
                            reportDocument.Database.Tables["tblKhachHang"].SetDataSource(dataTable);
                            crystalReportViewer1.ReportSource = reportDocument;
                        }
                    }
                }
            }
        }
    }
}
