using Enviostisur.Data.Entities;
using Enviostisur.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enviostisur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tcdocu_origController : ControllerBase
    {

        ITcdocu_origService _tcdocu_OrigService;
        public Tcdocu_origController(ITcdocu_origService tcdocu_OrigService)
        {
            _tcdocu_OrigService = tcdocu_OrigService;
        }


        // GET: api/<Tcdocu_origController>
        [HttpGet]
        public List<MDTcdocu_orig> GetTcdocuOrigs(string nu_reca)
        {
            var tcdocu = _tcdocu_OrigService.GetTcdocuOrigs(nu_reca);
            return tcdocu;
        }

        // GET api/<Tcdocu_origController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Tcdocu_origController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Tcdocu_origController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Tcdocu_origController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
