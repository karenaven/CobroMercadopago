using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR.Clases
{
    public class Sucursal
    {
        public string name { get; set; }
        public BusinessHours business_hours { get; set; }
        public Location location { get; set; }
        public string external_id { get; set; }

        public class BusinessHours
        {
            public List<Monday> monday { get; set; }
            public List<Tuesday> tuesday { get; set; }
            public List<Wednesday> wednesday { get; set; }
            public List<Thursday> thursday { get; set; }
            public List<Friday> friday { get; set; }
            public List<Saturday> saturday { get; set; }
            public List<Sunday> sunday { get; set; }

            public class Monday
            {
                public string open { get; set; }
                public string close { get; set; }
            }

            public class Tuesday
            {
                public string open { get; set; }
                public string close { get; set; }
            }
            public class Wednesday
            {
                public string open { get; set; }
                public string close { get; set; }
            }
            public class Thursday
            {
                public string open { get; set; }
                public string close { get; set; }
            }
            public class Friday
            {
                public string open { get; set; }
                public string close { get; set; }
            }
            public class Saturday
            {
                public string open { get; set; }
                public string close { get; set; }
            }
            public class Sunday
            {
                public string open { get; set; }
                public string close { get; set; }
            }
        }

        public class Location
        {
            public string street_number { get; set; }
            public string street_name { get; set; }
            public string city_name { get; set; }
            public string state_name { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string reference { get; set; }
        }
    }
}
