using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.BLL.DTO.Equipment
{
	public class UpdateEquipmentDTO
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		public double InitialPrice { get; set; }

		[Required]
		public int UsefulLife { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime CreditTerm { get; set; }
	}
}
