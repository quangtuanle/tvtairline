using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneReservationWebService.DTO
{
    public class AirPort
    {
        private string _airPortCode;

        public string AirPortCode
        {
            get { return _airPortCode; }
            set { _airPortCode = value; }
        }
        private string _airPortName;

        public string AirPortName
        {
            get { return _airPortName; }
            set { _airPortName = value; }
        }
        private string _area;

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public AirPort(string airportcode, string airportname, string area)
        {
            _airPortCode = airportcode;
            _airPortName = airportname;
            _area = area;
        }
        public AirPort()
        {

        }

    }
}