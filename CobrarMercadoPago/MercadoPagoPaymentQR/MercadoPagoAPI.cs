using MercadoPagoPaymentQR.Clases;
using MercadoPagoPaymentQR.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPagoPaymentQR
{
    public class MercadoPagoAPI : IMercadoPagoAPI
    {
        private readonly HttpClient client;
        private readonly string accessToken;

        public MercadoPagoAPI(HttpClient client, string accessToken)
        {
            this.client = client;
            this.accessToken = accessToken;
        }

        public async Task<string> CrearSucursal(Sucursal sucursal, string idVendedor)
        {
            string url = $"https://api.mercadopago.com/users/{idVendedor}/stores";
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string json = JsonConvert.SerializeObject(sucursal, Formatting.Indented);

            HttpResponseMessage response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "Transaccion Fallida :\n" + response.Content.ReadAsStringAsync().Result;
            }
        }

        public async Task<string> CrearCaja(Caja caja)
        {
            string url = $"https://api.mercadopago.com/pos";
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string json = JsonConvert.SerializeObject(caja, Formatting.Indented);

            HttpResponseMessage response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "Transaccion Fallida :\n" + response.Content.ReadAsStringAsync().Result;
            }
        }

        public async Task<string> CrearOrdenPOS(Orden orden, string idVendedor, string externalPosId)
        {
            string url = $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{idVendedor}/pos/{externalPosId}/qrs";
            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            
            string json = JsonConvert.SerializeObject(orden, Formatting.Indented);
            
            var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                QR qr = JsonConvert.DeserializeObject<QR>(response.Content.ReadAsStringAsync().Result);
                return qr.qr_data;
            }
            else
            {
                return "Transaccion Fallida :\n" + response.Content.ReadAsStringAsync().Result;
            }
        }

        public async Task<string> CrearOrdenPUT(Orden orden, string idVendedor,string externalPosId)
        {
            string url = $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{idVendedor}/pos/{externalPosId}/qrs";
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string json = JsonConvert.SerializeObject(orden,Formatting.Indented);

            var response = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "Transaccion Fallida :\n" + response.Content.ReadAsStringAsync().Result;
            }
        }
        public Image TranformarStringToQR(string cadena)
        {
            QRCoder.QRCodeGenerator QR = new QRCoder.QRCodeGenerator();
            ASCIIEncoding ASSCII = new ASCIIEncoding();
            var z = QR.CreateQrCode(ASSCII.GetBytes(cadena), QRCoder.QRCodeGenerator.ECCLevel.H);
            QRCoder.PngByteQRCode png = new QRCoder.PngByteQRCode();
            png.SetQRCodeData(z);
            var arr = png.GetGraphic(10);
            MemoryStream ms = new MemoryStream();
            ms.Write(arr, 0, arr.Length);
            Bitmap qr = new Bitmap(ms);

            return qr;
        }

        public async Task<List<Result>> TraerPagos()
        {
            string url = $"https://api.mercadopago.com/v1/payments/search";
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Pagos payments = JsonConvert.DeserializeObject<Pagos>(response.Content.ReadAsStringAsync().Result);
                return payments.results;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Element>> TraerOrdenes()
        {
            string url = $"https://api.mercadopago.com/merchant_orders/search";
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<Element> elements = JsonConvert.DeserializeObject<Merchant_Orden>(response.Content.ReadAsStringAsync().Result).elements;
                return elements;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Element>> TraerOrdenes(string ordenReference)
        {
            string url = $"https://api.mercadopago.com/merchant_orders/search?external_reference={ordenReference}";
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<Element> elements = JsonConvert.DeserializeObject<Merchant_Orden>(response.Content.ReadAsStringAsync().Result).elements;
                return elements;
            }
            else
            {
                return null;
            }
        }
    }
}
