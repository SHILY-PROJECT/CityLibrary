using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SimbirSoftWorkshop.API.Interfaces;
using SimbirSoftWorkshop.API.Models.DatabaseModels;
using SimbirSoftWorkshop.API.Models.ViewModel;

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
            try
            {
                return Ok(_iPersonRepository.GetPersonBooks(personId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.1.1 - Добавить пользователя
        /// </summary>
        [HttpPost("AddNewPerson")]
        public IActionResult AddPerson([FromQuery] FullNameDto fullName, [FromQuery] DateTime birthDate = default)
        {
            try
            {
                return Ok(_iPersonRepository.Add(fullName, birthDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.1.6 - Получение книги пользователем
        /// </summary>
        [HttpPost("PersonTakeBook")]
        public IActionResult TakeBook([FromQuery][Required] int bookId, [FromQuery][Required] int personId)
        {
            try
            {
                _iPersonRepository.TakeBook(bookId, personId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Пользователью успешно выдана книга");
        }

        /// <summary>
        /// 2.7.1.7 - Возврат книги пользователем
        /// </summary>
        [HttpPost("PersonReturnBook")]
        public IActionResult ReturnBook([FromQuery][Required] int bookId, [FromQuery][Required] int personId)
        {
            try
            {
                _iPersonRepository.ReturnBook(bookId, personId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Пользователь успешно вернул книгу");
        }

        /// <summary>
        /// 2.7.1.2 - Обновление/изменение информации о пользователе
        /// </summary>
        [HttpPut("UpdatePersonInformation")]
        public IActionResult UpdatePerson([FromQuery] PersonUpdateDto personUpdateDto)
        {
            try
            {
                return Ok(_iPersonRepository.Update(personUpdateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 2.7.1.3 - Удаление пользователя по идентификатору
        /// </summary>
        [HttpDelete("RemoveById")]
        public IActionResult DeletePerson([FromQuery][Required] int personId)
        {
            try
            {
                _iPersonRepository.Delete(personId);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok("Пользователь успешно удален");
        }

        /// <summary>
        /// 2.7.1.4 - Удаление пользователя по ФИО
        /// </summary>
        [HttpDelete("RemoveByFullName")]
        public IActionResult DeletePerson([FromQuery] FullNameDto fullName)
        {
            try
            {
                _iPersonRepository.Delete(fullName.FirstName, fullName.LastName, fullName.MiddleName);
            }
            catch(Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok("Пользователь успешно удален");
        }

    }
}
