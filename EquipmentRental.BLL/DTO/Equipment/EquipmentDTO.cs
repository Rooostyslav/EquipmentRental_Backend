using System;

namespace EquipmentRental.BLL.DTO.Equipment
{
	public class EquipmentDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public double InitialPrice { get; set; }

		public DateTime CreditTerm { get; set; }

		public double Condition { get; set; }
	}
}
