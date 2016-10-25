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
    public class PassengersController : ApiController
    {
        [HttpGet]
        public List<Passenger> getAllPassengers()
        {
            List<Passenger> result = new List<Passenger>();
            DALPassenger DAL_Passenger = new DALPassenger();

            result = DAL_Passenger.GetAllPassengers();


            return result;
        }

        [HttpPost]
        public bool InsertNewPassenger(string bookingcode, string epithets, string firstname, string lastname, int agecode)
        { 
                DALPassenger DAL_Passenger = new DALPassenger();
                return DAL_Passenger.InsertNewPassenger(bookingcode, epithets, firstname, lastname, agecode);
           
        }
    }
}
