using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneReservationWebService.DTO
{
    public class FlightDetail
    {
        private string _bookingCode;

        public string BookingCode
        {
            get { return _bookingCode; }
            set { _bookingCode = value; }
        }
        private string _flightCode;

        public string FlightCode
        {
            get { return _flightCode; }
            set { _flightCode = value; }
        }
        private string _departureDates;

        public string DepartureDates
        {
            get { return _departureDates; }
            set { _departureDates = value; }
        }
        private string _classLevel;

        public string ClassLevel
        {
            get { return _classLevel; }
            set { _classLevel = value; }
        }
        private string _priceLevel;

        public string PriceLevel
        {
            get { return _priceLevel; }
            set { _priceLevel = value; }
        }
        
        public FlightDetail(string bookingcode, string flightcode, string departuredates, string classlevel, string pricelevel)
        {
            _bookingCode = bookingcode;
            _flightCode = flightcode;
            _departureDates = departuredates;
            _classLevel = classlevel;
            _priceLevel = pricelevel;
        }
        
        public FlightDetail()
        {
            
        }
    }
}