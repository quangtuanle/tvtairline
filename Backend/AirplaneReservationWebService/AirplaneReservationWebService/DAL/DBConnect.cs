using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AirplaneReservationWebService
{
    public class DBConnect
    {
        protected SqlConnection _connect = new SqlConnection(ConfigurationManager.ConnectionStrings["AirplaneReservationDBConnectionString"].ConnectionString);

        public DataTable ReadTable(string TableName)
        {
            DataTable result = new DataTable();

            string SQL = "select * from " + TableName;
            SqlDataAdapter da = new SqlDataAdapter(SQL, _connect);
            da.Fill(result);

            return result;
        }

        public void Connect()
        {
            try
            {
                if (_connect.State != ConnectionState.Open)
                {
                    _connect.Open();
                }
            }
            catch(Exception)
            {
                return;
            }
        }

        public void Close()
        {
            _connect.Close();
            _connect.Dispose();
            _connect = null;
        }
    }
}