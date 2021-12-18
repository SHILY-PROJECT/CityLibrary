using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Authors;
using SimbirSoftWorkshop.API.Toolkit;

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

        /// <summary>
        /// Получение списка всех авторов.
        /// </summary>
        /// <returns></returns>
        public ResultContent<IEnumerable<Author>> GetListAuthors()
        {
            try
            {
                return new ResultContent<IEnumerable<Author>>().Ok(_context.Authors.ToList());
            }
            catch (Exception ex)
            {
                return new ResultContent<IEnumerable<Author>>().Error(ex);
            }
        }

        /// <summary>
        /// Получение списка всех книг автора.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public ResultContent<IEnumerable<AuthorBookDto>> GetListBooksByAuthor(int authorId)
        {
            try
            {
                var author = _context.Authors
                    .Where(a => a.Id == authorId)
                    .Include(a => a.Books)
                        .ThenInclude(b => b.BooksGenres)
                            .ThenInclude(bg => bg.Genre)
                    .FirstOrDefault();

                var books = author.Books.Select(book => new AuthorBookDto
                {
                    AuthorId = authorId,
                    Author = $"{author.FirstName} {author.LastName}",
                    BookId = book.Id,
                    BookName = book.Name,
                    GenreId = book.BooksGenres.FirstOrDefault(x => x.BookId == book.Id).GenreId,
                    GenreName = book.BooksGenres.FirstOrDefault(x => x.BookId == book.Id).Genre.GenreName
                })
                .ToList();

                return new ResultContent<IEnumerable<AuthorBookDto>>().Ok(books);
            }
            catch (Exception ex)
            {
                return new ResultContent<IEnumerable<AuthorBookDto>>().Error(ex);
            }
        }

        /// <summary>
        /// Добавление нового автора (с книгами/без)
        /// </summary>
        /// <param name="authorDto"></param>
        /// <param name="books"></param>
        /// <returns></returns>
        public ResultContent<Author> Add(AuthorDto authorDto, List<string> books = null)
        {
            try
            {
                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    MiddleName = authorDto.MiddleName,
                    Books = books is not null && !books.Any(x => !string.IsNullOrWhiteSpace(x)) ? books.Where(x => string.IsNullOrWhiteSpace(x)).Select(x => new Book { Name = x }).ToList() : null
                };

                _context.Authors.Add(author);
                _context.SaveChanges();

                return new ResultContent<Author>().Ok(author);
            }
            catch (Exception ex)
            {
                return new ResultContent<Author>().Error(ex);
            }
        }

        /// <summary>
        /// Удаление автора.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public ResultContent<Author> Delete(int authorId)
        {
            try
            {
                var author = _context.Authors.Include(a => a.Books).FirstOrDefault(x => x.Id == authorId);

                if (author is null)
                    return new ResultContent<Author>().Error($"'{nameof(authorId)}:{authorId}' - Автор не найден");

                if (author.Books.Any())
                    return new ResultContent<Author>().Error($"'{nameof(authorId)}:{authorId}' - Невозможно удалить автора, пока у него есть книги");

                _context.Authors.Remove(author);
                _context.SaveChanges();

                return new ResultContent<Author>().Ok(author);
            }
            catch (Exception ex)
            {
                return new ResultContent<Author>().Error(ex);
            }
        }

    }
}
