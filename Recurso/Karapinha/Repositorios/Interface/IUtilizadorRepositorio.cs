using Karapinha.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Repositorios.Interface
{
    public interface IUtilizadorRepositorio
    {
        Task<List<Utilizador>> BuscarTodosUtilizadores();
        Task<Utilizador> BuscarPorId(int id);
        Task<Utilizador> Adicionar(Utilizador utilizador);
        Task<Utilizador> Atualizar(Utilizador utilizador, int id);
        Task<bool> Apagar(int id);
    }
}
