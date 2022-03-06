namespace WebApi.WebApi.Models.Dto.Books
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
