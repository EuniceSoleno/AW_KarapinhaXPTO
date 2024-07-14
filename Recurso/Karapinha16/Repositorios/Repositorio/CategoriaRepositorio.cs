using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Repositorios.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly KarapinhaDBContext _dbcontex;

        public CategoriaRepositorio(KarapinhaDBContext dBContext)
        {
            _dbcontex = dBContext;
        }

        public async Task<Categoria> Adicionar(Categoria categoria)
        {
            await _dbcontex.AddAsync(categoria);
            await _dbcontex.SaveChangesAsync(); // Correção aplicada
            return categoria;
        }

        public async Task<Categoria> BuscarPorId(int id)
        {
            return await _dbcontex.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Categoria> BuscarPorNome(string nome)
        {
            return await _dbcontex.Categorias.FirstOrDefaultAsync(x => x.CategoriaNome.Equals(nome));
        }

        public async Task<List<Categoria>> BuscarTodasCategorias()
        {
            return await _dbcontex.Categorias.ToListAsync();
        }

        public async Task<Categoria> Apagar(int id)
        {
            Categoria categoria = await BuscarPorId(id);

            if (categoria == null)
            {
                throw new Exception($"Categoria com {id} nao encontada");
            }
            _dbcontex.Remove(categoria);
            await _dbcontex.SaveChangesAsync(); // Certifique-se de aguardar SaveChangesAsync
            return categoria;
        }

         public async Task<Categoria> Atualizar(Categoria categoria, int id)
         {
             Categoria categoriaporId = await BuscarPorId(id);

             if (categoriaporId == null)
             {
                 throw new Exception($"Categoria  {id} nao encontada");
             }
             categoriaporId.Descricao = categoria.Descricao;
             categoriaporId.CategoriaNome = categoria.CategoriaNome;
             _dbcontex.Update(categoriaporId);
             await _dbcontex.SaveChangesAsync(); // Certifique-se de aguardar SaveChangesAsync
             return categoriaporId;
         }

    }
}
