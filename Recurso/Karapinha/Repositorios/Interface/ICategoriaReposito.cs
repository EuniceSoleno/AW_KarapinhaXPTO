using Karapinha.Model;

namespace Karapinha.Repositorios.Interface
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> BuscarTodasCategorias();
        Task<Categoria> BuscarPorNome(string nome);
        Task<Categoria> BuscarPorId(int id);
        Task<Categoria> Adicionar(Categoria profissional);
        Task<Categoria> Atualizar(Categoria profissional, int id);
        Task<Categoria> Apagar(int id);
    }
}
