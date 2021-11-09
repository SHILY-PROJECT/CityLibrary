using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using SimbirSoftWorkshop.API.Models;

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
        [HttpGet("ListAllHumans")]
        public IActionResult GetAllHumans()
            => Ok(DataStore.Humans);

        /// <summary>
        /// 1.3.1.2. - Список людей, которые пишут книги
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListHumansIsAuthors")]
        public IActionResult GetHumansIsAuthors()
            => Ok(DataStore.Humans.Where(human
                => DataStore.Books.Any(book => book.Author.Contains(human.Name, StringComparison.OrdinalIgnoreCase)
                && book.Author.Contains(human.Surname, StringComparison.OrdinalIgnoreCase))).ToList());

        /// <summary>
        /// 1.3.1.3. - Список людей - результат поиска по фразе
        /// </summary>
        /// <param name="searchQuery">Поисковый запрос (фраза).</param>
        [HttpGet("ListHumansBySearchQuery")]
        public IActionResult GetHumansByLineQuery(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return ValidationProblem("Некорректная фраза запроса");

            var queries = searchQuery.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            var result = DataStore.Humans
                .Where(x => queries
                .All(query => new[] { x.Name, x.Surname, x.Patronymic }
                .Any(xProperty => xProperty.Contains(query, StringComparison.OrdinalIgnoreCase)))).ToList();

            return Ok(result);
        }

        /// <summary>
        /// 1.3.2 - Добавление нового человека
        /// </summary>
        [HttpPost("AddNewHuman")]
        public IActionResult PostAddHuman(HumanDto human)
        {
            DataStore.Humans.Add(human);

            if (!DataStore.Humans.Contains(human))
                return BadRequest("Не удалось добавить человека");

            return Ok("Человек успешно добавлен");
        }

        /// <summary>
        /// 1.3.3 - Удаление человека
        /// </summary>
        [HttpDelete("DeleteHuman")]
        public IActionResult DeleteHuman(HumanDto human, bool onlyFirstMatch = true, bool checkPatronymic = false, bool checkBirthday = false)
        {
            var atOneDeletionOrMany = false;

            for (int i = 0; i < DataStore.Humans.Count;)
            {
                var item = DataStore.Humans[i];

                if (item.Name.Contains(human.Name, StringComparison.OrdinalIgnoreCase) && item.Surname.Contains(human.Surname, StringComparison.OrdinalIgnoreCase))
                {
                    if (checkPatronymic && !(item.Patronymic.Contains(human.Patronymic, StringComparison.OrdinalIgnoreCase))) { i++; continue; }
                    if (checkBirthday && !($"{item.Birthday:yyyy-MM-dd}".Contains($"{human.Birthday:yyyy-MM-dd}"))) { i++; continue; }

                    DataStore.Humans.RemoveAt(i);
                    atOneDeletionOrMany = true;

                    if (onlyFirstMatch) break;
                }
                else i++;
            }

            return atOneDeletionOrMany ? Ok("Человек успешно удален") : BadRequest("Не удалось удалить человека");
        }

    }
}
