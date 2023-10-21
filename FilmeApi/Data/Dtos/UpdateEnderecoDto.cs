using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos;

public class UpdateEnderecoDto
{
    [Required]
    public string Lougradouro { get; set; }

    [Required]
    public int Numero { get; set; }
}
