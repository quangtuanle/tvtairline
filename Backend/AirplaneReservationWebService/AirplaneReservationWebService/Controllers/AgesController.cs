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
    public class AgesController : ApiController
    {

        [HttpGet]
        public List<Age> getAllAges()
        {
            List<Age> result = new List<Age>();
            DALAge DAL_Age = new DALAge();

            result = DAL_Age.GetAllAges();

            return result;
        }

    }
}
