using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Services;
using StudentManagement.API.Models;

namespace StudentManagement.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService) {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var students = _studentService.GetAll();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var student = _studentService.GetById(id);

            if(student == null) {
                return NotFound("Student Not Found!");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Student student) {
            var addedStudent = _studentService.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = addedStudent.ID }, addedStudent);
        }
    }
}
