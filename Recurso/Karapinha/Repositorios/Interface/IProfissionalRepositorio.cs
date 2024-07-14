using Karapinha.Model;

namespace Karapinha.Repositorios.Interface
{
    public interface IProfissionalRepositorio
    {
        Task<List<Profissional>> BuscarTodosProfissionais();
        Task<Profissional> BuscarPorId(int id);
        Task<Profissional>BuscarPorNome(string nome);
        Task<Profissional> Adicionar(Profissional profissional);
        Task<Profissional> Atualizar(Profissional profissional, int id);
        Task<Profissional> Apagar(int id);
    }
}
