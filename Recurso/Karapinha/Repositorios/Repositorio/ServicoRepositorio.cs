using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Repositorios.Repositorio
{
    public class ServicoRepositorio : IServicoRepositorio
    {

        private readonly KarapinhaDBContext _dbcontex;
       
        public ServicoRepositorio(KarapinhaDBContext dBContext)
        {
            _dbcontex = dBContext;

        }

        public async Task<Servico> BuscarPorId(int id)
        {
            return await _dbcontex.Servicos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Servico>> BuscarTodosServicos()
        {
            return await _dbcontex.Servicos.ToListAsync();
        }
        public async Task<Servico> Adicionar(Servico servico)
        {
            await _dbcontex.Servicos.AddAsync(servico);
            _dbcontex.SaveChanges();

            return servico;
        }

        public async Task<Servico> Apagar(int id)
        {
            Servico servicoPorId = await BuscarPorId(id);
            if (servicoPorId == null)
            {
                throw new Exception($"Servico {id} not found.");
            }
            _dbcontex.Remove(servicoPorId);
            _dbcontex.SaveChanges(true);

            return servicoPorId;
        }

        public async Task<Servico> Atualizar(Servico servico, int id)
        {
            Servico servicoPorId = await BuscarPorId(id);
            if (servicoPorId == null)
            {
                throw new Exception($"Servico {id} not found.");
            }
            servicoPorId.ServicoNome = servico.ServicoNome;
            servicoPorId.Preco = servico.Preco;
            servicoPorId.CategoriaId = servico.CategoriaId;
            
            _dbcontex.Update(servicoPorId);
            _dbcontex.SaveChanges();
            return servicoPorId;
        }

    }
}
