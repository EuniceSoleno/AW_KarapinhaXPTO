using System;
using System.Collections.Generic;

namespace Karapinha.Model
{
    public class TabelaDeHorario
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public virtual ICollection<Marcacao> Marcacoes { get; set; }
    }
}
