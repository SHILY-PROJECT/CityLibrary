using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.Dto;
using SimbirSoftWorkshop.API.Models.Dto.Persons;

namespace SimbirSoftWorkshop.API.Controllers
{
    /// <summary>
    /// 2.7 - Контроллер пользователя
    /// </summary>
    [ApiController]
    [Route("Persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _iPersonRepository;

        public PersonsController(IPersonRepository iPersonRepository)
        {
            _iPersonRepository = iPersonRepository;
        }

        /// <summary>
        /// 2.7.1.5 - Получение списока всех взятых пользователем книг 
        /// </summary>
        [HttpGet("ListPersonBooks")]
        public IActionResult GetPersonBooks([FromQuery][Required] int personId)
        {
            var result = _iPersonRepository.GetPersonBooks(personId);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.1.1 - Добавить пользователя
        /// </summary>
        [HttpPost("AddNewPerson")]
        public IActionResult AddPerson([FromQuery] PersonDto person)
        {
            var result = _iPersonRepository.Add(person);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.1.6 - Получение книги пользователем
        /// </summary>
        [HttpPost("PersonTakeBook")]
        public IActionResult TakeBook([FromQuery] PersonBookDto personBook)
        {
            var result = _iPersonRepository.TakeBook(personBook);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok("Пользователью успешно выдана книга");
        }

        /// <summary>
        /// 2.7.1.7 - Возврат книги пользователем
        /// </summary>
        [HttpPost("PersonReturnBook")]
        public IActionResult ReturnBook([FromQuery] PersonBookDto personBook)
        {
            var result = _iPersonRepository.ReturnBook(personBook);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok("Пользователь успешно вернул книгу");
        }

        /// <summary>
        /// 2.7.1.2 - Обновление/изменение информации о пользователе
        /// </summary>
        [HttpPut("UpdatePersonInformation")]
        public IActionResult UpdatePerson([FromQuery] UpdatePersonDto personUpdateDto)
        {
            var result = _iPersonRepository.Update(personUpdateDto);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.1.3 - Удаление пользователя по идентификатору
        /// </summary>
        [HttpDelete("RemoveById")]
        public IActionResult DeletePerson([FromQuery][Required] int personId)
        {
            var result = _iPersonRepository.Delete(personId);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok("Пользователь успешно удален");
        }

        /// <summary>
        /// 2.7.1.4 - Удаление пользователя по ФИО
        /// </summary>
        [HttpDelete("RemoveByFullName")]
        public IActionResult DeletePerson([FromQuery] PersonDto person)
        {
            var result = _iPersonRepository.Delete(person);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok("Пользователь успешно удален");
        }

    }
}
