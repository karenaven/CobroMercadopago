using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR.Clases
{
    public class Orden
    {
        public string external_reference { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string notification_url { get; set; }

        //formato fecha "2023-08-22T16:34:56.559-04:00"
        public string expiration_date { get; set; }
        public int total_amount { get; set; }
        public List<Item> items { get; set; }

        public class Item
        {
            public string sku_number { get; set; }
            public string category { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public int unit_price { get; set; }
            public int quantity { get; set; }
            public string unit_measure { get; set; }
            public int total_amount { get; set; }
        }
    }
}
