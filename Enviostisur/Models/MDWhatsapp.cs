namespace Enviostisur.Models
{
    public class MDWhatsapp
    {
        public class Peticion
        {
            public string app { get; set; }

            public string sender { get; set; }

            public string message { get; set; }

            public string phone { get; set; }

        }

        public class message
        {
            public string reply { get; set; }
        }
    }
}
