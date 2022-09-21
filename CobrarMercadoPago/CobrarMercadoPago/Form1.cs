using MercadoPagoPaymentQR.Clases;

namespace CobrarMercadoPago
{
    public partial class Form1 : Form
    {
        private string orden_reference;
        public Form1()
        {
            InitializeComponent();
        }
        
        #region TECLADO
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text+= "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text += "0";
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxMonto.Text = textBoxMonto.Text.Substring(0, textBoxMonto.Text.Length - 1);
            }
            catch (Exception) { }
        }

        private void buttonBorrarTodo_Click(object sender, EventArgs e)
        {
            textBoxMonto.Text = "";
        }



        #endregion

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible=false;
            panelTeclado.Visible = false;
            panel2EscaneaQr.Visible = true;
            iniciarMercadoPago();

        }

        private async void iniciarMercadoPago()
        {
            HttpClient client = new HttpClient();
            string accessesToken = "APP_USR-7156108107310509-090909-5435f39621de9ec69896d4beeb6b6041-1195179584";
            string idVendedor = "1195179584";
            MercadoPagoPaymentQR.MercadoPagoAPI mercadopago = new MercadoPagoPaymentQR.MercadoPagoAPI(client, accessesToken);
            Orden.Item Item = new Orden.Item();
            Item.sku_number = "COOLPAY2022";
            Item.category = "TU PAGO EN COOLPAY";
            Item.title = "TU PAGO EN COOLPAY";
            Item.description = "";
            Item.unit_price = Convert.ToInt32(textBoxMonto.Text);
            Item.quantity = 1;
            Item.unit_measure = "unit";
            Item.total_amount = Convert.ToInt32(textBoxMonto.Text);

            List<Orden.Item> items = new List<Orden.Item>();
            items.Add(Item);

            Orden orden = new Orden();
            orden.external_reference = generarExternalID();
            orden_reference = orden.external_reference;
            orden.title = "TU PAGO EN COOLPAY";
            orden.description = "";
            orden.notification_url = "https://www.yourserver.com/notifications";
            orden.expiration_date = DateTime.Now.AddDays(30).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffzzz");
            orden.total_amount = Convert.ToInt32(textBoxMonto.Text);
            orden.items = items;


            string qr = await mercadopago.CrearOrdenPOS(orden, idVendedor, "SUC002POST003");
            Console.WriteLine("////////////////////////////////");
            Console.WriteLine(qr);
            pictureBoxQR.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxQR.Image = mercadopago.TranformarStringToQR(qr);
        }

        private string generarExternalID()
        {
            string externalId = "Order-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return externalId;
        }

    }
}