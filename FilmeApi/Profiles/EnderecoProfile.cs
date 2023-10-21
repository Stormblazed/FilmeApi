using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Models;

namespace EnderecoApi.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile() {

        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();       
    }
}
