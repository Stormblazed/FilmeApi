using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int id { get; set; }
    [Required(ErrorMessage = "O titulo do filme é obrigatório")]
    [MaxLength(500,ErrorMessage ="O tamanho do titulo não pode exceder 500 caracteres")]
    public string titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string genero { get; set; }
    [Required(ErrorMessage ="A duração do filme é obrigatório")]
    [Range(70, 600,ErrorMessage ="A duração do filme deve ter entre 70 a 600 minutos")]
    public int duracao { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }

}
