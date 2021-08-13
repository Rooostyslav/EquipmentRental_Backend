using EquipmentRental.BLL.DTO.Equipment;
using EquipmentRental.BLL.DTO.Payment;
using EquipmentRental.BLL.DTO.User;
using System;

namespace EquipmentRental.BLL.DTO.Order
{
	public class OrderDTO
	{
		public int Id { get; set; }

		public int EquipmentId { get; set; }

		public EquipmentDTO Equipment { get; set; }

		public int UserId { get; set; }

		public UserDTO User { get; set; }

		public int PaymentId { get; set; }

		public PaymentDTO Payment { get; set; }

		public DateTime From { get; set; }

		public DateTime To { get; set; }
	}
}
