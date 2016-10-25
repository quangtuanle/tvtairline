using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirplaneReservationWebService.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AirplaneReservationWebService.DAL
{
    public class DALAge : DBConnect
    {
        public List<Age> GetAllAges()
        {
            try
            {
                _connect.Open();
                string sql = "select * from age";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<Age> result = new List<Age>();

                foreach (DataRow row in _dt.Rows)
                {
                    Age currentAge = new Age(Int32.Parse(row["ageCode"].ToString()), row["ageDetail"].ToString());
                    result.Add(currentAge);
                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}