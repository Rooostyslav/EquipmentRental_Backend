using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.BLL.DTO.Role
{
	public class CreateRoleDTO
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }
	}
}
