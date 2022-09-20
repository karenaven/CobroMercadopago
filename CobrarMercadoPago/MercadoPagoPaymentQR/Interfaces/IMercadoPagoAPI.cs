using MercadoPagoPaymentQR.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR.Interfaces
{
    public interface IMercadoPagoAPI
    {
        Task<string> CrearOrdenPOS(Orden orden, string idVendedor, string externalPosId);
        Task<string> CrearOrdenPUT(Orden orden, string idVendedor, string externalPosId);
        Task<string> CrearSucursal(Sucursal sucursal, string idVendedor);
        Task<string> CrearCaja(Caja caja);
        Image TranformarStringToQR(string cadena);
        Task<List<Result>> TraerPagos();
        Task<List<Element>> TraerOrdenes();
    }
}
