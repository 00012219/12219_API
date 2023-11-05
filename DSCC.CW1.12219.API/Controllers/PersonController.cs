using DSCC.CW1._12219.API.Models;
using DSCC.CW1._12219.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSCC.CW1._12219.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PersonController(IService<Person> personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_personService.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            _personService.Delete(id);
            return Ok(person);
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person) 
        {
            if (ModelState.IsValid)
            {
                _personService.Create(person);
                return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
            }

            return Ok(person);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person updatingPerson) 
        {
            if (id != updatingPerson.Id)
            {
                return BadRequest("User is not exists in database");
            }

            var existingOrder = _personService.GetById(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            // Update the properties of the existing order with the new values.
            existingOrder.Name = updatingPerson.Name;
            existingOrder.Email = updatingPerson.Email;
            existingOrder.City = updatingPerson.City;
            existingOrder.Country = updatingPerson.Country;
            existingOrder.Phone = updatingPerson.Phone;

            _personService.Update(existingOrder);
            return Ok(existingOrder);
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}
