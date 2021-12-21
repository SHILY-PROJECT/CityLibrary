using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimbirSoftWorkshop.API.Enums;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.Dto.Books;
using SimbirSoftWorkshop.API.Models.Entity;
using SimbirSoftWorkshop.API.Models.Dto.Authors;
using SimbirSoftWorkshop.API.Toolkit;

namespace SimbirSoftWorkshop.API.Repositories
{
    /// <summary>
    /// 2.6 - Репозиторий книги
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// 3.1.1 - Конструктор для реализации DI.
        /// </summary>
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавление новой книги.
        /// </summary>
        public ResultContent<Book> Add(NewBookDto newBook)
        {
            try
            {
                var author = _context.Authors.Find(newBook.AuthorId);
                var genre = _context.Genres.Find(newBook.GenreId);

                if (author is null)
                    return new ResultContent<Book>().Error($"'{nameof(author)}:{author}' - Автор не найден");

                if (genre is null)
                    return new ResultContent<Book>().Error($"'{nameof(genre)}:{genre}' - Жанр не найден");

                var book = new Book
                {
                    Name = newBook.Name,
                    AuthorId = author.Id
                };
                _context.Books.Add(book);
                _context.SaveChanges();

                _context.BooksGenres.Add(new BookGenre() { GenreId = genre.Id, BookId = book.Id });
                _context.SaveChanges();

                return new ResultContent<Book>().Ok(book, "Книга успешно добавлена");
            }
            catch (Exception ex)
            {
                return new ResultContent<Book>().Error(ex);
            }
        }

        /// <summary>
        /// Удаление книги.
        /// </summary>
        public ResultContent<Book> Delete(int bookId)
        {
            try
            {
                var book = _context.Books.Find(bookId);

                if (book is null)
                    return new ResultContent<Book>().Error($"'{nameof(bookId)}:{bookId}' - книга не найдена");

                if (book.LibraryCards.Any() is false)
                    return new ResultContent<Book>().Error($"'{nameof(bookId)}:{bookId}' - книга находится у пользователя");

                _context.Books.Remove(book);
                _context.SaveChanges();

                return new ResultContent<Book>().Ok(book, "Книга успешно удалена");
            }
            catch (Exception ex)
            {
                return new ResultContent<Book>().Error(ex);
            }
        }

