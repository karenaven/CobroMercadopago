using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR.Clases
{
    public class Merchant_Orden
    {
        public List<Element> elements { get; set; }
        public int next_offset { get; set; }
        public int total { get; set; }

    }
}
