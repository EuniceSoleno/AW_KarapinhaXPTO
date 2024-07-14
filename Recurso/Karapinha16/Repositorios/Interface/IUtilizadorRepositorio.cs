using Karapinha.Model;

namespace Karapinha.Repositorios.Interface
{
    public interface IUtilizadorRepositorio
    {
        Task<List<Utilizador>> BuscarTodosUtilizadores();
        Task<Utilizador> BuscarPorId(int id);
        
        Task<Utilizador> BuscarPorNome(string nome);
        Task<Utilizador> Adicionar(Utilizador utilizador);
        Task<Utilizador> Atualizar(Utilizador utilizador, int id);
        Task<Utilizador> Apagar(int id);
    }
}
