
namespace Karapinha.Model
{
    public class Utilizador
    {
        public int id { get; set; }
        public string nomeCompleto { get; set; }
        public string endereco { get; set; }
        public string telemovel { get; set; }
        public string bi { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public byte[]? photo { get; set; }

        public Utilizador(byte[]? photo, int id, string nomeCompleto, string endereco, string telemovel, string bi, string username, string password, string nivelDeAcesso)
        {
            this.id = id;
            this.nomeCompleto = nomeCompleto;
            this.endereco = endereco;
            this.telemovel = telemovel;
            this.bi = bi;
            this.username = username;
            this.password = password;
            this.photo = photo;
            this.nivelDeAcesso = nivelDeAcesso;
        }

        public string nivelDeAcesso {  get; set; }

        public static implicit operator bool(Utilizador v)
        {
            throw new NotImplementedException();
        }
    }
}
