using EquipmentRental.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetAllAsync();

		Task<Order> GetByIdAsync(int orderId);

		Task<Order> AddAsync(Order order);

		Task<Order> UpdateAsync(Order updatedOrder);

		Task<Order> DeleteAsync(Order order);
	}
}
