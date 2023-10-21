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
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarCinemasPorId), new { id = cinema.id }, cinema);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> ListarCinemas([FromQuery] int? enderecoId = null)
    {
        if (enderecoId == null)
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.cinemas.ToList());
        }
        return _mapper.Map<List<ReadCinemaDto>>(
            _context.cinemas.FromSqlRaw($"SELECT id, nome, enderecoId	FROM public.cinemas where cinemas.enderecoid={enderecoId}").ToList());
        
    }

    [HttpGet("{id}")]
    public IActionResult ListarCinemasPorId(int id)
    {
        var cinema = _context.cinemas.FirstOrDefault(item => item.id == id);
        if (cinema == null) return NotFound();

        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinema);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarCinema(int id)
    {
        var cinemaLocalizado = _context.cinemas.FirstOrDefault(item => item.id == id);

        if (cinemaLocalizado == null) return NotFound();

        _context.cinemas.Remove(cinemaLocalizado);
        _context.SaveChanges();

        return NoContent();

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinemaLocalizado = _context.cinemas.FirstOrDefault(item => item.id == id);

        if (cinemaLocalizado == null) return NotFound();
        _mapper.Map(cinemaDto, cinemaLocalizado);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaCinemaParcial(int id, JsonPatchDocument<UpdateCinemaDto> patch)
    {
        var cinemaLocalizado = _context.cinemas.FirstOrDefault(item => item.id == id);
        if (cinemaLocalizado == null) return NotFound();

        var cinemaParaAtualizar = _mapper.Map<UpdateCinemaDto>(cinemaLocalizado);

        patch.ApplyTo(cinemaParaAtualizar, ModelState);

        if (!TryValidateModel(cinemaParaAtualizar)) return ValidationProblem(ModelState);

        _mapper.Map(cinemaParaAtualizar, cinemaLocalizado);
        _context.SaveChanges();

        return NoContent();
    }
}