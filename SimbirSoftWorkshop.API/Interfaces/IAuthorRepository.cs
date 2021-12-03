using System.Collections.Generic;
using SimbirSoftWorkshop.API.Models.DatabaseModels;
using SimbirSoftWorkshop.API.Models.ViewModel;

namespace SimbirSoftWorkshop.API.Interfaces
{
    public interface IAuthorRepository
    {
        public IEnumerable<Author> GetListAuthors();
        public Author GetListBooksByAuthor(int authorId);
        public Author Add(FullNameDto fullName, List<string> books = null);
        public void Delete(int authorId);
    }
}
