using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirplaneReservationWebService.DAL;
using AirplaneReservationWebService.DTO;

namespace AirplaneReservationWebService.Controllers
{
    public class FlightsController : ApiController
    {
        [HttpGet]
        public List<Flight> getAllOrigins()
        {
            List<Flight> result = new List<Flight>();
            DALFlight DAL_Flight = new DALFlight();

            result = DAL_Flight.GetAllFlights();

            return result;
        }


        //tìm danh sách máy bay theo sân bay đi, sân bay đến, ngày đi, số lượng hành khách đăng ký
        [HttpGet]
        public List<Flight> FindFlight(string origin, string destination, string departuredates, int passengerquantity)
        {
            List<Flight> result = new List<Flight>();
            DALFlight DAL_Flight = new DALFlight();

            //tìm danh sách các máy bay thỏa origin, destination, departuredates
             List<Flight> ListFlightODD = new List<Flight>();
             ListFlightODD = DAL_Flight.FindFlight(origin, destination, departuredates);

            //với mỗi chiếc máy bay, có mã máy bay, tính tổng lượng khách đã đặt chỗ
            foreach (Flight flight in ListFlightODD)
            {
                //tinh  tổng hành khách trên máy bay               
                int totalPassengerInFlight = CountPassengerInFlight(flight.FlightCode, flight.DepartureDates);
               
                //số lượng ghế trên máy bay
                int SeatNumberInFlight = DAL_Flight.GetSeatNumberInFlight(flight.FlightCode, flight.DepartureDates, flight.ClassLevel, flight.PriceLevel);

                //so sanh
                if (totalPassengerInFlight <= SeatNumberInFlight)
                {
                    result.Add(flight);
                }                
            }

           return result;
        }

        private int CountPassengerInFlight(string flightcode, string departuredates)
        {
            int result = 0;
            DALFlightDetail DAL_FlightDetail = new DALFlightDetail();
            DALPassenger DAL_Passenger = new DALPassenger();

            List<FlightDetail> ListFlightDetailByFD = new List<FlightDetail>();
            ListFlightDetailByFD = DAL_FlightDetail.GetAllFlightDetailsByID(flightcode, departuredates);

            //với mỗi chi tiết chuyến bay, lẫy mã để tính tổng hành khách trong bảng passenger
            foreach (FlightDetail flightdetail in ListFlightDetailByFD)
            {
                int passengerbybookingcode = DAL_Passenger.CountPassengerByID(flightdetail.BookingCode);
                result += passengerbybookingcode;
            }
            return result;
        }
           
    }
}
