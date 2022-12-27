using Enviostisur.Data.Entities;

namespace Enviostisur.IService
{
    public interface ITddocu_origService
    {
        List<MDTddocu_orig> GetTddocuOrigs(int iddocu_orig);
    }
}
