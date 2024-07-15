using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Repositorios.Repositorio
{
    public class MarcacaoRepositorio : IMarcacaoRepositorio
    {
        private readonly KarapinhaDBContext _dbContext;

        public MarcacaoRepositorio(KarapinhaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Marcacao> BuscarPorId(int id)
        {
            return await _dbContext.Marcacoes
                .Include(m => m.Categorias)
                .Include(m => m.Servicos)
                .Include(m => m.Profissionais)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Marcacao>> BuscarTodasMarcacoes()
        {
            return await _dbContext.Marcacoes
                .Include(m => m.Categorias)
                .Include(m => m.Servicos)
                .Include(m => m.Profissionais)
                .ToListAsync();
        }

        public async Task<Marcacao> Adicionar(Marcacao marcacao)
        {
            // Adiciona as associações
            _dbContext.Marcacoes.Add(marcacao);
            await _dbContext.SaveChangesAsync();
            return marcacao;
        }

        public async Task<Marcacao> Apagar(int id)
        {
            var marcacaoPorId = await BuscarPorId(id);
            if (marcacaoPorId == null)
            {
                throw new KeyNotFoundException($"Marcação {id} não encontrada");
            }
            _dbContext.Remove(marcacaoPorId);
            await _dbContext.SaveChangesAsync();
            return marcacaoPorId;
        }

        public async Task<Marcacao> Atualizar(Marcacao marcacao, int id)
        {
            var marcacaoPorId = await BuscarPorId(id);
            if (marcacaoPorId == null)
            {
                throw new KeyNotFoundException($"Marcação {id} não encontrada");
            }
            marcacaoPorId.Hora = marcacao.Hora;
            marcacaoPorId.DiaSemana = marcacao.DiaSemana;
            marcacaoPorId.Profissionais = marcacao.Profissionais;
            marcacaoPorId.Categorias = marcacao.Categorias;
            marcacaoPorId.Servicos = marcacao.Servicos;

            _dbContext.Update(marcacaoPorId);
            await _dbContext.SaveChangesAsync();
            return marcacaoPorId;
        }
    }
}
