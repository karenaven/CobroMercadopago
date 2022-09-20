using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR.Clases
{
    public class Caja
    {
        public string name { get; set; }
        public bool fixed_amount { get; set; }
        public int category { get; set; }
        public string external_store_id { get; set; }
        public string external_id { get; set; }
    }
}
