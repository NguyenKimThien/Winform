using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTL_HSK_AUTH
{
    class connection
    {
         private static string connectionString = @"Data Source=DESKTOP-VVSLPEA\SQLEXPRESS;Initial Catalog=BaiTapLon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection getSQLconnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
