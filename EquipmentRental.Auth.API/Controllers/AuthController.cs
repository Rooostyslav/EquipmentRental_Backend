using EquipmentRental.Auth.Common;
using EquipmentRental.BLL.BusinessModels;
using EquipmentRental.BLL.DTO.User;
using EquipmentRental.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EquipmentRental.Auth.API.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IOptions<AuthOptions> _authOptions;
		private readonly IUserService _userService;

		public AuthController(IOptions<AuthOptions> authOptions,
			IUserService userService)
		{
			_authOptions = authOptions;
			_userService = userService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] Login login)
		{
			var user = await _userService.FindByLoginAsync(login);
			if (user == null)
			{
				return BadRequest("Error email or password!");
			}

			string token = GenerateJWT(user);
			return Ok(new { accessToken = token });
		}


		private string GenerateJWT(UserDTO user)
		{
			var authParams = _authOptions.Value;

			var securityKey = authParams.GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("role", user.RoleName)
			};

			var token = new JwtSecurityToken(authParams.Issuer,
				authParams.Audience,
				claims,
				expires: DateTime.Now.AddSeconds(authParams.Tokenlifetime),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
