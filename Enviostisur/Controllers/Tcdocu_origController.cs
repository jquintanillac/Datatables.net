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

      
    }
}
