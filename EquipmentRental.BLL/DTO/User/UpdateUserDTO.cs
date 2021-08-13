using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.BLL.DTO.User
{
	public class UpdateUserDTO
	{
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public int RoleId { get; set; }
	}
}
