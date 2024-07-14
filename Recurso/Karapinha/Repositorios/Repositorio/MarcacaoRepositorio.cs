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
        private readonly KarapinhaDBContext _dbcontex;

        private readonly ProfissionalRepositorio _profissional;
        private readonly CategoriaRepositorio _categoria;
        private readonly ServicoRepositorio _servico;

        public MarcacaoRepositorio(KarapinhaDBContext dbContext, ProfissionalRepositorio profissionalRepositorio, CategoriaRepositorio categoriaRepositorio, ServicoRepositorio servicoRepositorio)
        {
            _dbcontex = dbContext;
            _profissional = profissionalRepositorio;
            _categoria = categoriaRepositorio;
            _servico = servicoRepositorio;
        }

        public async Task<Marcacao> BuscarPorId(int id)
        {
            return await _dbcontex.Marcacoes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Marcacao>> BuscarTodasMarcacoes()
        {
            return await _dbcontex.Marcacoes.ToListAsync();
        }

        public async Task<Marcacao> Adicionar(Marcacao marcacao)
        {
            var categoriaEncontrada = await _categoria.BuscarPorNome(marcacao.CategoriaNome);
            if (categoriaEncontrada == null)
            {
                throw new ArgumentException("Categoria solicitada não encontrada");
            }
            var profissionalEncontrado = await _profissional.BuscarPorNome(marcacao.ProfissionalNome);
            if (profissionalEncontrado == null)
            {
                throw new ArgumentException("Profissional solicitado não encontrado");
            }
            var servicoEncontrado = await _servico.BuscarPorNome(marcacao.ServicoNome);
            if (servicoEncontrado == null)
            {
                throw new ArgumentException("Serviço solicitado não encontrado");
            }

            await _dbcontex.AddAsync(marcacao);
            await _dbcontex.SaveChangesAsync();
            return marcacao;
        }

        public async Task<Marcacao> Apagar(int id)
        {
            var marcacaoPorId = await BuscarPorId(id);
            if (marcacaoPorId == null)
            {
                throw new KeyNotFoundException($"Marcação {id} não encontrada");
            }
            _dbcontex.Remove(marcacaoPorId);
            await _dbcontex.SaveChangesAsync();
            return marcacaoPorId;
        }

        public async Task<Marcacao> Atualizar(Marcacao marcacao, int id)
        {
            var marcacaoPorId = await BuscarPorId(id);
            if (marcacaoPorId == null)
            {
                throw new KeyNotFoundException($"Marcação {id} não encontrada");
            }
            marcacaoPorId.hora = marcacao.hora;
            marcacaoPorId.DiaSemana = marcacao.DiaSemana;
            marcacaoPorId.ProfissionalNome = marcacao.ProfissionalNome;
            marcacaoPorId.CategoriaNome = marcacao.CategoriaNome;
            marcacaoPorId.ServicoNome = marcacao.ServicoNome;

            _dbcontex.Update(marcacaoPorId);
            await _dbcontex.SaveChangesAsync();
            return marcacaoPorId;
        }
    }
}
