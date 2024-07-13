using SistemaDeTarefas.Enuns;

namespace SistemaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa status { get; set; }

        public int ? usuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
