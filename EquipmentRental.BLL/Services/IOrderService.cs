using EquipmentRental.BLL.DTO.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderDTO>> FindAllOrdersAsync();

		Task<OrderDTO> FindByIdAsync(int orderId);

		Task<OrderDTO> CreateAsync(CreateOrderDTO order);

		Task<OrderDTO> UpdateAsync(UpdateOrderDTO orderToUpdate);

		Task<OrderDTO> DeleteAsync(int orderId);
	}
}
