using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneReservationWebService.DTO
{
    public class Booking
    {
        private string _bookingCode;

        public string BookingCode
        {
            get { return _bookingCode; }
            set { _bookingCode = value; }
        }
        private string _bookingTimes;

        public string BookingTimes
        {
            get { return _bookingTimes; }
            set { _bookingTimes = value; }
        }
        private double _payment;

        public double Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }
        private bool _status;

        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Booking(string bookingcode, string bookingtimes, double payment, bool status)
        {
            _bookingCode = bookingcode;
            _bookingTimes = bookingtimes;
            _payment = payment;
            _status = status;
        }
        public Booking()
        {
            
        }
    }

}