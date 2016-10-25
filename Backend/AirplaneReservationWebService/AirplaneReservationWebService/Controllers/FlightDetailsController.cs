using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirplaneReservationWebService.DTO;
using AirplaneReservationWebService.DAL;

namespace AirplaneReservationWebService.Controllers
{
    public class FlightDetailsController : ApiController
    {
        //??xuất danh sách chặng bay theo cái gì?
        [HttpGet]
        public List<FlightDetail> getAllFlightDetails()
        {
            List<FlightDetail> result = new List<FlightDetail>();
            DALFlightDetail DAL_FlightDetail = new DALFlightDetail();

            result = DAL_FlightDetail.GetAllFlightDetails();

            return result;
        }

        
        [HttpPost]
        public bool InsertNewFlightDetail(string bookingcode, string flightcode, string departuredates, string classlevel, string pricelevel)
        {
            DALFlightDetail DAL_FlightDetail = new DALFlightDetail();
            return DAL_FlightDetail.InsertNewFlightDetail(bookingcode, flightcode, departuredates, classlevel, pricelevel);
        }
    }
}
