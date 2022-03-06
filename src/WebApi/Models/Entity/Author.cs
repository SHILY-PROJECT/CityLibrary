using System.Collections.Generic;

namespace WebApi.WebApi.Models.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
