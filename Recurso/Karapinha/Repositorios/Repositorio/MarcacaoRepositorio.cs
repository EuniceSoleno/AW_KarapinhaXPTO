using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Repositorios.Repositorio
{
    public class MarcacaoRepositorio : IMarcacaoRepositorio
    {
        private readonly KarapinhaDBContext _dbcontex;

        public MarcacaoRepositorio(KarapinhaDBContext dBContext)
        {
            _dbcontex = dBContext;
        }

        public async Task<Marcacao> BuscarPorId(int id)
        {
            return await _dbcontex.Marcacoes.FirstOrDefaultAsync();
        }

        public async Task<List<Marcacao>> BuscarTodasMarcacoes()
        {
            return await _dbcontex.Marcacoes.ToListAsync();
        }
        public async Task<Marcacao> Adicionar(Marcacao marcacao)
        {
             await _dbcontex.AddAsync(marcacao);
             _dbcontex.SaveChangesAsync();
            return marcacao;
        }

        public async Task<Marcacao> Apagar(int id)
        {
            Marcacao marcacaoPorId = await BuscarPorId(id);
            if (marcacaoPorId == null)
            {
                throw new Exception($"Marcacao {id} nao encontrada");
            }
            _dbcontex.Remove(marcacaoPorId);            
            _dbcontex.SaveChanges();
            return marcacaoPorId;

        }

        public async Task<Marcacao> Atualizar(Marcacao marcacao, int id)
        {
            Marcacao marcacaoPorId = await BuscarPorId(id);
            if (marcacaoPorId == null)
            {
                throw new Exception($"Marcacao {id} nao encontrada");
            }
            marcacaoPorId.hora = marcacao.hora;
            marcacaoPorId.DiaSemana = marcacao.DiaSemana;
            marcacaoPorId.ProfissionalNome = marcacao.ProfissionalNome;
            marcacaoPorId.CategoriaNome = marcacao.CategoriaNome;
            _dbcontex.Update(marcacaoPorId);
            _dbcontex.SaveChanges();
            return marcacaoPorId;
        }

        
    }
}
