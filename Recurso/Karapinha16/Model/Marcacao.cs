namespace Karapinha.Model
{
    public class Marcacao
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public string NomeProfissional { get; set; }

        public string estado { get; set; }
        public Marcacao(int id, string diaSemana, int hora, int minuto, string nomeProfissional)
        {
            Id = id;
            DiaSemana = diaSemana;
            Hora = hora;
            Minuto = minuto;
            NomeProfissional = nomeProfissional;
            //o estado de uma marcacao e pendente por default
            estado = "Pendente";

        }

        public string HoraCompleta => $"{Hora:D2}:{Minuto:D2}";

        public static implicit operator bool(Marcacao v)
        {
            throw new NotImplementedException();
        }
    }
}
