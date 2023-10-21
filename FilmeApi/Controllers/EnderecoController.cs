using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Data;
using FilmeApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto EnderecoDto)
    {
        Endereco Endereco = _mapper.Map<Endereco>(EnderecoDto);
        _context.enderecos.Add(Endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarEnderecosPorId), new { id = Endereco.id }, Endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> ListarEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.enderecos.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ListarEnderecosPorId(int id)
    {
        var Endereco = _context.enderecos.FirstOrDefault(item => item.id == id);
        if (Endereco == null) return NotFound();

        var EnderecoDto = _mapper.Map<ReadEnderecoDto>(Endereco);
        return Ok(Endereco);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarEndereco(int id)
    {
        var EnderecoLocalizado = _context.enderecos.FirstOrDefault(item => item.id == id);

        if (EnderecoLocalizado == null) return NotFound();

        _context.enderecos.Remove(EnderecoLocalizado);
        _context.SaveChanges();

        return NoContent();

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto EnderecoDto)
    {
        var EnderecoLocalizado = _context.enderecos.FirstOrDefault(item => item.id == id);

        if (EnderecoLocalizado == null) return NotFound();
        _mapper.Map(EnderecoDto, EnderecoLocalizado);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaEnderecoParcial(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var EnderecoLocalizado = _context.enderecos.FirstOrDefault(item => item.id == id);
        if (EnderecoLocalizado == null) return NotFound();

        var EnderecoParaAtualizar = _mapper.Map<UpdateEnderecoDto>(EnderecoLocalizado);

        patch.ApplyTo(EnderecoParaAtualizar, ModelState);

        if (!TryValidateModel(EnderecoParaAtualizar)) return ValidationProblem(ModelState);

        _mapper.Map(EnderecoParaAtualizar, EnderecoLocalizado);
        _context.SaveChanges();

        return NoContent();
    }
}
