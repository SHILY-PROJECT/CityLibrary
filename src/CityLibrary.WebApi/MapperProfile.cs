using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.WebApi.Models.Authors;
using CityLibrary.WebApi.Models.Books;
using CityLibrary.WebApi.Models.Genres;
using CityLibrary.WebApi.Models.Persons;

namespace CityLibrary.WebApi;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AuthorDto, Author>().ReverseMap();
        CreateMap<AuthorForSearchDto, Author>().ReverseMap();
        CreateMap<BookDto, Book>().ReverseMap();
        CreateMap<GenreDto, Genre>().ReverseMap();
        CreateMap<GenreStatsDto, GenreStats>().ReverseMap();
        CreateMap<LibraryCardDto, LibraryCard>().ReverseMap();
        CreateMap<PersonDto, Person>().ReverseMap();
        CreateMap<PersonForDeleteDto, Person>().ReverseMap();
    }
}