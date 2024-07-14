using Karapinha.Model;

namespace Karapinha.Repositorios.Interface
{
    public interface IMarcacaoRepositorio
    {
        Task<List<Marcacao>> BuscarTodasMarcacoes();
        Task<Marcacao> BuscarPorId(int id);
        Task<Marcacao> Adicionar(Marcacao marcacao);
        Task<Marcacao> Atualizar(Marcacao marcacao, int id);
        Task<Marcacao> Apagar(int id);
    }
}
