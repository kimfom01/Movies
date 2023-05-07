using AutoMapper;
using Movies.Models;

namespace Movies.Mapper;

public class AutoMappings : Profile
{
    public AutoMappings()
    {
        CreateMap<MovieApiDto, Movie>()
            .ForMember(mov => mov.Genre, 
            opt => opt.MapFrom(movDto => 
            string.Join(" ", movDto.Genres)));

        CreateMap<Movie, Details>();
    }
}
