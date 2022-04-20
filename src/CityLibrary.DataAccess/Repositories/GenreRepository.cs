using AutoMapper;
using CityLibrary.Domain.Models;
using CityLibrary.Domain.Interfaces.Repositories;
using CityLibrary.DataAccess.Models;
using CityLibrary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityLibrary.DataAccess.Repositories;

internal class GenreRepository : BaseRepository<Genre, GenreDb>, IGenreRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public GenreRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Genres, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreStats>> GenreStatsAsync()
    {
        var statsEntities = await _context.Genres
            .Select(genre => new GenreStatsModel(genre, _context.Books.Count(book => book.Genre.Id == genre.Id)))
            .ToArrayAsync();

        return _mapper.Map<GenreStats[]>(statsEntities);
    }
}