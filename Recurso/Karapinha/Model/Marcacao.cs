namespace Karapinha.Model
{
    public class Marcacao
    {
        public int Id { get; set; }
        public virtual ICollection<Categoria>? Categorias { get; set; }  // Múltiplas Categorias
        public virtual ICollection<Servico>? Servicos { get; set; }  // Múltiplos Serviços
        public virtual ICollection<Profissional>? Profissionais { get; set; }  // Múltiplos Profissionais
        public string DiaSemana { get; set; }
        public string Hora { get; set; }
        public string Minuto { get; set; }

        public static implicit operator bool(Marcacao v)
        {
            throw new NotImplementedException();
        }
    }
}
