using EquipmentRental.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.DAL.EF
{
	public class EquipmentRentalContext : DbContext
	{
		public DbSet<Role> Roles { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<Equipment> Equipments { get; set; }

		public DbSet<Payment> Payments { get; set; }

		public EquipmentRentalContext(DbContextOptions<EquipmentRentalContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
