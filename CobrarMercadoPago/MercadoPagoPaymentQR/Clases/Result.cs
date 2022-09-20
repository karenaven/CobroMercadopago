using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR.Clases
{
    public class Result
    {
        public string id { get; set; }
        public string date_created { get; set; }
        public string date_approved { get; set; }
        public string date_last_updated { get; set; }
        public string money_release_date { get; set; }
        public string payment_method_id { get; set; }
        public string payment_type_id { get; set; }
        public string status { get; set; }
        public string status_detail { get; set; }
        public string currency_id { get; set; }
        public string description { get; set; }
        public int collector_id { get; set; }
        public Payer payer { get; set; }
        public Metadata metadata { get; set; }
        public AdditionalInfo additional_info { get; set; }
        public Order order { get; set; }
        public float transaction_amount { get; set; }
        public float transaction_amount_refunded { get; set; }
        public float coupon_amount { get; set; }
        public TransactionDetails transaction_details { get; set; }
        public int installments { get; set; }
        public Card card { get; set; }


        public class Card
        {
            public string id { get; set; }
            public Cardholder cardholder { get; set; }
            public string last_four_digits { get; set; }

            public class Cardholder
            {
                public string number { get; set; }
                public string type { get; set; }
            }
        }
        public class TransactionDetails
        {
            public float net_received_amount { get; set; }
            public float total_paid_amount { get; set; }
            public float overpaid_amount { get; set; }
            public float installment_amount { get; set; }
        }
        public class AdditionalInfo
        {
            public object authentication_code { get; set; }
            public object nsu_processadora { get; set; }
            public object available_balance { get; set; }
        }
        public class Order
        {
            public string id { get; set; }
            public string type { get; set; }
        }
        public class Metadata { }
        public class Payer
        {
            public int id { get; set; }
            public string email { get; set; }
            public Identification identification { get; set; }
            public string type { get; set; }

            public class Identification
            {
                public string type { get; set; }
                public int number { get; set; }
            }
        }
    }
}
