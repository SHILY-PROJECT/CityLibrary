using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Models;
using System.ComponentModel.DataAnnotations;

namespace SimbirSoftWorkshop.API.Controllers
{
    /// <summary>
    /// 1.3 - Контроллер человека
    /// </summary>
    [ApiController]
    [Route("Human")]
    public class HumanController : ControllerBase
    {
        /// <summary>
        /// 1.3.1.1 - Список всех людей
        /// </summary>
        [HttpGet("listAllHumans")]
        public IActionResult GetAllHumans()
            => Ok(DataStore.Humans);

        /// <summary>
        /// 1.3.1.2. - Список людей, которые пишут книги
        /// </summary>
        /// <returns></returns>
        [HttpGet("listHumansIsAuthors")]
        public IActionResult GetHumansIsAuthors()
            => Ok(DataStore.Humans.Where(human => DataStore.Books.Any(book
                => book.Author.Equals($"{human.Name} {human.Surname}", StringComparison.OrdinalIgnoreCase))).ToList());

        /// <summary>
        /// 1.3.1.3. - Список людей - результат поиска по фразе
        /// </summary>
        /// <param name="searchQuery">Поисковый запрос (фраза).</param>
        [HttpGet("listHumansBySearchQuery")]
        public IActionResult GetHumansByQuery(
            [Required][StringLength(1000, MinimumLength = 1)]
            [RegularExpression(@"[A-Za-zА-Яа-я0-9\s-]+", ErrorMessage = "The string can contain only Cyrillic, Latin and whitespace characters.")]
            string searchQuery)
        {
            var queries = searchQuery.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            var result = DataStore.Humans
                .Where(x => queries
                .All(query => new[] { x.Name, x.Surname, x.Patronymic, x.Birthday.ToString("yyyy-MM-dd") }
                .Any(xProperty => xProperty.Contains(query, StringComparison.OrdinalIgnoreCase)))).ToList();

            return Ok(result);
        }

        /// <summary>
        /// 1.3.2 - Добавление нового человека
        /// </summary>
        [HttpPost("addNewHumanToList")]
        public IActionResult PostAddHuman([Required][FromQuery] HumanDto human)
        {
            var humanDetail = (HumanDetailDto)human;
            humanDetail.Id = (DataStore.Humans.Max(x => x.Id) + 1);
            DataStore.Humans.Add(humanDetail);

            return Ok("Человек успешно добавлен");
        }

        /// <summary>
        /// 1.3.3 - Удаление человека
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="patronymic">Отчество (если свойство нужно игнорировать, то установите: ignore)</param>
        /// <param name="birthday">Дата рождения (формат: yyyy-MM-dd) (если свойство нужно игнорировать, то установите: ignore)</param>
        /// <returns></returns>
        [HttpDelete("removingHumanFromList")]
        public IActionResult DeleteHuman([Required] long humanId)
        {
            for (int i = 0; i < DataStore.Humans.Count;)
            {
                if (DataStore.Humans[i].Id == humanId)
                {
                    DataStore.Humans.RemoveAt(i);
                    return Ok("Человек успешно удален");
                }
                else i++;
            }

            return BadRequest("Не удалось удалить человека");
        }

        private static string NormalizeNamingCase(string nameOrSurnameOrPatronymic)
            => string.Join(" ", nameOrSurnameOrPatronymic.Split(' ')
                .Select(x => new string(x.Select((value, index) => index == 0 ? char.ToUpper(value) : char.ToLower(value)).ToArray())));
    }
}
