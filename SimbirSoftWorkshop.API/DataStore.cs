using System;
using System.Collections.Generic;
using SimbirSoftWorkshop.API.Models;

namespace SimbirSoftWorkshop.API
{
    internal class DataStore
    {
        /// <summary>
        /// 1.2.3 - Список людей
        /// </summary>
        internal static List<HumanDto> Humans = new()
        {
            new()
            {
                Name = "Alexander",
                Surname = "Statskov",
                Patronymic = "Dmitrievich",
                Birthday = new(1983, 03, 12),
                HumanId = 1
            },
            new()
            {
                Name = "Igor",
                Surname = "Izmailov",
                Patronymic = "Innokentievich",
                Birthday = new(1978, 11, 27),
                HumanId = 2
            },
            new()
            {
                Name = "Eliezer",
                Surname = "Yudkowsky",
                Patronymic = "Shlomo",
                Birthday = new(1979, 09, 11),
                HumanId = 3
            },
            new()
            {
                Name = "Yana",
                Surname = "Sharkelova",
                Patronymic = "Egorovna",
                Birthday = new(1992, 05, 06),
                HumanId = 4
            },
            new()
            {
                Name = "Igor",
                Surname = "Premin",
                Patronymic = "Olegovych",
                Birthday = new(1978, 11, 27),
                HumanId = 5
            }
        };

        /// <summary>
        /// 1.2.3 - Список книг
        /// </summary>
        internal static List<BookDto> Books = new()
        {
            new()
            {
                Title = "Harry Potter and the Methods of Rationality",
                Author = "Eliezer Yudkowsky",
                Genre = "Fantasy",
                AuthorId = 1
            },
            new()
            {
                Title = "The Demon-Haunted World: Science as a Candle in the Dark",
                Author = "Carl Sagan",
                Genre = "Scientific literature",
                AuthorId= 2
            },
            new()
            {
                Title = "The Brain's Way of Healing: Remarkable Discoveries and Recoveries from the Frontiers of Neuroplasticity",
                Author = "Norman Doidge",
                Genre = "Self-development literature",
                AuthorId = 3
            },
            new()
            {
                Title = "Contact",
                Author = "Carl Sagan",
                Genre = "Science fiction",
                AuthorId = 2
            }
        };

        /// <summary>
        /// 2.1.3 - Список библиотечных карточек
        /// </summary>
        internal static List<LibraryCardDto> LibraryCards = new();
    }
}
