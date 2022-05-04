using Desafio.Dominio.Entidades;
using System.Threading.Tasks;

namespace Desafio.Dominio.Interfaces.RepositoryInterfaces
{
    public interface IVistoriaRepository : IBaseRepository<Senha>
    {
        Task<Senha> ObterPorChave(int id);

    }
}
