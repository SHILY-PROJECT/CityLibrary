namespace WebApi.WebApi.Models.Dto.Books
{
    public class UpdateGenreOfBookDto
    {
        public int BookId { get; set; }
        public int OldGenreId { get; set; }
        public int NewGenreId { get; set; }
    }
}
