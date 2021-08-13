using EquipmentRental.DAL.EF;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories.Implementation
{
	public class OrderRepository : Repository<Order>, IOrderRepository
	{
		private readonly DbSet<Order> _orders;

		public OrderRepository(EquipmentRentalContext equipmentRentalContext)
			: base(equipmentRentalContext)
		{
			_orders = equipmentRentalContext.Orders;
		}

		public override async Task<Order> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(o => o.Id == id);
		}

		public override async Task<IEnumerable<Order>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		private IQueryable<Order> GetQueryWithIncludes()
		{
			return _orders.Include(o => o.Equipment)
				.Include(o => o.Payment)
				.Include(o => o.User);
		}
	}
}