        /// <summary>
        /// Получение книг автора.
        /// </summary>
        public ResultContent<IEnumerable<BookDetailsDto>> GetListBooksByAuthor(AuthorDto authorSearch, BookSortingTypeEnum sortingType)
        {
            var firstName = authorSearch.FirstName;
            var lastName = authorSearch.LastName;
            var middleName = authorSearch.MiddleName;

            try
            {
                var author = _context.Authors.Where(a =>
                    EF.Functions.Like(a.FirstName, firstName) && EF.Functions.Like(a.LastName, lastName) &&
                    (string.IsNullOrWhiteSpace(middleName) || EF.Functions.Like(a.MiddleName, middleName)))
                    .Include(a => a.Books)
                        .ThenInclude(b => b.BooksGenres)
                            .ThenInclude(bg => bg.Genre)
                    .FirstOrDefault();

                if (author is null)
                    return new ResultContent<IEnumerable<BookDetailsDto>>().Error(
                        $"'{nameof(firstName)}:{firstName} | {nameof(lastName)}:{lastName} | {nameof(middleName)}:{middleName}' - Автор не найден");

                if (author.Books is null || author.Books.Any() is false)
                    return new ResultContent<IEnumerable<BookDetailsDto>>().Error("По данному автору книг не найдено");

                var books = author.Books.Select(x => new BookDetailsDto
                {
                    Id = x.Id,
                    Title = x.Name,
                    GenreId = x.BooksGenres.FirstOrDefault(bg => bg.BookId == x.Id).GenreId,
                    Genre = x.BooksGenres.FirstOrDefault(bg => bg.BookId == x.Id).Genre.GenreName,
                    AuthorId = x.AuthorId,
                    Author = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .ToList();

                return new ResultContent<IEnumerable<BookDetailsDto>>().Ok(SortingBooks(books, sortingType));
            }
            catch (Exception ex)
            {
                return new ResultContent<IEnumerable<BookDetailsDto>>().Error(ex);
            }
        }

        /// <summary>
        /// Получение списка книг по жанру.
        /// </summary>
        public ResultContent<IEnumerable<BookDetailsDto>> GetListBooksByGenre(int genreId, BookSortingTypeEnum sortingType)
        {
            try
            {
                var booksGenres = _context.BooksGenres
                    .Where(x => x.GenreId == genreId)
                    .Include(bg => bg.Genre)
                    .Include(bg => bg.Book)
                        .ThenInclude(b => b.Author)
                    .ToList();

                if (booksGenres is null)
                    new ResultContent<IEnumerable<BookDetailsDto>>().Error($"'{nameof(genreId)}:{genreId}' - Жанр не найден");

                if (booksGenres.Any() is false)
                    new ResultContent<IEnumerable<BookDetailsDto>>().Error($"'{nameof(genreId)}:{genreId}' - По данному жанру ничего не найдено");

                var books = booksGenres.Select(x => new BookDetailsDto
                {
                    Id = x.BookId,
                    Title = x.Book.Name,
                    GenreId = x.GenreId,
                    Genre = x.Genre.GenreName,
                    AuthorId = x.Book.AuthorId,
                    Author = $"{x.Book.Author.FirstName} {x.Book.Author.LastName}"
                })
                .ToList();

                return new ResultContent<IEnumerable<BookDetailsDto>>().Ok(SortingBooks(books, sortingType));
            }
            catch (Exception ex)
            {
                return new ResultContent<IEnumerable<BookDetailsDto>>().Error(ex);
            }
        }

        /// <summary>
        /// Обновление жанра книги.
        /// </summary>
        public ResultContent<BookDetailsDto> UpdateGenre(UpdateGenreOfBookDto updateGenre)
        {
            var bookId = updateGenre.BookId;
            var oldGenreId = updateGenre.OldGenreId;
            var newGenreId = updateGenre.NewGenreId;

            try
            {
                var bookGenre = _context.BooksGenres.Find(bookId, oldGenreId);

                if (bookGenre is null)
                    return new ResultContent<BookDetailsDto>().Error($"'{nameof(bookId)}:{bookId} | {nameof(oldGenreId)}:{oldGenreId}' - Книга с жанром не найдена");
                
                if (newGenreId != 0 && _context.Genres.Find(newGenreId) is null)
                    return new ResultContent<BookDetailsDto>().Error($"'{nameof(newGenreId)}:{newGenreId}' - Жанра не существует");

                if (newGenreId != 0)
                {
                    _context.BooksGenres.Remove(bookGenre);
                    bookGenre.GenreId = newGenreId;
                    _context.BooksGenres.Add(bookGenre);
                }
                else _context.BooksGenres.Remove(bookGenre);

                _context.SaveChanges();

                var book = _context.Books
                    .Where(x => x.Id == bookId)
                    .Include(b => b.Author)
                    .Include(b => b.BooksGenres)
                        .ThenInclude(bg => bg.Genre)
                    .FirstOrDefault();

                var bookDto = new BookDetailsDto
                {
                    Id = book.Id,
                    Title = book.Name,
                    GenreId = bookGenre.GenreId,
                    Genre = bookGenre.Genre.GenreName,
                    AuthorId = book.AuthorId,
                    Author = $"{book.Author.FirstName} {book.Author.LastName}"
                };

                return new ResultContent<BookDetailsDto>().Ok(bookDto);
            }
            catch (Exception ex)
            {
                return new ResultContent<BookDetailsDto>().Error(ex);
            }
        }

        /// <summary>
        /// Сортировка книг.
        /// </summary>
        private static IEnumerable<BookDetailsDto> SortingBooks(List<BookDetailsDto> books, BookSortingTypeEnum sortingType) => sortingType switch
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
