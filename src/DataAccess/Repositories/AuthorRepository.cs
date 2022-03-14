using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using DataAccess.Entities;

namespace DataAccess.Repositories;

public sealed class AuthorRepository : BaseRepository<Author, AuthorDb>, IAuthorRepository
{
    private readonly CityLibraryDbContext _context;
    private readonly IMapper _mapper;

    public AuthorRepository(CityLibraryDbContext context, IMapper mapper) : base(context, context.Authors, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId)
    {
        var books = await _context.Books.Where(book => book.AuthorId == authorId).ToArrayAsync();
        return _mapper.Map<IEnumerable<Book>>(books);
    }
}