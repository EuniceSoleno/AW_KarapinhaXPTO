﻿using System.ComponentModel;

namespace SistemaDeTarefas.Enuns
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,

        [Description("Concluido")]
        Concluido = 3

    }
}
