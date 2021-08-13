using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.BLL.DTO.Order
{
	public class UpdateOrderDTO
	{
		public int Id { get; set; }

		[Required]
		public int EquipmentId { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int PaymentId { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime From { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime To { get; set; }
	}
}
