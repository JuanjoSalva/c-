﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private List<Person> _people = new List<Person>();

        public PersonController()
        {
            _people.Add(new Person() { Id = 1, FirstName = "James", LastName = "Sprayberry" });
            _people.Add(new Person() { Id = 2, FirstName = "Jason", LastName = "Mosley" });
            _people.Add(new Person() { Id = 3, FirstName = "Jennifer", LastName = "Dietz" });
            _people.Add(new Person() { Id = 4, FirstName = "Bessie", LastName = "Duppstadt" });
        }

        [HttpGet]
        [Produces("application/xml")]
        public List<Person> GetAll()
        {
            return _people;
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        /*[HttpGet("GetById/{id}")]
        public IActionResult GetPById(int id)
        {
            string json = default;
            var person = _people.FirstOrDefault(Person => Person.Id == id);
            

            if (person!=null)
                var json = JsonSerializer.Serialize(person);
            else
                json = "{\"Id\":0, \"FirstName\":\"Not FOUND\"}";
            return Ok(json);
        }*/

    }
}
