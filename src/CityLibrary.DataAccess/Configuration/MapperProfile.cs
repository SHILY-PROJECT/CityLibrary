using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.DataAccess.Entities;
using CityLibrary.DataAccess.Models;

namespace CityLibrary.DataAccess.Configuration;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AuthorDb, Author>().ReverseMap();
        CreateMap<BookDb, Book>().ReverseMap();
        CreateMap<GenreDb, Genre>().ReverseMap();
        CreateMap<GenreStatsModel, GenreStats>().ReverseMap();
        CreateMap<LibraryCardDb, LibraryCard>().ReverseMap();
        CreateMap<PersonDb, Person>().ReverseMap();
    }
}