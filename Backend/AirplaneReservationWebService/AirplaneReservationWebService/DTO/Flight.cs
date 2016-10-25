using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneReservationWebService.DTO
{
    public class Flight
    {
        private string _flightCode;
        private string _origin;      
        private string _destination;       
        private string _departureDates;      
        private string _departureTimes;
        private string _classLevel;       
        private string _priceLevel;       
        private int _seatNumber;    
        private double _price;

        public Flight()
        {
            
        }
         public Flight(string flightcode, string origin, string destination, string departuredates, 
             string departuretimes, string classlevel, string pricelevel, int seatnumber, double price)
        {
            _flightCode = flightcode;
            _origin = origin;
            _destination = destination;
            _departureDates = departuredates;
            _departureTimes = departuretimes;
            _classLevel = classlevel;
            _priceLevel = pricelevel;
            _seatNumber = seatnumber;
            _price = price;
        }
        public string FlightCode
        {
            get { return _flightCode; }
            set { _flightCode = value; }
        }
          public string Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
         public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
          public string DepartureDates
        {
            get { return _departureDates; }
            set { _departureDates = value; }
        }
        public string DepartureTimes
        {
            get { return _departureTimes; }
            set { _departureTimes = value; }
        }
         public string ClassLevel
        {
            get { return _classLevel; }
            set { _classLevel = value; }
        }
        public string PriceLevel
        {
            get { return _priceLevel; }
            set { _priceLevel = value; }
        }

        public int SeatNumber
        {
            get { return _seatNumber; }
            set { _seatNumber = value; }
        }
         public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}