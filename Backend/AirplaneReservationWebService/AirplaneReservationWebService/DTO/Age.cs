using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneReservationWebService.DTO
{
    public class Age
    {
        private int _ageCode;

        public int AgeCode
        {
            get { return _ageCode; }
            set { _ageCode = value; }
        }
        private string _ageDetail;

        public string AgeDetail
        {
            get { return _ageDetail; }
            set { _ageDetail = value; }
        }

        public Age(int agecode, string agedetail)
        {
            _ageCode = agecode;
            _ageDetail = agedetail;
        }
        public Age()
        {
            
        }
    }
}