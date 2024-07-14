using Karapinha.Model;

namespace Karapinha.Repositorios.Interface
{
    public interface IServicoRepositorio
    {
        Task<List<Servico>> BuscarTodosServicos();
        Task<Servico> BuscarPorId(int id);
        Task<Servico> BuscarPorNome(string nome);

        Task<Servico> Adicionar(Servico servico);
        Task<Servico> Atualizar(Servico servico, int id);
        Task<Servico> Apagar(int id);
    }
}
