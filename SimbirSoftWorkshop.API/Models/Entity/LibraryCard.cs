namespace SimbirSoftWorkshop.API.Models.Entity
{
    /// <summary>
    /// 2.2 - Класс библиотечной карточки, предназначен для связи двух моделей (описывающий сущность для БД)
    /// </summary>
    public class LibraryCard
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
