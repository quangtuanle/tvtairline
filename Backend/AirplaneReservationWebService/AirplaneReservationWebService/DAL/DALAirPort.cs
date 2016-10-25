using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirplaneReservationWebService.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AirplaneReservationWebService.DAL
{
    public class DALAirPort : DBConnect
    {
        public List<AirPort> GetAllAirPorts()
        {
            try
            {
                _connect.Open();
                string sql = "select * from airPort";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<AirPort> result = new List<AirPort>();
                foreach (DataRow row in _dt.Rows)
                {
                    AirPort currentAirPort = new AirPort(row["airPortCode"].ToString(), row["airPortName"].ToString(), row["area"].ToString());
                    result.Add(currentAirPort);
                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public AirPort GetAirPortById(string airportcode)
        {
            try
            {
                AirPort currentAirPort = new AirPort();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connect;
                cmd.CommandText = "select * from airPort where airPortCode = airportcode";
                cmd.CommandType = CommandType.Text;
                _connect.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    currentAirPort.AirPortCode = dr["airPortCode"].ToString();
                    currentAirPort.AirPortName = dr["airPortName"].ToString();
                    currentAirPort.Area = dr["area"].ToString();
                }
                _connect.Close();
                return currentAirPort;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AirPort> GetAllOrigins()
        {
            try
            {
                _connect.Open();
                string sql = "select distinct ap.airPortCode, ap.airPortName, ap.area from airPort ap, flight f where ap.airPortCode = f.origin";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<AirPort> result = new List<AirPort>();

                foreach (DataRow row in _dt.Rows)
                {
                    AirPort currentAirPort = new AirPort(row["airPortCode"].ToString(), row["airPortName"].ToString(), row["area"].ToString());
                    result.Add(currentAirPort);
                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public List<AirPort> GetAllDestinationsByOrigin(String origin)
        {
            try
            {
                _connect.Open();
                string sql = "select distinct ap.airPortCode, ap.airPortName, ap.area from airPort ap, flight f where ap.airPortCode = f.destination and f.origin = '" + origin + "'";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<AirPort> result = new List<AirPort>();

                foreach (DataRow row in _dt.Rows)
                {
                    AirPort currentAirPort = new AirPort(row["airPortCode"].ToString(), row["airPortName"].ToString(), row["area"].ToString());
                    result.Add(currentAirPort);
                }
                _connect.Close();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public List<AirPort> GetAllDestinations()
        {
            try
            {
                _connect.Open();
                string sql = "select distinct ap.airPortCode, ap.airPortName, ap.area from airPort ap, flight f where ap.airPortCode = f.destination";
                SqlDataAdapter _da = new SqlDataAdapter(sql, _connect);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);

                List<AirPort> result = new List<AirPort>();

                foreach (DataRow row in _dt.Rows)
                {
                    AirPort currentAirPort = new AirPort(row["airPortCode"].ToString(), row["airPortName"].ToString(), row["area"].ToString());
                    result.Add(currentAirPort);
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