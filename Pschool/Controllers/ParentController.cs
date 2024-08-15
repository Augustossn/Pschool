using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PschoolCrud.Entities;
using PschoolCrud.Services;
using PschoolCrud.Services.Interfaces;

namespace Pschool.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParentController : ControllerBase
	{
		private readonly IParentService _parentService;

		public ParentController(ParentService parentService)
		{
			_parentService = parentService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Parent>>> GetParents()
		{
			return await _parentService.GetAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Parent>> GetById(int id)
		{
			var parent = await _parentService.GetById(id);
			return Ok(parent);
		}

		[HttpPost]
		public async Task<ActionResult<Parent>> Post(Parent parent)
		{
			var addedParent = await _parentService.Post(parent);
			return Ok(addedParent);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Parent>> Put(Parent parent, int id)
		{
			var updateParent = await _parentService.Put(parent, id);
			return Ok(updateParent);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var result = await _parentService.Delete(id);
			return Ok(result);
		}
	}
}
