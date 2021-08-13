using System;
using System.Security.Claims;

namespace EquipmentRental.API.UserClaims
{
	public static class UserInformation
	{
		public static int Id(this ClaimsPrincipal claims)
		{
			Int32.TryParse(claims
				.FindFirstValue(ClaimsIdentity.DefaultNameClaimType + "identifier"), out int id);
			return id;
		}
	}
}
