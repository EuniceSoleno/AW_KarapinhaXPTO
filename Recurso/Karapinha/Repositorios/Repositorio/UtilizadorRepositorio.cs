using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Repositorios.Repositorio
{
    public class UtilizadorRepositorio : IUtilizadorRepositorio
    {
        private readonly KarapinhaDBContext _dbcontext;

        public UtilizadorRepositorio(KarapinhaDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Utilizador> BuscarPorId(int id)
        {
            return await _dbcontext.Utilizadores.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Utilizador>> BuscarTodosUtilizadores()
        {
            return await _dbcontext.Utilizadores.ToListAsync();
        }

        public async Task<Utilizador> Adicionar(Utilizador utilizador)
        {
            if (utilizador == null)
            {
                throw new ArgumentNullException(nameof(utilizador), "O utilizador não pode ser nulo.");
            }

            await _dbcontext.Utilizadores.AddAsync(utilizador);
            await _dbcontext.SaveChangesAsync();
            return utilizador;
        }

        public async Task<Utilizador> Atualizar(Utilizador utilizador, int id)
        {
            if (utilizador == null)
            {
                throw new ArgumentNullException(nameof(utilizador), "O utilizador não pode ser nulo.");
            }

            var utilizadorPorId = await BuscarPorId(id);
            if (utilizadorPorId == null)
            {
                throw new KeyNotFoundException($"Utilizador com id {id} não encontrado.");
            }

            utilizadorPorId.password = utilizador.password;
            utilizadorPorId.bi = utilizador.bi;
            utilizadorPorId.telemovel = utilizador.telemovel;
            utilizadorPorId.username = utilizador.username;
            utilizadorPorId.nomeCompleto = utilizador.nomeCompleto;
            utilizadorPorId.endereco = utilizador.endereco;

            _dbcontext.Update(utilizadorPorId);
            await _dbcontext.SaveChangesAsync();
            return utilizadorPorId;
        }

        public async Task<Utilizador> Apagar(int id)
        {
            var utilizadorPorId = await BuscarPorId(id);
            if (utilizadorPorId == null)
            {
                throw new KeyNotFoundException($"Utilizador com id {id} não encontrado.");
            }

            _dbcontext.Remove(utilizadorPorId);
            await _dbcontext.SaveChangesAsync();
            return utilizadorPorId;
        }
    }
}
