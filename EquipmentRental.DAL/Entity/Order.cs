using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.DAL.Entity
{
	public class Order
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		public int EquipmentId { get; set; }

		public virtual Equipment Equipment { get; set; }

		[Required]
		[Column(Order = 3)]
		public int UserId { get; set; }

		public virtual User User { get; set; }

		[Required]
		[Column(Order = 4)]
		public int PaymentId { get; set; }

		public virtual Payment Payment { get; set; }

		[Required]
		[Column(Order = 5)]
		[DataType(DataType.DateTime)]
		public DateTime From { get; set; }

		[Required]
		[Column(Order = 6)]
		[DataType(DataType.DateTime)]
		public DateTime To { get; set; }
	}
}
