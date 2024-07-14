
namespace Karapinha.Model
{
    public class Profissional
    {
        public int id {  get; set; }
        public string ProfissionalNome { get; set; }
        public string endereco  { get; set; }
        public string telemovel { get; set; }
        public string bi {get; set; }
        public string password { get; set; }
       /* public byte []? photo { get; set; }
        public string PhotoBase64 { get; set; }*/
        public int CategoriaId { get; set; }
        public  string userName { get; set; }
        public string nivelDeAcesso { get; set; }


      /* public Profissional (int categoriaId, string nomeFuncionario, string endereco, string contacto, string bi)
        {
            this.CategoriaId = categoriaId;
            this.ProfissionalNome = nomeFuncionario;
            this.endereco = endereco;
            this.telemovel = contacto;
            this.nivelDeAcesso = "profissional";

        }*/

        public static implicit operator bool(Profissional v)
        {
            throw new NotImplementedException();
        }
    }
}
