using System.Collections.Generic;
using SimbirSoftWorkshop.API.Enums;
using SimbirSoftWorkshop.API.Models.ViewModel;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IBookRepository
    {
        public void Add(string nameBook, int genreId, int authorId);
        public void Delete(int bookId);
        public BookDto UpdateGenre(BookUpdateGenreDto bookUpdateGenreDto);
        public IEnumerable<BookDto> GetListBooksByAuthor(FullNameDto fullNameDto, BookSortingTypeEnum sortingType);
        public IEnumerable<BookDto> GetListBooksByGenre(int genreId, BookSortingTypeEnum sortingType);
    }
}
