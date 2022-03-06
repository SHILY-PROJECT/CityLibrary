namespace WebApi.WebApi.Models.Dto.Authors
{
    public class AuthorBookDetailsDto
    {
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
