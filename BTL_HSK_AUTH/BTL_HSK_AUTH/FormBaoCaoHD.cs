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
    public partial class FormBaoCaoHD : Form
    {
        public FormBaoCaoHD()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            showReportHD();
        }
        public void showReportHD()
        {
            using (SqlConnection sqlConnection = connection.getSQLconnection())
            {
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT_HD";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using( SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {
                        dataAdapter.SelectCommand = sqlCommand;
                        using(DataTable dataTable = new DataTable())
                        {
                            dataAdapter.Fill(dataTable);
                            ReportDocument reportDocument = new ReportDocument();
                            string path = @"C:\Users\DELL\source\repos\BTL_HSK_AUTH\BTL_HSK_AUTH\BaoCao\DSHD.rpt";
                            reportDocument.Load(path);
                            reportDocument.Database.Tables["tblHoaDon"].SetDataSource(dataTable);
                            crystalReportViewer1.ReportSource = reportDocument;
                            
                        }
                    }
                }
            }
        }
    }
}
