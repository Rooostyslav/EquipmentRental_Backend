using EquipmentRental.BLL.DTO.Role;
using EquipmentRental.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.API.Controllers
{
	[ApiController]
	[Route("api/roles")]
	public class RolesController : ControllerBase
	{
		private readonly IRoleService _roleService;

		public RolesController(IRoleService roleService)
		{
			_roleService = roleService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetRoles()
		{
			var items = await _roleService.FindAllRolesAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetRoleById(int id)
		{
			var item = await _roleService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreateRole(
			[FromBody] CreateRoleDTO roleToCreate)
		{
			var result = await _roleService.CreateAsync(roleToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateRole(
			[FromBody] UpdateRoleDTO roleToUpdate)
		{
			var result = await _roleService.UpdateAsync(roleToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			await _roleService.DeleteAsync(id);
			return Ok();
		}
	}
}
