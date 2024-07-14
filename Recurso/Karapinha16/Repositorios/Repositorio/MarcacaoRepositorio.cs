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
        private readonly ProfissionalRepositorio _profissionalRepositorio;
        private readonly TabelaDeHorarioRepositorio _tabelaDeHorarioRepositorio;

        public MarcacaoRepositorio(KarapinhaDBContext dbContext, ProfissionalRepositorio profissionalRepositorio, TabelaDeHorarioRepositorio tabelaDeHorarioRepositorio)
        {
            _dbContext = dbContext;
            _profissionalRepositorio = profissionalRepositorio;
            _tabelaDeHorarioRepositorio = tabelaDeHorarioRepositorio;
        }

        public async Task<Marcacao> BuscarPorId(int id)
        {
            return await _dbContext.Marcacoes
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Marcacao>> BuscarTodasMarcacoes()
        {
            return await _dbContext.Marcacoes
                .ToListAsync();
        }

        public async Task<Marcacao> Adicionar(Marcacao marcacao)
        {
            // Adiciona as associações
            var profissional = await _profissionalRepositorio.BuscarPorNome(marcacao.NomeProfissional);
            var tabela = await _tabelaDeHorarioRepositorio.BuscarPorNomeProfissional(marcacao.NomeProfissional);

            if (profissional == null)
            {
                throw new ArgumentException("Profissional Solicitado Inexistente");
            }

            if (tabela == null)
            {
                throw new ArgumentException("Profissional Solicitado Está Indisponível");
            }

            // Validar se o horário da marcação está dentro do intervalo disponível
            bool horarioValido = await _tabelaDeHorarioRepositorio.IsHorarioDentroDoIntervalo(tabela, marcacao.Hora, marcacao.Hora);
            if (!horarioValido)
            {
                throw new ArgumentException("O horário da marcação está fora do intervalo permitido para este profissional.");
            }

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

            _dbContext.Update(marcacaoPorId);
            await _dbContext.SaveChangesAsync();
            return marcacaoPorId;
        }
    }
}
