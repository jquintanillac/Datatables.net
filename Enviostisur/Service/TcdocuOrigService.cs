using Enviostisur.Data.Datasql;
using Enviostisur.Data;
using Enviostisur.Data.Entities;
using Enviostisur.IService;

namespace Enviostisur.Service
{
    public class TcdocuOrigService : ITcdocu_origService
    {
        private readonly DataContext _context;
        SPOperaciones _operaciones;
        public TcdocuOrigService(DataContext context)
        {
            _context = context;
            _operaciones = new SPOperaciones();
        }

        public List<MDTcdocu_orig> GetTcdocuOrigs(string nu_reca)
        {
            var tcdocuorig = _operaciones.ListDocorig(nu_reca);
            return tcdocuorig;
        }
    }
}
