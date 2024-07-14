using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TabelaDeHorario> BuscarPorNomeProfissional(string nome)
        {
            return await _dbContext.TabelasDeHorarios
                .FirstOrDefaultAsync(t => t.ProfissionalNome.Equals(nome));
        }

        public async Task<List<TabelaDeHorario>> BuscarTodos()
        {
            return await _dbContext.TabelasDeHorarios
                .ToListAsync();
        }

        public async Task<TabelaDeHorario> Adicionar(TabelaDeHorario tabelaDeHorario)
        {
            var diasValidos = new HashSet<string> { "Segunda", "Terca", "Quarta", "Quinta", "Sexta", "Sabado" };

            if (!diasValidos.Contains(tabelaDeHorario.DiaSemana))
            {
                throw new ArgumentException("Dia de semana inválido");
            }

            if (tabelaDeHorario.HoraInicioHora < 0 || tabelaDeHorario.HoraInicioHora > 23 ||
               tabelaDeHorario.HoraInicioMinuto < 0 || tabelaDeHorario.HoraInicioMinuto > 59 ||
               tabelaDeHorario.HoraFimHora < 0 || tabelaDeHorario.HoraFimHora > 23 ||
               tabelaDeHorario.HoraFimMinuto < 0 || tabelaDeHorario.HoraFimMinuto > 59)
            {
                throw new ArgumentException("Hora de início ou fim inválida");
            }

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

            // Atualizando os horários
            tabelaExistente.HoraInicioHora = tabelaDeHorario.HoraInicioHora;
            tabelaExistente.HoraInicioMinuto = tabelaDeHorario.HoraInicioMinuto;
            tabelaExistente.HoraFimHora = tabelaDeHorario.HoraFimHora;
            tabelaExistente.HoraFimMinuto = tabelaDeHorario.HoraFimMinuto;

            tabelaExistente.DiaSemana = tabelaDeHorario.DiaSemana;

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

        public Task<bool> IsHorarioValido(TabelaDeHorario tabelaDeHorario)
        {
            if (tabelaDeHorario.HoraInicioHora < tabelaDeHorario.HoraFimHora ||
               (tabelaDeHorario.HoraInicioHora == tabelaDeHorario.HoraFimHora &&
                tabelaDeHorario.HoraInicioMinuto < tabelaDeHorario.HoraFimMinuto))
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> IsHorarioDentroDoIntervalo(TabelaDeHorario tabelaDeHorario, int hora, int minuto)
        {
            var horaInicio = tabelaDeHorario.HoraInicioHora * 60 + tabelaDeHorario.HoraInicioMinuto;
            var horaFim = tabelaDeHorario.HoraFimHora * 60 + tabelaDeHorario.HoraFimMinuto;
            var horaAtual = hora * 60 + minuto;

            return Task.FromResult(horaAtual >= horaInicio && horaAtual <= horaFim);
        }
    }
}
