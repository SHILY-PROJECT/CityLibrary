using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetHumansByLineQuery(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return ValidationProblem($"['{nameof(searchQuery)}' - не может быть нулевым или пустым.]");

            var queries = searchQuery.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            var result = DataStore.Humans
                .Where(x => queries
                .All(query => new[] { x.Name, x.Surname, x.Patronymic }
                .Any(xProperty => xProperty.Equals(query, StringComparison.OrdinalIgnoreCase)))).ToList();

            return Ok(result);
        }

        /// <summary>
        /// 1.3.2 - Добавление нового человека
        /// </summary>
        [HttpPost("addNewHumanToList")]
        public IActionResult PostAddHuman(HumanDto human)
        {
            var variables = new List<(string nameVar, string valueVar)>
            {
                (nameof(human.Name), human.Name), (nameof(human.Surname), human.Surname), (nameof(human.Patronymic), human.Patronymic)
            }
            .Where(x => string.IsNullOrWhiteSpace(x.valueVar) || x.valueVar == "string").ToList();

            if (variables.Count != 0)
                return ValidationProblem(string.Join(", ", variables.Select(x => $"['{x.nameVar}' - не может быть нулевым или пустым.]")));

            human.HumanId = (DataStore.Humans.Max(x => x.HumanId) + 1);
            DataStore.Humans.Add(human);

            if (!DataStore.Humans.Contains(human))
                return BadRequest("Не удалось добавить человека");

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
        [HttpDelete("deleteHumanFromList")]
        public IActionResult DeleteHuman(string name, string surname, string patronymic = "ignore", string birthday = "ignore")
        {
            var variables = new List<(string nameVar, string valueVar)>
            {
                (nameof(name), name), (nameof(surname), surname), (nameof(patronymic), patronymic), (nameof(birthday), birthday),
            }
            .Where(x => string.IsNullOrWhiteSpace(x.valueVar)).ToList();

            if (variables.Count != 0)
                return ValidationProblem(string.Join(", ", variables.Select(x => $"['{x.nameVar}' - не может быть нулевым или пустым.]")));

            for (int i = 0; i < DataStore.Humans.Count;)
            {
                var item = DataStore.Humans[i];

                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && item.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase))
                {
                    if (patronymic != "ignore" && !(item.Patronymic.Equals(patronymic, StringComparison.OrdinalIgnoreCase))) { i++; continue; }
                    if (birthday != "ignore" && !($"{item.Birthday:yyyy-MM-dd}".Equals(birthday))) { i++; continue; }

                    DataStore.Humans.RemoveAt(i);

                    return Ok("Человек успешно удален");
                }
                else i++;
            }

            return BadRequest("Не удалось удалить человека");
        }

    }
}
