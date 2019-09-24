using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InstructorsListApp.Models;

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

        [HttpPost("add")]
        public IActionResult CreateInstructorEntry([FromBody] Instructor instructor) {
            if(ModelState.IsValid) {
                instructor.Id = Guid.NewGuid().ToString();
                databaseContext.Instructors.Add(instructor);
                databaseContext.SaveChangesAsync();
                return Ok(instructor.Id);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInstructorEntry(string id, [FromBody] Instructor instructor) {
            if(ModelState.IsValid) {
                databaseContext.Instructors.Update(instructor);
                databaseContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DelereInstructorEntry(string id) {
            Instructor instructor = databaseContext.Instructors.FirstOrDefault(i => i.Id == id);
            if(instructor != null) {
                databaseContext.Instructors.Remove(instructor);
                databaseContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("No such instructor");
        }
    }
}
