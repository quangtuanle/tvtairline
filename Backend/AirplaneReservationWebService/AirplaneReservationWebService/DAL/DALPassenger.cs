using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirplaneReservationWebService.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AirplaneReservationWebService.DAL
{
    public class DALPassenger : DBConnect
    {
        public List<Passenger> GetAllPassengers()
        {
            try
            {
                _connect.Open();
                string sql = "select * from passenger";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<Passenger> result = new List<Passenger>();

                foreach (DataRow row in _dt.Rows)
                {
                    Passenger currentPassenger = new Passenger(row["bookingCode"].ToString(), row["epithets"].ToString(), row["firstname"].ToString(),
                        row["lastname"].ToString(), Int32.Parse(row["ageCode"].ToString()));
                    result.Add(currentPassenger);
                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public bool InsertNewPassenger(string bookingcode, string epithets, string firstname, string lastname, int agecode)
        {
            try
            {

                _connect.Open();
                string sql = "insert into Passenger values('" + bookingcode + "', '" + epithets + "', '" + firstname + "', '" + lastname + "', " + agecode + ")";
                SqlCommand cmd = new SqlCommand(sql, _connect);
                cmd.ExecuteNonQuery();
                _connect.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public int CountPassengerByID(string bookingcode)
        {
            try
            {
                int result; 
                _connect.Open();
                string sql = "select count(*) from passenger where bookingCode = '" + bookingcode + "'";
                SqlCommand cmd = new SqlCommand(sql, _connect);
                result = (int)cmd.ExecuteScalar();
                _connect.Close();
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}