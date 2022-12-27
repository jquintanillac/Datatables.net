using Enviostisur.Data.Datasql;
using Enviostisur.Data.Entities;
using Enviostisur.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Globalization;
//using MailKit.Net.Smtp;
//using MailKit;
//using MimeKit;
using static Enviostisur.Models.MDWhatsapp;
using Rotativa.AspNetCore;

namespace Enviostisur.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        SPOperaciones _operaciones;        
        public HomeController(IConfiguration configuration, ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger; 
            _operaciones = new SPOperaciones();
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public async Task<IActionResult> Graneles()
        {
            MDSmtpSettings smtpSettings = new MDSmtpSettings();
            {
                smtpSettings.Server = _configuration.GetValue<string>("SmtpSettings:Server");
                smtpSettings.Port = Int32.Parse(_configuration.GetValue<string>("SmtpSettings:Port"));
                smtpSettings.SenderName = _configuration.GetValue<string>("SmtpSettings:SenderName");
                smtpSettings.SenderEmail = _configuration.GetValue<string>("SmtpSettings:SenderEmail");
                smtpSettings.UserName = _configuration.GetValue<string>("SmtpSettings:UserName");
                smtpSettings.Password = _configuration.GetValue<string>("SmtpSettings:Password"); 
            };

            //var granales = await _operaciones.spMailgraneles();
            //string stCuerpohtml = "<!DOCTYPE html>";
            //stCuerpohtml += "<html lang='en'>";
            //stCuerpohtml += "<head>";
            //stCuerpohtml += "<meta charset='UTF - 8'>";
            //stCuerpohtml += "<title>DIAS DE ALMACENAJE GRANELES</title>";
            //stCuerpohtml += "</head>";
            //stCuerpohtml += "<body>";
            //stCuerpohtml += "<table  class='table table-striped table - bordered'>";
            //stCuerpohtml += "<thead>";
            //stCuerpohtml += "<tr>";
            //stCuerpohtml += "<th>" + "RECALADA" + "</th>";
            //stCuerpohtml += "<th>" + "DOCUMENTO ORIGEN" + "</th>";
            //stCuerpohtml += "<th>" + "ITEM" + "</th>";
            //stCuerpohtml += "<th>" + "CLIENTE" + "</th>";
            //stCuerpohtml += "<th>" + "CARGA" + "</th>";
            //stCuerpohtml += "<th>" + "ALMACEN" + "</th>";
            //stCuerpohtml += "<th>" + "FECHA TARJA" + "</th>";
            //stCuerpohtml += "<th>" + "DIAS" + "</th>";
            //stCuerpohtml += "</tr>";
            //stCuerpohtml += "</thead>";
            //stCuerpohtml += "<tbody>";
            //foreach (var item in granales)
            //{            
            //stCuerpohtml += "<tr>";
            //stCuerpohtml += "<td>" + item.NU_RECA + "</td>";
            //stCuerpohtml += "<td>" + item.NU_DOCU_ORIG + "</td>";
            //stCuerpohtml += "<td>" + item.NU_SECU_ITEM + "</td>";
            //stCuerpohtml += "<td>" + item.DE_CLIE + "</td>";
            //stCuerpohtml += "<td>" + item.DE_CARG + "</td>";
            //stCuerpohtml += "<td>" + item.DE_ALMA + "</td>";
            //stCuerpohtml += "<td>" + item.FE_TARJ + "</td>";
            //stCuerpohtml += "<td>" + item.DIAS + "</td>";
            //stCuerpohtml += "</tr>";
            //}
            //stCuerpohtml += "</tbody>";        
            //stCuerpohtml += "</table>";
            //stCuerpohtml += "</body>";
            //stCuerpohtml += "</html>";

            MailMessage mailMessage = new MailMessage(smtpSettings.SenderEmail, "jquintanillac@tisur.com.pe", "Pruebas email", "Prueba de nuevo servidor");
            //mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient(smtpSettings.Server, smtpSettings.Port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new System.Net.NetworkCredential(8,);
            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
            //MimeMessage mensaje = new MimeMessage();
            //mensaje.From.Add(new MailboxAddress("Enviar", smtpSettings.SenderEmail));
            //mensaje.To.Add(new MailboxAddress("Destinatario 1", "csalinasgu@tisur.com.pe"));
            //mensaje.To.Add(new MailboxAddress("Destinatario 2", "almacend1@tisur.com.pe"));
            //mensaje.To.Add(new MailboxAddress("Destinatario 3", "jquintanillac@tisur.com.pe"));
            //mensaje.Subject = "Alerta Fumigacion Graneles";

            //BodyBuilder Bodymes = new BodyBuilder();
            //Bodymes.HtmlBody = stCuerpohtml;

            //mensaje.Body = Bodymes.ToMessageBody();

            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Connect(smtpSettings.Server, smtpSettings.Port, false);
            //smtpClient.Authenticate(smtpSettings.UserName, smtpSettings.Password);
            //smtpClient.Send(mensaje);
            //smtpClient.Disconnect(true);

            ViewBag.Graneles = await _operaciones.spMailgraneles();
            return View();
        }

        public IActionResult Operaciones()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<message>> bottisura([FromForm] Peticion oPeticion)
        {
            try
            {   

                var app = oPeticion.app;
                var sender = oPeticion.sender;
                var message = oPeticion.message;
                string oIterar = "";

                if (message == null)
                {
                    message = "8757";
                }

                var oResp = await _operaciones.spRequerimiento(message);
                foreach (var item in oResp)
                {
                    oIterar = oIterar + " \n" +
                              "Nro. Requerimiento: " + item.nro_reque + " \n" +
                              "Placa: " + item.placa + " \n" +
                              "Transportista: " + item.trans + " \n" +
                              "Carga: " + item.carga + " \n" +
                              "Programacion: " + item.fec_prog + " \n" +
                              "Llegada: " + item.fec_lleg + " \n" +
                              "Antepuerto: " + item.fec_ante + " \n" +
                              "1er pesaje: " + item.fec_1Bal + " \n" +
                              "Tarja : " + item.fec_tarja + " \n" +
                              "2do pesaje: " + item.fec_2Bal + " \n" +
                              "Salida: " + item.fec_puert + " \n";
                }
                message oResponse = new message
                {
                    reply = oIterar
                };
                return oResponse;              
                
            }
            catch (Exception ex)
            {
                var json = "";
                message oResponse = new message
                {
                    reply = json
                };
                return oResponse;
            }

        }

        [HttpPost]
        public async Task<ActionResult<message>> bottisurb([FromForm] Peticion oPeticion)
        {
            try
            {

                var app = oPeticion.app;
                var sender = oPeticion.sender;
                var message = oPeticion.message;
                string oIterar = "";

                if (message == null)
                {
                    message = "8765";
                }

                var oResp = await _operaciones.spRequerimiento(message);
                foreach (var item in oResp)
                {
                    oIterar = oIterar + " \n" +
                              "Nro. Requerimiento: " + item.nro_reque + " \n" +
                              "Placa: " + item.placa + " \n" +
                              "Transportista: " + item.trans + " \n" +
                              "Carga: " + item.carga + " \n" +
                              "Programacion: " + item.fec_prog + " \n" +
                              "Llegada: " + item.fec_lleg + " \n" +
                              "Antepuerto: " + item.fec_ante + " \n" +
                              "1er pesaje: " + item.fec_1Bal + " \n" +
                              "Tarja : " + item.fec_tarja + " \n" +
                              "2do pesaje: " + item.fec_2Bal + " \n" +
                              "Salida: " + item.fec_puert + " \n";
                }
                message oResponse = new message
                {
                    reply = oIterar
                };
                return oResponse;

            }
            catch (Exception ex)
            {
                var json = "";
                message oResponse = new message
                {
                    reply = json
                };
                return oResponse;
            }

        }

        [HttpPost]
        public async Task<ActionResult<message>> bottisurc([FromForm] Peticion oPeticion)
        {
            try
            {

                var app = oPeticion.app;
                var sender = oPeticion.sender;
                var message = oPeticion.message;
                var phone = oPeticion.phone;
                string oIterar = "";

                if (message == null)
                {
                    message = "8760";
                }

                var oResp = await _operaciones.spRequerimiento(message);
                foreach (var item in oResp)
                {
                    oIterar = oIterar + " \n" +
                              "Nro. Requerimiento: " + item.nro_reque + " \n" +
                              "Placa: " + item.placa + " \n" +
                              "Transportista: " + item.trans + " \n" +
                              "Carga: " + item.carga + " \n" +
                              "Programacion: " + item.fec_prog + " \n" +
                              "Llegada: " + item.fec_lleg + " \n" +
                              "Antepuerto: " + item.fec_ante + " \n" +
                              "1er pesaje: " + item.fec_1Bal + " \n" +
                              "Tarja : " + item.fec_tarja + " \n" +
                              "2do pesaje: " + item.fec_2Bal + " \n" +
                              "Salida: " + item.fec_puert + " \n";
                }
                message oResponse = new message
                {
                    reply = oIterar
                };
                return oResponse;

            }
            catch (Exception ex)
            {
                var json = "";
                message oResponse = new message
                {
                    reply = json
                };
                return oResponse;
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Mapalmacen()
        {
            return View();
        }
        public IActionResult SubirImagen()
        {
            return View();
        }
        public IActionResult Saveimg()
        {
            return View();
        }
        public async Task<IActionResult> ReporteBalanza()
        {           
            return View();
        }

        public async Task<IActionResult> imprimirBalanza(DateTime fecini, DateTime fecfin, string inpreca, int bl, int items)
        {
            DateTime Fecha1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            DateTime Fecha2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue;
            List<MDBalanza> imprimir = new List<MDBalanza>();



            try
            {
                if (fecini == DateTime.MinValue && fecfin == DateTime.MinValue)
                {
                    imprimir = await _operaciones.spBalanza(Fecha1, Fecha2, inpreca, bl, items);

                }
                else
                {
                    imprimir = await _operaciones.spBalanza(fecini, fecfin, inpreca, bl, items);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            //return View(imprimir);
            return new ViewAsPdf("imprimirBalanza", imprimir)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}