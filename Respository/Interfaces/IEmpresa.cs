using SCE_DB_NET.Models;

namespace SCE_DB_NET.Respository.Interfaces
{
    public interface IEmpresa
    {
        IEnumerable<Empresa> listar();
    }
}
