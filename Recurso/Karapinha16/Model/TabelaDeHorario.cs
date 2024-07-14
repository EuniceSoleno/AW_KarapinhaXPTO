using Karapinha.Model;

public class TabelaDeHorario
{
    public int Id { get; set; }
    public string ProfissionalNome { get; set; }

    public int HoraInicioHora { get; set; }
    public int HoraInicioMinuto { get; set; }
    public int HoraFimHora { get; set; }
    public int HoraFimMinuto { get; set; }

    public string DiaSemana { get; set; }

  /* public TabelaDeHorario (string profissionalNome, int HoraInicioHora, int HoraInicioMinuto, int HoraFimHora,
       int HoraFimMinuto, string DiaSemana)
    {
        this.HoraFimHora = HoraInicioHora;
        this.HoraInicioMinuto = HoraFimMinuto;
        this.HoraFimHora = HoraFimHora;
        this.HoraFimMinuto = HoraFimMinuto;
        this.DiaSemana = DiaSemana;
        this.ProfissionalNome = profissionalNome;

    }*/

}
