using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.BLL.DTO.Role
{
	public class UpdateRoleDTO
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }
	}
}
