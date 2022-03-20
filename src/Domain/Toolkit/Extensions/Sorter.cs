using Domain.Enums;
using Domain.Models;

namespace Domain.Toolkit.Extensions;

internal static class Sorter
{
    public static IEnumerable<Book> SortBooks(this IEnumerable<Book> books, BookSortType sortType) => sortType switch
    {
        BookSortType.BookName           => books.OrderBy(x => x.Name),
        BookSortType.BookNameReversed   => books.OrderByDescending(x => x.Name),
        BookSortType.Author             => books.OrderBy(x => x.Author),
        BookSortType.AuthorReversed     => books.OrderByDescending(x => x.Author),
        BookSortType.NoSort             => books,
        _                               => books
    };
}
