using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimbirSoftWorkshop.API.Enums;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.DatabaseModels;
using SimbirSoftWorkshop.API.Models.ViewModel;

namespace SimbirSoftWorkshop.API.Repositories
{
    /// <summary>
    /// 2.6 - Репозиторий книги
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(string nameBook, int genreId, int authorId)
        {
            var author = _context.Authors.Find(authorId);
            var genre = _context.Genres.Find(genreId);

            if (author is null) throw new Exception($"'{nameof(author)}:{author}' - Автор не найден");
            else if (genre is null) throw new Exception($"'{nameof(genre)}:{genre}' - Жанр не найден");

            var book = new Book
            {
                Name = nameBook,               
                AuthorId = author.Id
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            _context.BooksGenres.Add(new() { GenreId = genre.Id, BookId = book.Id});
            _context.SaveChanges();
        }

        public void Delete(int bookId)
        {
            var book = _context.Books.Find(bookId);

            if (book is null) throw new Exception($"'{nameof(bookId)}:{bookId}' - книга не найдена");
            else if (!book.LibraryCards.Any()) throw new Exception($"'{nameof(bookId)}:{bookId}' - книга находится у пользователя");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<BookDto> GetListBooksByAuthor(FullNameDto fullNameDto, BookSortingTypeEnum sortingType)
        {
            var firstName = fullNameDto.FirstName;
            var lastName = fullNameDto.LastName;
            var middleName = fullNameDto.MiddleName;
            var author = _context.Authors.Where
            (a =>
                EF.Functions.Like(a.FirstName, firstName) &&
                EF.Functions.Like(a.LastName, lastName) &&
                (string.IsNullOrWhiteSpace(middleName) ||
                EF.Functions.Like(a.MiddleName, middleName))
            )
            .Include(a => a.Books)
            .ThenInclude(b => b.BooksGenres)
            .ThenInclude(bg => bg.Genre)
            .FirstOrDefault();
            
            if (author is null) throw new Exception($"'{nameof(firstName)}:{firstName} | {nameof(lastName)}:{lastName} | {nameof(middleName)}:{middleName}' - Автор не найден");
            else if (author.Books is null || !author.Books.Any()) return new List<BookDto>();

            var books = author.Books.Select(x => new BookDto
            {
                Id = x.Id,
                Title = x.Name,
                GenreId = x.BooksGenres.FirstOrDefault(bg => bg.BookId == x.Id).GenreId,
                Genre = x.BooksGenres.FirstOrDefault(bg => bg.BookId == x.Id).Genre.GenreName,
                AuthorId = x.AuthorId,
                Author = $"{x.Author.FirstName} {x.Author.LastName}"
            })
            .ToList();

            return SortingBooks(books, sortingType);
        }

        public IEnumerable<BookDto> GetListBooksByGenre(int genreId, BookSortingTypeEnum sortingType)
        {
            var booksGenres = _context.BooksGenres.Where(x => x.GenreId == genreId)
                .Include(bg => bg.Genre)
                .Include(bg => bg.Book)
                .ThenInclude(b => b.Author)
                .ToList();

            if (booksGenres is null) throw new Exception($"'{nameof(genreId)}:{genreId}' - Жанр не найден");
            else if (!booksGenres.Any()) return new List<BookDto>();

            var books = booksGenres.Select(x => new BookDto
            {
                Id =  x.BookId,
                Title = x.Book.Name,
                GenreId = x.GenreId,
                Genre = x.Genre.GenreName,
                AuthorId = x.Book.AuthorId,
                Author = $"{x.Book.Author.FirstName} {x.Book.Author.LastName}"
            })
            .ToList();

            return SortingBooks(books, sortingType);
        }

        public BookDto UpdateGenre(BookUpdateGenreDto bookUpdateGenreDto)
        {
            var bookId = bookUpdateGenreDto.BookId;
            var oldGenreId = bookUpdateGenreDto.OldGenreId;
            var newGenreId = bookUpdateGenreDto.NewGenreId;
            var bookGenre = _context.BooksGenres.Find(bookId, oldGenreId);

            if (bookGenre is null) throw new Exception($"'{nameof(bookId)}:{bookId} | {nameof(oldGenreId)}:{oldGenreId}' - Книга с жанром не найдена");
            else if (newGenreId != 0 && _context.Genres.Find(newGenreId) is null) throw new Exception($"'{nameof(newGenreId)}:{newGenreId}' - Жанра не существует");

            if (newGenreId != 0)
            {
                _context.BooksGenres.Remove(bookGenre);
                _context.SaveChanges();

                bookGenre.GenreId = newGenreId;
                _context.BooksGenres.Add(bookGenre);
            }
            else _context.BooksGenres.Remove(bookGenre);
            
            _context.SaveChanges();

            var book = _context.Books.Where(x => x.Id == bookId)
                .Include(b => b.Author)
                .Include(b => b.BooksGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefault();

            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Name,
                GenreId = bookGenre.GenreId,
                Genre = bookGenre.Genre.GenreName,
                AuthorId = book.AuthorId,
                Author = $"{book.Author.FirstName} {book.Author.LastName}"
            };

            return bookDto;
        }

        private static IEnumerable<BookDto> SortingBooks(List<BookDto> books, BookSortingTypeEnum sortingType) => sortingType switch
        {
            BookSortingTypeEnum.BookName =>         books.OrderBy(x => x.Title).ToList(),
            BookSortingTypeEnum.BookNameReversed => books.OrderByDescending(x => x.Title).ToList(),
            BookSortingTypeEnum.Author =>           books.OrderBy(x => x.Author).ToList(),
            BookSortingTypeEnum.AuthorReversed =>   books.OrderByDescending(x => x.Author).ToList(),
            BookSortingTypeEnum.NoSort =>           books,
            _ =>                                    books
        };
    }
}
