using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.BLL.DTO.Payment
{
	public class CreatePaymentDTO
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Bank { get; set; }

		[Required]
		public int Amount { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Currency { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime PaymentTime { get; set; }
	}
}
