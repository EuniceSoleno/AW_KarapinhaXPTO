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

        public async Task<Model.Categoria> Adicionar(Model.Categoria categoria)
        {
           await _dbcontex.AddAsync(categoria);
            _dbcontex.SaveChangesAsync();
            return categoria;
        }

        public async Task<Model.Categoria> BuscarPorId(int id)
        {
            return await _dbcontex.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Model.Categoria>> BuscarTodasCategorias()
        {
            return await _dbcontex.Categorias.ToListAsync();

        }

        public async Task<Model.Categoria> Apagar(int id)
        {
            Categoria categoria = await BuscarPorId(id);

            if (categoria == null)
            {
                throw new Exception($"Categoria com {id} nao encontada");
            }
            _dbcontex.Remove(categoria);
            _dbcontex.SaveChanges();
            return categoria;
        }

        public async Task<Model.Categoria> Atualizar(Model.Categoria categoria, int id)
        {
            Categoria categoriaporId = await BuscarPorId(id);

            if (categoriaporId == null)
            {
                throw new Exception($"Categoria com {id} nao encontada");
            }
            categoriaporId.Descricao = categoria.Descricao;
            categoriaporId.CategoriaNome = categoria.CategoriaNome;
            _dbcontex.Update(categoriaporId);
            _dbcontex.SaveChanges();
            return categoriaporId;


        }

    }
}
