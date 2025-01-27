﻿using Karapinha.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karapinha.Repositorios.Interface
{
    public interface ITabelaDeHorarioRepositorio
    {
        Task<TabelaDeHorario> BuscarPorId(int id);
        Task<List<TabelaDeHorario>> BuscarTodos();
        Task<TabelaDeHorario> Adicionar(TabelaDeHorario tabelaDeHorario);
        Task<TabelaDeHorario> Atualizar(TabelaDeHorario tabelaDeHorario, int id);
        Task<TabelaDeHorario> Apagar(int id);
        Task<bool>IsHorarioValido(TabelaDeHorario tabelaDeHorario);

        Task<bool> IsHorarioDentroDoIntervalo(TabelaDeHorario tabelaDeHorario, int hora, int minuto);

        Task<TabelaDeHorario> BuscarPorNomeProfissional(string nome);
    }
}
