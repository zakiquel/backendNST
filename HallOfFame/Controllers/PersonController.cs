using HallOfFame.Services;
using HallOfFame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HallOfFame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace HallOfFame.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonController : ControllerBase
{
    PersonService _service;
    public PersonController(PersonService service)
    {
        _service = service;
    }

    // GET: api/v1/persons Получение всех сотрудников
    [Route("~/api/v1/persons")]
    [HttpGet]
    public IEnumerable<Person> GetAll()
    {
        return _service.GetAll();
    }

    // GET: api/v1/person/id Получить конкретного сотрудника
    [HttpGet("{id}")]
    public ActionResult<Person> GetById(int id)
    {
        var person = _service.GetById(id);

        if(person is not null)
        {
            return person;
        }
        else
        {
            return NotFound();
        }
    }


    // POST: api/v1/person Добавление нового сотрудника
    [HttpPost]
    public IActionResult Create(Person newPerson)
    {
        var person = _service.Create(newPerson);
        return CreatedAtAction(nameof(GetById), new { id = person!.Id }, person);
    }
    

    // PUT: api/v1/person/id Обновление данных конкретного сотрудника
    [HttpPut("{id}")]
    public IActionResult Put(int id, Person updatedPerson)
    {
        if (id != updatedPerson.Id)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            errors["Others"] = "Неверный запрос";
            return BadRequest(errors);
        }

        _service.PutPerson(id, updatedPerson);

        return Ok();
    }


    // DELETE: api/v1/person/id  Удаление существующего сотрудника
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var person = _service.GetById(id);

        if(person is not null)
        {
            _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}