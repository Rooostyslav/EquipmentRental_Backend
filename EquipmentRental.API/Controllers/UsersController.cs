using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EquipmentRental.BLL.Services;
using System.Threading.Tasks;
using EquipmentRental.BLL.DTO.User;
using EquipmentRental.API.UserClaims;
using Microsoft.AspNetCore.Authorization;

namespace EquipmentRental.API.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetUsers()
		{
			var items = await _userService.FindAllUsersAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetUserById(int id)
		{
			var item = await _userService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpGet("my")]
		[Authorize]
		public async Task<IActionResult> GetMyUser()
		{
			int myId = User.Id();
			var myUser = await _userService.FindByIdAsync(myId);

			if (myUser != null)
			{
				return Ok(myUser);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateUser(
			[FromBody] CreateUserDTO userToCreate)
		{
			var result = await _userService.CreateAsync(userToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateUser(
			[FromBody] UpdateUserDTO userToUpdate)
		{
			var result = await _userService.UpdateAsync(userToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _userService.DeleteAsync(id);
			return Ok();
		}
	}
}
