using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos;
using FilmeApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost] 
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarFilmesPorId), new { id = filme.id }, filme);
    }

    [HttpGet]    
    public IEnumerable<ReadFilmeDto> ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? nomeCinema = null)
    {
        if(nomeCinema == null)
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.filmes.Skip(skip).Take(take).ToList());
        }
        return _mapper.Map<List<ReadFilmeDto>>(_context.filmes.Where( filme => 
                                                                       filme.Sessoes.Any(sessao => 
                                                                                         sessao.cinema.nome == nomeCinema)).Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ListarFilmesPorId(int id)
    {
        var filme = _context.filmes.FirstOrDefault(item => item.id == id);
        if (filme == null) return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filme);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filmeLocalizado = _context.filmes.FirstOrDefault(item => item.id == id);

        if (filmeLocalizado == null) return NotFound();
            
        _context.filmes.Remove(filmeLocalizado);
        _context.SaveChanges();

        return NoContent();

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filmeLocalizado = _context.filmes.FirstOrDefault(item => item.id == id);

        if (filmeLocalizado == null) return NotFound();
        _mapper.Map(filmeDto, filmeLocalizado);       

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filmeLocalizado = _context.filmes.FirstOrDefault(item => item.id == id);
        if (filmeLocalizado == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filmeLocalizado);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar)) return ValidationProblem(ModelState);

        _mapper.Map(filmeParaAtualizar, filmeLocalizado);
        _context.SaveChanges();

        return NoContent();
    }
}
