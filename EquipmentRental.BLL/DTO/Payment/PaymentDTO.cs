using System;

namespace EquipmentRental.BLL.DTO.Payment
{
	public class PaymentDTO
	{
		public int Id { get; set; }

		public string Bank { get; set; }

		public int Amount { get; set; }

		public string Currency { get; set; }

		public DateTime PaymentTime { get; set; }
	}
}
