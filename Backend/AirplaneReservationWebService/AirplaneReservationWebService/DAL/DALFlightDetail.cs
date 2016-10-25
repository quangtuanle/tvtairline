using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirplaneReservationWebService.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AirplaneReservationWebService.DAL
{
    public class DALFlightDetail : DBConnect
    {
        public List<FlightDetail> GetAllFlightDetails()
        {
            try
            {
                _connect.Open();
                string sql = "select * from flightDetail";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<FlightDetail> result = new List<FlightDetail>();

                foreach (DataRow row in _dt.Rows)
                {
                    FlightDetail currentFlightDetail = new FlightDetail(row["bookingCode"].ToString(), row["flightCode"].ToString(), row["departureDates"].ToString(),
                        row["classLevel"].ToString(), row["priceLevel"].ToString());
                    result.Add(currentFlightDetail);

                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public bool InsertNewFlightDetail(string bookingcode, string flightcode, string departuredates, string classleverl, string pricelevel)
        {
            try
            {

                _connect.Open();

            
                string sql = "insert into flightDetail values('" + bookingcode + "', '" + flightcode + "', '" + departuredates + "', '" + classleverl + "', '" + pricelevel + "')";
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

        public List<FlightDetail> GetAllFlightDetailsByID(string flightcode, string departuredates)
        {
            try
            {
                _connect.Open();
                string sql = "select distinct * from flightDetail where (flightCode = '" + flightcode + "' and departureDates = '" + departuredates + "')";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<FlightDetail> result = new List<FlightDetail>();

                foreach (DataRow row in _dt.Rows)
                {
                    FlightDetail currentFlightDetail = new FlightDetail(row["bookingCode"].ToString(), row["flightCode"].ToString(), row["departureDates"].ToString(),
                        row["classLevel"].ToString(), row["priceLevel"].ToString());
                    result.Add(currentFlightDetail);

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