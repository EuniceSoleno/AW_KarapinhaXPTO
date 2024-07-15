using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Repositorios.Repositorio
{
    public class TabelaDeHorarioRepositorio : ITabelaDeHorarioRepositorio
    {
        private readonly KarapinhaDBContext _dbContext;

        public TabelaDeHorarioRepositorio(KarapinhaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TabelaDeHorario> BuscarPorId(int id)
        {
            return await _dbContext.TabelasDeHorarios
                .Include(t => t.Marcacoes)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TabelaDeHorario>> BuscarTodos()
        {
            return await _dbContext.TabelasDeHorarios
                .Include(t => t.Marcacoes)
                .ToListAsync();
        }

        public async Task<TabelaDeHorario> Adicionar(TabelaDeHorario tabelaDeHorario)
        {
            _dbContext.TabelasDeHorarios.Add(tabelaDeHorario);
            await _dbContext.SaveChangesAsync();
            return tabelaDeHorario;
        }

        public async Task<TabelaDeHorario> Atualizar(TabelaDeHorario tabelaDeHorario, int id)
        {
            var tabelaExistente = await BuscarPorId(id);
            if (tabelaExistente == null)
            {
                throw new KeyNotFoundException($"Tabela de Horário com ID {id} não encontrada");
            }

            tabelaExistente.Data = tabelaDeHorario.Data;
            tabelaExistente.HoraInicio = tabelaDeHorario.HoraInicio;
            tabelaExistente.HoraFim = tabelaDeHorario.HoraFim;

            _dbContext.TabelasDeHorarios.Update(tabelaExistente);
            await _dbContext.SaveChangesAsync();
            return tabelaExistente;
        }

        public async Task<TabelaDeHorario> Apagar(int id)
        {
            var tabelaDeHorario = await BuscarPorId(id);
            if (tabelaDeHorario == null)
            {
                throw new KeyNotFoundException($"Tabela de Horário com ID {id} não encontrada");
            }

            _dbContext.TabelasDeHorarios.Remove(tabelaDeHorario);
            await _dbContext.SaveChangesAsync();
            return tabelaDeHorario;
        }
    }
}
