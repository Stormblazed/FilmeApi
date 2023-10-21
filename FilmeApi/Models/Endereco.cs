using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int id { get; set; }

    [Required]
    public string lougradouro { get; set; }

    [Required]
    public int numero { get; set; }

    public virtual Cinema cinema { get; set; }

}
