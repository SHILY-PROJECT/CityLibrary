using Domain.Models;
using Domain.Interfaces.Repositories;
using DataAccess.Entities;
using AutoMapper;

namespace DataAccess.Repositories;

public class GenreRepository : BaseRepository<Genre, GenreDb>, IGenreRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public GenreRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Genres, mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}