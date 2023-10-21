using AutoMapper;
using FilmeApi.Data.Dtos;
using FilmeApi.Models;

namespace FilmeApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco,
                       opt => opt.MapFrom(cinema => cinema.endereco))
            .ForMember(cinemaDto => cinemaDto.Sessoes,
                       opt => opt.MapFrom(cinema => cinema.sessoes));
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}
