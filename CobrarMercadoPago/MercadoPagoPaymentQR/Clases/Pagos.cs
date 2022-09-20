using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR.Clases
{
    public class Pagos
    {
        public List<Result> results { get; set; }
        public Paging paging { get; set; }

        public class Paging
        {
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
        }
    }
}
