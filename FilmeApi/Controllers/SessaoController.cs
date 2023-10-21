using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using FilmeApi.Models;

namespace FilmeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
    {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _context.sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarSessaosPorId), new { filmeId = sessao.filmeId, cinemaId = sessao.cinemaId }, sessao);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> ListarSessaos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.sessoes.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{filmeId}/{cinemaId}")]
    public IActionResult ListarSessaosPorId(int filmeId, int cinemaId)
    {
        var sessao = _context.sessoes.FirstOrDefault(item => item.filmeId == filmeId && item.cinemaId == cinemaId);
        if (sessao == null) return NotFound();

        var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
        return Ok(sessao);
    }

    [HttpDelete("{filmeId}/{cinemaId}")]
    public IActionResult DeletarSessao(int filmeId, int cinemaId)
    {
        var sessaoLocalizado = _context.sessoes.FirstOrDefault(item => item.filmeId == filmeId && item.cinemaId == cinemaId);

        if (sessaoLocalizado == null) return NotFound();

        _context.sessoes.Remove(sessaoLocalizado);
        _context.SaveChanges();

        return NoContent();

    }
}
