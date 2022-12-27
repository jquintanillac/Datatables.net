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

    
        // GET: api/<TmrecasController>
        [HttpGet]
        public List<MDTmreca> GetTmrecas()
        {
            var recaladas = _Tmrecaservice.GetTmrecas();
            return recaladas;
        }

        // GET api/<TmrecasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TmrecasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TmrecasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TmrecasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
