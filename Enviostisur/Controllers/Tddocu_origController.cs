using Enviostisur.Data.Entities;
using Enviostisur.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enviostisur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tddocu_origController : ControllerBase
    {

        ITddocu_origService _tddocu_OrigService;

        public Tddocu_origController(ITddocu_origService tddocu_OrigService)
        {
            _tddocu_OrigService = tddocu_OrigService;
        }


        // GET: api/<Tddocu_origController>
        [HttpGet]
        public List<MDTddocu_orig> GetTcdocuOrigs(int ID_DOCU_ORIG)
        {
           var tcdocu = _tddocu_OrigService.GetTddocuOrigs(ID_DOCU_ORIG);
            return tcdocu;
        }

        // GET api/<Tddocu_origController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Tddocu_origController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Tddocu_origController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Tddocu_origController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
