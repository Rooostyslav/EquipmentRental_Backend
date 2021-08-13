using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.DAL.Entity
{
	public class Equipment
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		[Column(Order = 3)]
		public double InitialPrice { get; set; }

		[Required]
		[Column(Order = 4)]
		public int UsefulLife { get; set; }

		[Required]
		[Column(Order = 5)]
		[DataType(DataType.DateTime)]
		public DateTime CreditTerm { get; set; }

		public virtual ICollection<Order> Orders { get; set; }

		public Equipment()
		{
			Orders = new Collection<Order>();
		}
	}
}
