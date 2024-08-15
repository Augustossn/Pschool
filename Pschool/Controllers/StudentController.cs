using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PschoolCrud.Entities;
using PschoolCrud.Services;
using PschoolCrud.Services.Interfaces;

namespace Pschool.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;
	
		public StudentController(StudentService studentService)
		{
			_studentService = studentService;
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> GetById(int id)
		{
			var student = await _studentService.GetById(id);
			return Ok(student);
		}
		[HttpPost]
		public async Task<ActionResult<Student>> Post(Student student)
		{
			var addedStudent = await _studentService.Post(student);
			return Ok(addedStudent);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<Student>> Put(Student student, int id)
		{
			var updateStudent = await _studentService.Put(student, id);
			return Ok(updateStudent);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var result = await _studentService.Delete(id);
			return Ok(result);
		}
	}
}
