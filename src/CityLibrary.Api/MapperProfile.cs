using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.Api.Models.Authors;
using CityLibrary.Api.Models.Books;
using CityLibrary.Api.Models.Genres;
using CityLibrary.Api.Models.Persons;

namespace CityLibrary.Api;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AuthorDto, Author>().ReverseMap();
        CreateMap<AuthorForSearchDto, Author>().ReverseMap();

        CreateMap<BookDto, Book>().ReverseMap();
        CreateMap<NewBookWithAuthorDto, Book>().ReverseMap();
        CreateMap<NewBookWithoutAuthorDto, Book>().ReverseMap();

        CreateMap<GenreDto, Genre>().ReverseMap();
        CreateMap<GenreStatsDto, GenreStats>().ReverseMap();

        CreateMap<PersonDto, Person>().ReverseMap();
        CreateMap<PersonForDeleteDto, Person>().ReverseMap();
        CreateMap<LibraryCardDto, LibraryCard>().ReverseMap();
    }
}