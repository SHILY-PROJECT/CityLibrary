using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftWorkshop.API.Models.ViewModel
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
