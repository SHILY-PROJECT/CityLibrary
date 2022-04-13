using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.WebApi.Models.Author;
using CityLibrary.WebApi.Models.Book;
using CityLibrary.WebApi.Models.Genre;
using CityLibrary.WebApi.Models.Person;

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
        CreateMap<PersonForDeleteDto, Author>().ReverseMap();
    }
}