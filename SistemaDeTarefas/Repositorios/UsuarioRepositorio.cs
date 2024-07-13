using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeTarefasDBContexts _dbcontex;

        public UsuarioRepositorio (SistemaDeTarefasDBContexts sistemaTarefasContex)
        {
            _dbcontex = sistemaTarefasContex;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbcontex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbcontex.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dbcontex.Usuarios.AddAsync(usuario);
            _dbcontex.SaveChangesAsync();

            return usuario;

        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o id:  { id}  nao encontrado");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.email = usuario.email;
            _dbcontex.AddAsync(usuarioPorId);
            _dbcontex.SaveChanges();
            return usuario;

        }

        public async Task<UsuarioModel> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o id:  {id}  nao encontrado");
            }
            _dbcontex.Usuarios.Remove(usuarioPorId);
            _dbcontex.SaveChanges();
            return usuarioPorId;
        }

       

      
    }
}
