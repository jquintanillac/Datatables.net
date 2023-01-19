using Enviostisur.Data.Entities;
using Enviostisur.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enviostisur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TmrecasController : ControllerBase
    {
        ITmrecaService _Tmrecaservice;

        public TmrecasController(ITmrecaService tmrecaservice)
        {
            _Tmrecaservice = tmrecaservice;
        }


        [HttpGet]
        public List<MDTmreca> GetTmrecas()
        {
            var recaladas = _Tmrecaservice.GetTmrecas();
            return recaladas;
        }    
       

     
    }
}
