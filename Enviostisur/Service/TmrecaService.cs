using Enviostisur.Data;
using Enviostisur.Data.Datasql;
using Enviostisur.Data.Entities;
using Enviostisur.IService;

namespace Enviostisur.Service
{
    public class TmrecaService : ITmrecaService
    {
        private readonly DataContext _context;
        SPOperaciones _operaciones;
        public TmrecaService(DataContext context)
        {
            _context = context;
            _operaciones = new SPOperaciones();
        }

        public List<MDTmreca> GetTmrecas()
        {
            var recalada = _operaciones.ListRecalada(1);
            return recalada;
        }
    }
}
