using Karapinha.Model;

namespace Karapinha.Repositorios.Interface
{
    public interface ITabelaRepositorio
    {
        //nao sei como fazer isso
        Task<List<TabelaDeHorario>> BuscarTodosUsuarios();
        Task<TabelaDeHorario> BuscarPorId(int id);
        Task<TabelaDeHorario> Adicionar(TabelaDeHorario usuario);
        Task<TabelaDeHorario> Atualizar(TabelaDeHorario usuario, int id);
        Task<TabelaDeHorario> Apagar(int id);

    }
}
