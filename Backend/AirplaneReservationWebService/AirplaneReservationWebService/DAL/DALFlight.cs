using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirplaneReservationWebService.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AirplaneReservationWebService.DAL
{
    public class DALFlight : DBConnect
    {
        public List<Flight> GetAllFlights()
        {
            try
            {
                _connect.Open();
                string sql = "select * from flight";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<Flight> result = new List<Flight>();
                
                foreach (DataRow row in _dt.Rows)
                {
                    Flight currentFlight = new Flight(row["flightCode"].ToString(), row["origin"].ToString(), row["destination"].ToString(),
                        row["departureDates"].ToString(), row["departureTimes"].ToString(), row["classLevel"].ToString(), row["priceLevel"].ToString(), Int32.Parse(row["seatNumber"].ToString()), Double.Parse(row["price"].ToString()));
                    result.Add(currentFlight);

                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }


        //so sanh tổng số lượng hành khách đã cộng vào so với số lượng ghế của máy bay
        public List<Flight> FindFlight(string origin, string destination, string departuredates)
        {
            try
            {
                _connect.Open();
                string sql = "select * from flight where (origin = '" + origin + "' and destination = '" + destination + "')";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<Flight> result = new List<Flight>();

                foreach (DataRow row in _dt.Rows)
                {
                    Flight currentFlight = new Flight(row["flightCode"].ToString(), row["origin"].ToString(), row["destination"].ToString(),
                        row["departureDates"].ToString(), row["departureTimes"].ToString(), row["classLevel"].ToString(), row["priceLevel"].ToString(), Int32.Parse(row["seatNumber"].ToString()), Double.Parse(row["price"].ToString()));
                    result.Add(currentFlight);

                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public int GetSeatNumberInFlight(string flightcode, string departuredates, string classlevel, string pricelevel)
        {
            try
            {
                int result;
                _connect.Open();
                string sql = "select seatNumber from flight where (flightCode = '" + flightcode + "' and departureDates = '" + departuredates +
                    "' and classLevel = '" + classlevel + "' and priceLevel = '" + pricelevel + "')";
                SqlCommand cmd = new SqlCommand(sql, _connect);
                result = (int) cmd.ExecuteScalar();
                _connect.Close();
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool DeleteFight(string flightcode)
        {
            try
            {
                _connect.Open();
                string sql = "delete from flight where flightCode = '" + flightcode + "'";

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