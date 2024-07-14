using System.Reflection.Metadata;

namespace Karapinha.Model
{
    public class Marcacao
    {
        public int Id { get; set; }
        public string CategoriaNome { get; set; }
        public virtual Categoria? Categoria { get; set; }
        public string ServicoNome { get; set; }
        public virtual Servico? Servico { get; set; }
        public string ProfissionalNome { get; set; }
        public virtual Profissional? Profissional { get; set; }
        public  string DiaSemana {  get; set; }
        public string hora { get; set; }
        public string minuto { get; set; }

        public static implicit operator bool(Marcacao v)
        {
            throw new NotImplementedException();
        }
    }
}
