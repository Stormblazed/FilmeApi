using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Models;
public class Sessao
{
    public int? filmeId { get; set; }
    public virtual Filme filme { get; set; }
    public int? cinemaId { get; set; }
    public virtual Cinema cinema { get; set; }


}
