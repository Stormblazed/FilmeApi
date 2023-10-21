using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "O titulo do filme é obrigatório")]
    [StringLength(500, ErrorMessage = "O tamanho do titulo não pode exceder 500 caracteres")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração do filme é obrigatório")]
    [Range(70, 600, ErrorMessage = "A duração do filme deve ter entre 70 a 600 minutos")]
    public int Duracao { get; set; }
 
}
