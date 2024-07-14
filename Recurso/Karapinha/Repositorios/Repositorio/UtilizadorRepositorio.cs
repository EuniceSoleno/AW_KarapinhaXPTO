using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Repositorios.Repositorio
{
    public class UtilizadorRepositorio : IUtilizadorRepositorio
    {
        private readonly KarapinhaDBContext _dbcontext;
        public UtilizadorRepositorio (KarapinhaDBContext dbcontext)
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
            await _dbcontext.Utilizadores.AddAsync( utilizador);
            _dbcontext.SaveChangesAsync();
            return utilizador;
        }

        public async Task<Utilizador> Atualizar(Utilizador utilizador, int id)
        {
           Utilizador utilizadorPorId = await BuscarPorId (id);

            if(utilizadorPorId == null)
            {
                throw new Exception($"Utilizador para o id: {id} nao encontado");
            }
            utilizadorPorId.password = utilizador.password;
            utilizadorPorId.bi = utilizador.bi;
            utilizadorPorId.telemovel = utilizador.telemovel;
            utilizadorPorId.username = utilizador.username;
            utilizadorPorId.nomeCompleto = utilizador.nomeCompleto;
            utilizadorPorId.endereco = utilizador.endereco;
            _dbcontext.Update( utilizadorPorId );
            _dbcontext.SaveChanges();
            return utilizador;
        }

        public async Task<Utilizador> Apagar(int id)
        {
            Utilizador utilizadorPorId = await BuscarPorId(id);

            if (utilizadorPorId == null)
            {
                throw new Exception($"Utilizador para o id: {id} nao encontado");
            }
            _dbcontext.Remove( utilizadorPorId );
            _dbcontext.SaveChanges( true );
            return utilizadorPorId;

        }

       


    }
}
