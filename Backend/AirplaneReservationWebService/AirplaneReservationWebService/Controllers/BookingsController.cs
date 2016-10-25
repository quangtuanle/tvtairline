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
    public class BookingsController : ApiController
    {
        [HttpGet]
        public List<Booking> getAllBookings()
        {
            List<Booking> result = new List<Booking>();
            DALBooking DAL_Booking = new DALBooking();

            result = DAL_Booking.GetAllBookings();

            return result;
        }

        [HttpPost]
        public string InsertNewBooking(double payment)
        {
            DALBooking DAL_Booking = new DALBooking();
            string bookingcode = GenerateBookingCode(6);
            //them kiem tra dieu kien

            string datetimes = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if(DAL_Booking.InsertNewBooking(bookingcode, datetimes, payment, false))
            {
                return bookingcode;
            }
            return null;
        }

        //ham generate ma booking
        private static Random random = new Random();
        private string GenerateBookingCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPut]
        public bool UpdateStatusBooking(string bookingcode)
        {
            DALBooking DAL_Booking = new DALBooking();
            if (DAL_Booking.GetCurrentStatus(bookingcode) != -1)
            {
                return DAL_Booking.UpdateStatusBooking(bookingcode);
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteBooking(string bookingcode)
        {
            DALBooking DAL_Booking = new DALBooking();
            return DAL_Booking.DeleteBooking(bookingcode);
        }
    }
}
