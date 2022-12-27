using Enviostisur.Data.Entities;
namespace Enviostisur.IService
{
    public interface ITcdocu_origService
    {
        List<MDTcdocu_orig> GetTcdocuOrigs(string nu_reca);
    }
}
