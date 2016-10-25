using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirplaneReservationWebService.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AirplaneReservationWebService.DAL
{
    public class DALBooking : DBConnect
    {
        public List<Booking> GetAllBookings()
        {
            try
            {
                _connect.Open();
                string sql = "select * from booking";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<Booking> result = new List<Booking>();

                foreach (DataRow row in _dt.Rows)
                {
                    Booking currentBooking = new Booking(row["bookingCode"].ToString(), row["bookingTimes"].ToString(), Double.Parse(row["payment"].ToString()),
                        Boolean.Parse(row["status"].ToString()));
                    result.Add(currentBooking);

                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public bool InsertNewBooking(string bookingcode, string bookingtimes, double payment, bool status)
        {
            try
            {

                _connect.Open();
                string sql = "insert into Booking values('" + bookingcode + "', '" + bookingtimes + "', " + payment + ", " + 0 + ")";
                SqlCommand cmd = new SqlCommand(sql, _connect);
                cmd.ExecuteNonQuery();
                _connect.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateStatusBooking(string bookingcode)
        {
            try
            {
            
                _connect.Open();
                string sql = "update Booking set status = 1 where bookingcode = '" + bookingcode + "'";
                SqlCommand cmd = new SqlCommand(sql, _connect);
                cmd.ExecuteNonQuery();
                _connect.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int GetCurrentStatus(string bookingcode)
        {
            try
            {
                _connect.Open();
                string sql = "select status from Booking where bookingCode = '" + bookingcode + "'";
                SqlCommand cmd = new SqlCommand(sql, _connect);
                return (int) cmd.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
        }

        public bool DeleteBooking(string bookingcode)
        {
            try
            {
                _connect.Open();
                string sql = "delete from booking where bookingCode = '" + bookingcode + "'";

                SqlCommand cmd = new SqlCommand(sql, _connect);
                cmd.ExecuteNonQuery();
                _connect.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}