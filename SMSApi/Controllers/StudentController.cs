using SMSApi.Infrastructure;
using SMSApi.Models;
using SMSApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        /// <summary>
        /// Get all students.
        /// </summary>
        [HttpGet(Name = "GetAll")]
        public IActionResult GetAll()
        {
            var students = _student.GetAll();
            return new ObjectResult(students);
        }

        /// <summary>
        /// Get a student by ID.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve.</param>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var student = _student.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return new ObjectResult(student);
        }

        /// <summary>
        /// Create a new student.
        /// </summary>
        /// <param name="student">The student object to create.</param>
        [HttpPost(Name = "Create")]
        public IActionResult Create([FromBody] Student student)
        {
            student.CategorizeByAge();
            _student.InsertUpdateStudent(student);
            _student.Save();
            return CreatedAtRoute("Get", new { id = student.Id }, student);
        }

        /// <summary>
        /// Delete a student by ID.
        /// </summary>
        /// <param name="id">The ID of the student to delete.</param>
        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult Delete(int id)
        {
            var student = _student.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            _student.DeleteStudent(student);
            _student.Save();
            return NoContent();
        }
    }
}
