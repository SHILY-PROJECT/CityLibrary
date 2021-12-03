using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.DatabaseModels;
using SimbirSoftWorkshop.API.Models.ViewModel;

namespace SimbirSoftWorkshop.API.Repositories
{
    /// <summary>
    /// 2.6 - Репозиторий автора
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetListAuthors()
        {
            return _context.Authors;
        }

        public Author GetListBooksByAuthor(int authorId)
        {
            return _context.Authors
                .Where(a => a.Id == authorId)
                .Include(a => a.Books)
                .ThenInclude(b => b.BooksGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefault();
        }

        public Author Add(FullNameDto fullName, List<string> books = null)
        {
            var firstName = fullName.FirstName;
            var lastName = fullName.LastName;
            var middleName = fullName.MiddleName;
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Books = books is not null && !books.Any(x => !string.IsNullOrWhiteSpace(x)) ? books.Where(x => string.IsNullOrWhiteSpace(x)).Select(x => new Book { Name = x }).ToList() : null
            };

            _context.Authors.Add(author);
            _context.SaveChanges();

            return author;
        }

        public void Delete(int authorId)
        {
            var author = _context.Authors.Include(a => a.Books).FirstOrDefault(x => x.Id == authorId);

            if (author is null) throw new Exception($"'{nameof(authorId)}:{authorId}' - Автор не найден");
            else if (author.Books.Any()) throw new Exception($"'{nameof(authorId)}:{authorId}' - Невозможно удалить автора, пока у него есть книги");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

    }
}
