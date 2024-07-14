using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Repositorios.Repositorio
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly KarapinhaDBContext _dbcontex;

        public ProfissionalRepositorio(KarapinhaDBContext dBContext)
        {
            _dbcontex = dBContext;
        }


        public async Task<Profissional> BuscarPorId(int id)
        {
            return await _dbcontex.Profissionais.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Profissional>> BuscarTodosProfissionais()
        {
            return await _dbcontex.Profissionais.ToListAsync();
        }
        public async Task<Profissional> Adicionar(Profissional profissional)
        {
            await _dbcontex.Profissionais.AddAsync(profissional);
            _dbcontex.SaveChangesAsync();
            return profissional;
        }

        public async Task<Profissional> Apagar(int id)
        {
            Profissional profissionalPorId = await BuscarPorId(id);
            if (profissionalPorId == null)
            {
                throw new Exception($"Profissional {id} nao encontrado");
            }
            _dbcontex.Remove(profissionalPorId);
            _dbcontex.SaveChanges();
            return profissionalPorId;
        }

        public async Task<Profissional> Atualizar(Profissional profissional, int id)
        {
            Profissional profissionalPorId = await BuscarPorId(id);
            if (profissionalPorId == null)
            {
                throw new Exception($"Profissional {id} nao encontrado");
            }
            profissionalPorId.ProfissionalNome = profissional.ProfissionalNome;
            profissionalPorId.password = profissional.password;
            profissionalPorId.bi = profissional.bi;
            profissionalPorId.telemovel = profissional.telemovel;
            profissionalPorId.photo = profissional.photo;
            profissionalPorId.CategoriaId = profissional.CategoriaId;
            profissionalPorId.endereco = profissional.endereco;

            _dbcontex.Update(profissionalPorId);
            _dbcontex.SaveChanges();

            return profissionalPorId;


        }

    }
}
