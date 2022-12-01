using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_NhaSachMini
{
    public class DataProvider
    {
        SqlConnection connection = new SqlConnection();
        public DataProvider()
        {
            try
            {
                connection.ConnectionString = @"Data Source=DESKTOP-2VR92U8;Initial Catalog=QL-NhaSach;Integrated Security=True";
                connection.Open();
            }
            catch { }
        }
        public DataTable loadAccount()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_load_account";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
    }
}
