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
    public class OriginsController : ApiController
    {
        [HttpGet]
        public List<AirPort> getAllOrigins()
        {
            List<AirPort> result = new List<AirPort>();
            DALAirPort DAL_AirPort = new DALAirPort();
 
            result = DAL_AirPort.GetAllOrigins();
           
 
            return result;
        }
 
        [HttpGet]
        public AirPort getOrigin(string airPortCode)
        {
            AirPort result = null;
            DALAirPort DAL_AirPort = new DALAirPort();
            result = DAL_AirPort.GetAirPortById(airPortCode);
         
            return result;
        }
    }
}
