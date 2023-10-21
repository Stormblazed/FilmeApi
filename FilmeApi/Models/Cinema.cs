using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Models;
public class Cinema
{
    [Key]
    [Required]
    public int id { get; set; }

    [Required(ErrorMessage = "O campo de nome é obrigatório!")] 
    public string nome { get; set; }
    
    public int enderecoid {  get; set; }

    public virtual Endereco endereco { get; set; }

    public virtual ICollection<Sessao> sessoes { get; set; }

}
