using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneReservationWebService.DTO
{
    public class Passenger
    {
        private string _bookingCode;

        public string BookingCode
        {
            get { return _bookingCode; }
            set { _bookingCode = value; }
        }
        private string _epithets;

        public string Epithets
        {
            get { return _epithets; }
            set { _epithets = value; }
        }
        private string _firstname;

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        private int _ageCode;

        public int AgeCode
        {
            get { return _ageCode; }
            set { _ageCode = value; }
        }
        
        public Passenger(string bookingcode, string epithets, string firstname, string lastname, int agecode)
        {
            _bookingCode = bookingcode;
            _epithets = epithets;
            _firstname = firstname;
            _lastname = lastname;
            _ageCode = agecode;
        }
        public Passenger()
        {
            
        }
    }
}