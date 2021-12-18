using System.Collections.Generic;
using SimbirSoftWorkshop.API.Toolkit;
using SimbirSoftWorkshop.API.Models.Dto.Authors;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IAuthorRepository
    {
        public ResultContent<IEnumerable<Author>> GetListAuthors();
        public ResultContent<IEnumerable<AuthorBookDto>> GetListBooksByAuthor(int authorId);
        public ResultContent<Author> Add(AuthorDto author, List<string> books = null);
        public ResultContent<Author> Delete(int authorId);
    }
}
