using System;
using System.Collections.Generic;

namespace WebApi.WebApi.Models.Entity
{
    /// <summary>
    /// 2.2 - Класс человека/персоны (описывающий сущность для БД)
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }

        public IEnumerable<LibraryCard> LibraryCard { get; set; }
    }
}
