﻿using Karapinha.Data;
using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Repositorios.Repositorio
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly KarapinhaDBContext _dbcontex;
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public ProfissionalRepositorio(KarapinhaDBContext dbContext, ICategoriaRepositorio categoriaRepositorio)
        {
            _dbcontex = dbContext;
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Profissional> BuscarPorId(int id)
        {
            return await _dbcontex.Profissionais
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Profissional> BuscarPorNome(string nome)
        {
            return await _dbcontex.Profissionais
                .FirstOrDefaultAsync(x => x.ProfissionalNome.Equals(nome));
        }

        public async Task<List<Profissional>> BuscarTodosProfissionais()
        {
            return await _dbcontex.Profissionais.ToListAsync();
        }

        public async Task<Profissional> Adicionar(Profissional profissional)
        {
            // Verifica se já existe um profissional com o mesmo BI
            if (await _dbcontex.Profissionais.AnyAsync(p => p.bi == profissional.bi))
            {
                throw new ArgumentException("Já existe um profissional com este BI.");
            }

            // Verifica se já existe um profissional com o mesmo telemóvel
            if (await _dbcontex.Profissionais.AnyAsync(p => p.telemovel == profissional.telemovel))
            {
                throw new ArgumentException("Já existe um profissional com este telemóvel.");
            }

            // Verifica se a categoria associada ao profissional existe
            var categoria = await _categoriaRepositorio.BuscarPorId(profissional.CategoriaId);
            if (categoria == null)
            {
                throw new ArgumentException("A categoria associada ao profissional não existe.");
            }

            await _dbcontex.Profissionais.AddAsync(profissional);
            await _dbcontex.SaveChangesAsync();
            return profissional;
        }

        public async Task<Profissional> Apagar(int id)
        {
            var profissionalPorId = await BuscarPorId(id);
            if (profissionalPorId == null)
            {
                throw new KeyNotFoundException($"Profissional {id} não encontrado.");
            }

            _dbcontex.Remove(profissionalPorId);
            await _dbcontex.SaveChangesAsync();
            return profissionalPorId;
        }

        public async Task<Profissional> Atualizar(Profissional profissional, int id)
        {
            var profissionalPorId = await BuscarPorId(id);
            if (profissionalPorId == null)
            {
                throw new KeyNotFoundException($"Profissional {id} não encontrado.");
            }

            // Verifica se já existe um profissional com o mesmo BI, excluindo o profissional atual
            if (await _dbcontex.Profissionais.AnyAsync(p => p.bi == profissional.bi && p.id != id))
            {
                throw new ArgumentException("Já existe um profissional com este BI.");
            }

            // Verifica se já existe um profissional com o mesmo telemóvel, excluindo o profissional atual
            if (await _dbcontex.Profissionais.AnyAsync(p => p.telemovel == profissional.telemovel && p.id != id))
            {
                throw new ArgumentException("Já existe um profissional com este telemóvel.");
            }

            // Atualiza as propriedades do profissional
            profissionalPorId.ProfissionalNome = profissional.ProfissionalNome;
            profissionalPorId.password = profissional.password;
            profissionalPorId.bi = profissional.bi;
            profissionalPorId.telemovel = profissional.telemovel;
            profissionalPorId.photo = profissional.photo;
            profissionalPorId.CategoriaId = profissional.CategoriaId;
            profissionalPorId.endereco = profissional.endereco;

            _dbcontex.Update(profissionalPorId);
            await _dbcontex.SaveChangesAsync();
            return profissionalPorId;
        }
    }
}
