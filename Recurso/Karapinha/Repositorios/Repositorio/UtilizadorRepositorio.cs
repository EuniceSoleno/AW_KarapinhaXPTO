using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Repositorios.Repositorio
{
    public class UtilizadorRepositorio : IUtilizadorRepositorio
    {
        private readonly KarapinhaDBContext _dbContext;

        public UtilizadorRepositorio(KarapinhaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Utilizador>> BuscarTodosUtilizadores()
        {
            return await _dbContext.Utilizadores.ToListAsync();
        }

        public async Task<Utilizador> BuscarPorId(int id)
        {
            return await _dbContext.Utilizadores.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Utilizador> Adicionar(Utilizador utilizador)
        {
            await _dbContext.Utilizadores.AddAsync(utilizador);
            await _dbContext.SaveChangesAsync();
            return utilizador;
        }

        public async Task<Utilizador> Atualizar(Utilizador utilizador, int id)
        {
            var utilizadorExistente = await BuscarPorId(id);
            if (utilizadorExistente == null)
            {
                return null;
            }

            utilizadorExistente.NomeCompleto = utilizador.NomeCompleto;
            utilizadorExistente.Endereco = utilizador.Endereco;
            utilizadorExistente.Telemovel = utilizador.Telemovel;
            utilizadorExistente.Bi = utilizador.Bi;
            utilizadorExistente.Username = utilizador.Username;
            utilizadorExistente.Password = utilizador.Password;
            utilizadorExistente.Photo = utilizador.Photo;
            utilizadorExistente.NivelAcesso = utilizador.NivelAcesso; // Novo campo

            _dbContext.Utilizadores.Update(utilizadorExistente);
            await _dbContext.SaveChangesAsync();
            return utilizadorExistente;
        }

        public async Task<bool> Apagar(int id)
        {
            var utilizador = await BuscarPorId(id);
            if (utilizador == null)
            {
                return false;
            }

            _dbContext.Utilizadores.Remove(utilizador);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
