using Enviostisur.Data.Datasql;
using Enviostisur.Data;
using Enviostisur.Data.Entities;
using Enviostisur.IService;

namespace Enviostisur.Service
{
    public class TddocuOrigService : ITddocu_origService
    {
        private readonly DataContext _context;
        SPOperaciones _operaciones;
        public TddocuOrigService(DataContext context)
        { 
            _context = context;
            _operaciones = new SPOperaciones();
        }
        public List<MDTddocu_orig> GetTddocuOrigs(int iddocu_orig)
        {
            var tddocuorig = _operaciones.ListItem(iddocu_orig);
            return tddocuorig;
        }
    }
}
