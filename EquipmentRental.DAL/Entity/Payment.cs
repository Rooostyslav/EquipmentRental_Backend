using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.DAL.Entity
{
	public class Payment
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Bank { get; set; }

		[Required]
		[Column(Order = 3)]
		public int Amount { get; set; }

		[Required]
		[Column(Order = 4)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Currency { get; set; }

		[Required]
		[Column(Order = 5)]
		[DataType(DataType.DateTime)]
		public DateTime PaymentTime { get; set; }

		public virtual ICollection<Order> Orders { get; set; }

		public Payment()
		{
			Orders = new Collection<Order>();
		}
	}
}
