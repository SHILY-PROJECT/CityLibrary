using AutoMapper;
using Domain.Models;
using Domain.Interfaces.Repositories;
using DataAccess.Models;
using DataAccess.Entities;

namespace DataAccess.Repositories;

public sealed class GenreRepository : BaseRepository<Genre, GenreDb>, IGenreRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public GenreRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Genres, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<GenreStats> GenreStats()
    {
        var statsEntities = _context.Genres.Select(genre => new GenreStatsModel
        {
            Genre = genre,
            Quantity = _context.Books.Count(book => book.Genre.Id == genre.Id)
        });

        return _mapper.Map<IEnumerable<GenreStats>>(statsEntities);
    }
}