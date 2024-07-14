using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Repositorios.Repositorio
{
    public class ServicoRepositorio : IServicoRepositorio
    {
        private readonly KarapinhaDBContext _dbcontex;
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public ServicoRepositorio(KarapinhaDBContext dbContext, CategoriaRepositorio categoriaRepositorio)
        {
            _dbcontex = dbContext;
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Servico> BuscarPorId(int id)
        {
            return await _dbcontex.Servicos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Servico> BuscarPorNome(string nome)
        {
            return await _dbcontex.Servicos.FirstOrDefaultAsync(x => x.ServicoNome.Equals(nome));
        }

        public async Task<List<Servico>> BuscarTodosServicos()
        {
            return await _dbcontex.Servicos.ToListAsync();
        }

        public async Task<Servico> Adicionar(Servico servico)
        {
            // Verificar se categoria existe
            var cat = await _categoriaRepositorio.BuscarPorId(servico.CategoriaId);
            if (cat == null)
            {
                throw new KeyNotFoundException($"Impossível registrar o serviço, categoria inexistente.");
            }

            await _dbcontex.Servicos.AddAsync(servico);
            await _dbcontex.SaveChangesAsync();
            return servico;
        }

        public async Task<Servico> Apagar(int id)
        {
            var servicoPorId = await BuscarPorId(id);
            if (servicoPorId == null)
            {
                throw new KeyNotFoundException($"Serviço {id} não encontrado.");
            }

            _dbcontex.Remove(servicoPorId);
            await _dbcontex.SaveChangesAsync();
            return servicoPorId;
        }

        public async Task<Servico> Atualizar(Servico servico, int id)
        {
            var servicoPorId = await BuscarPorId(id);
            if (servicoPorId == null)
            {
                throw new KeyNotFoundException($"Serviço {id} não encontrado.");
            }

            servicoPorId.ServicoNome = servico.ServicoNome;
            servicoPorId.Preco = servico.Preco;
            servicoPorId.CategoriaId = servico.CategoriaId;

            _dbcontex.Update(servicoPorId);
            await _dbcontex.SaveChangesAsync();
            return servicoPorId;
        }
    }
}
