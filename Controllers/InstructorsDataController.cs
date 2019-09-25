using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InstructorsListApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InstructorsListApp.Controllers
{
    [Route("api/v1/instructors")]
    [ApiController]
    public class InstructorsDataController : Controller
    {
        DatabaseContext databaseContext;

        public InstructorsDataController(DatabaseContext context)
        {
            databaseContext = context;
        }

        [HttpGet]
        public IEnumerable<Instructor> GetAllInstructors()
        {
            return databaseContext.Instructors.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetInstructorByID(string id) {
            var instructor = databaseContext.Instructors.FirstOrDefault(i => i.Id == id);
            if(instructor != null) {
                databaseContext.Entry<Instructor>(instructor).State = EntityState.Detached; // remove unneccessary refs
                return Ok(instructor);
            }
            return NotFound("Given instructor isn't found");
        }

        [HttpPost("add")]
        public IActionResult CreateInstructorEntry([FromBody] Instructor instructor) {
            if(ModelState.IsValid) {
                instructor.Id = Guid.NewGuid().ToString();
                databaseContext.Instructors.Add(instructor);
                databaseContext.SaveChanges();
                return Ok(instructor.Id);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInstructorEntry(string id, [FromBody] Instructor instructor) {
            if(ModelState.IsValid) {
                instructor.Id = id;
                var instructorEntry = databaseContext.Instructors.FirstOrDefault(i => i.Id == id);
                if(instructorEntry != null) {
                    databaseContext.Entry<Instructor>(instructorEntry).State = EntityState.Detached; // remove unneccessary refs
                    databaseContext.Instructors.Update(instructor);
                    databaseContext.SaveChanges();
                    return Ok();
                }
                return NotFound("Given instructor isn't found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DelereInstructorEntry(string id) {
            Instructor instructor = databaseContext.Instructors.FirstOrDefault(i => i.Id == id);
            if(instructor != null) {
                databaseContext.Instructors.Remove(instructor);
                databaseContext.SaveChanges();
                return Ok();
            }
            return NotFound("No such instructor");
        }
    }
}
