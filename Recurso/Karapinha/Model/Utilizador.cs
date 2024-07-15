using System.ComponentModel.DataAnnotations;

public class Utilizador
{
    public int Id { get; set; } 

    [Required]
    public string NomeCompleto { get; set; }

    [Required]
    public string Endereco { get; set; }

    [Required]
    public string Telemovel { get; set; }

    [Required]
    public string Bi { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public byte[] Photo { get; set; } // `photo` deve ser um array de bytes
    public string NivelAcesso { get; set; }

}
