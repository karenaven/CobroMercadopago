using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR.Clases
{
    public class Element
    {
        public string id { get; set; }
        public string status { get; set; }
        public string external_reference { get; set; }
        public string preference_id { get; set; }
        public List<Payment> payments { get; set; }
        public List<Shipment> shipments { get; set; }
        //public Payouts payouts { get; set; }
        public Collector collector { get; set; }
        public string marketplace { get; set; }
        public string date_created { get; set; }
        public string last_updated { get; set; }
        public float shipping_cost { get; set; }
        public float total_amount { get; set; }
        public string site_id { get; set; }
        public float paid_amount { get; set; }
        public float refunded_amount { get; set; }
        public Payer payer { get; set; }
        public List<Item> items { get; set; }
        public bool cancelled { get; set; }
        public string additional_info { get; set; }
        //public long application_id { get; set; }
        public string order_status { get; set; }

        public class Payment
        {
            public long id { get; set; }
            public float transaction_amount { get; set; }
            public float total_paid_amount { get; set; }
            public float shipping_cost { get; set; }
            public string currency_id { get; set; }
            public string status { get; set; }
            public string status_detail { get; set; }
            public string date_approved { get; set; }
            public string date_created { get; set; }
            public string last_modified { get; set; }
            public float amount_refunded { get; set; }
        }
        public class Item
        {
            public string id { get; set; }
            public string description { get; set; }
            public int quantity { get; set; }
            public string dimensions { get; set; }
            public string category_id { get; set; }
            public string currency_id { get; set; }
            public string picture_url { get; set; }
            public string title { get; set; }
            public int unit_price { get; set; }
        }
        public class City
        {
            public string name { get; set; }
        }
        public class State
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        public class Country
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Shipment
        {
            public long id { get; set; }
            public string shipment_type { get; set; }
            public string shipping_mode { get; set; }
            public string status { get; set; }
            public List<Item> items { get; set; }
            public string date_created { get; set; }
            public string last_modified { get; set; }
            public string date_first_printed { get; set; }
            public int service_id { get; set; }
            public int sender_id { get; set; }
            public int receiver_id { get; set; }
            public ReceiverAddress receiver_address { get; set; }
            public ShippingOption shipping_option { get; set; }

            public class ReceiverAddress
            {
                public long id { get; set; }
                public string address_line { get; set; }
                public City city { get; set; }
                public State state { get; set; }
                public Country country { get; set; }
                public int latitude { get; set; }
                public int longitude { get; set; }
                public string comment { get; set; }
                public string contact { get; set; }
                public long phone { get; set; }
                public int zip_code { get; set; }
                public string street_name { get; set; }
                public int street_number { get; set; }
            }
            public class ShippingOption
            {
                public int id { get; set; }
                public int cost { get; set; }
                public string currency_id { get; set; }
                public int shipping_method_id { get; set; }
                public EstimatedDelivery estimated_delivery { get; set; }
                public string name { get; set; }
                public int list_cost { get; set; }
                public Speed speed { get; set; }

                public class EstimatedDelivery
                {
                    public string date { get; set; }
                }
                public class Speed
                {
                    public int handling { get; set; }
                    public int shipping { get; set; }
                }
            }
        }
        public class Payouts
        {
        }
        public class Collector
        {
            public int id { get; set; }
            public string email { get; set; }
            public string nickname { get; set; }
        }
        public class Payer
        {
            public int id { get; set; }
        }
    }
}
