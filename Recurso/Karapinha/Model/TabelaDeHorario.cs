namespace Karapinha.Model
{
    public class TabelaDeHorario
    {
        public string ProfissionalNome { get; set; }
        public virtual Profissional Profissional { get; set; }

        public string hora { get; set; }
        public string minuto {  get; set; }



    }
}
