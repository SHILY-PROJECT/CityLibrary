namespace SimbirSoftWorkshop.API.Models.DatabaseModels
{
    /// <summary>
    /// 2.2 - Класс книги и её жанра, предназначен для связи двух моделей (описывающий сущность для БД)
    /// </summary>
    public class BookGenre
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
