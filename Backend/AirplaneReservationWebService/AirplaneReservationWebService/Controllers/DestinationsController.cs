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
    public class DestinationsController : ApiController
    {
        [HttpGet]
        public List<AirPort> getAllDestinationsByOrigin(String origin)
        {
            List<AirPort> result = new List<AirPort>();
            DALAirPort DAL_AirPort = new DALAirPort();

            result = DAL_AirPort.GetAllDestinationsByOrigin(origin);


            return result;
        }

        [HttpGet]
        public List<AirPort> getAllDestinations()
        {
            List<AirPort> result = new List<AirPort>();
            DALAirPort DAL_AirPort = new DALAirPort();

            result = DAL_AirPort.GetAllDestinations();


            return result;
        }
    }
}
