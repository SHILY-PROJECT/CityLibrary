using System.Collections.Generic;
using SimbirSoftWorkshop.API.Enums;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Models.Dto.Authors;
using SimbirSoftWorkshop.API.Models.Dto.Books;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IBookRepository
    {
        public ResultContent<Book> Add(NewBookDto newBook);
        public ResultContent<Book> Delete(int bookId);
        public ResultContent<BookDto> UpdateGenre(UpdateGenreOfBookDto bookUpdateGenre);
        public ResultContent<IEnumerable<BookDto>> GetListBooksByAuthor(AuthorDto authorSearch, BookSortingTypeEnum sortingType);
        public ResultContent<IEnumerable<BookDto>> GetListBooksByGenre(int genreId, BookSortingTypeEnum sortingType);
    }
}
