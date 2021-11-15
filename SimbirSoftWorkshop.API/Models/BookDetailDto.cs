namespace SimbirSoftWorkshop.API.Models
{
    /// <summary>
    /// Класс книги (с более детальными данными объекта)
    /// </summary>
    public class BookDetailDto : BookDto
    {
        public long Id { get; set; }

        public long AuthorId { get; set; }

    }
}
