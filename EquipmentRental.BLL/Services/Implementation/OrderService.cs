using AutoMapper;
using EquipmentRental.BLL.DTO.Order;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories;
using EquipmentRental.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services.Implementation
{
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orders;

		public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_orders = unitOfWork.Orders;
		}

		public async Task<OrderDTO> CreateAsync(CreateOrderDTO order)
		{
			var mapped = _mapper.Map<Order>(order);
			var result = await _orders.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<OrderDTO>(result);
		}

		public async Task<OrderDTO> DeleteAsync(int orderId)
		{
			var order = await _orders.GetByIdAsync(orderId);
			if (order != null)
			{
				var deleted = await _orders.DeleteAsync(order);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<OrderDTO>(order);
			}

			return null;
		}

		public async Task<IEnumerable<OrderDTO>> FindAllOrdersAsync()
		{
			var orders = await _orders.GetAllAsync();
			return _mapper.Map<IEnumerable<OrderDTO>>(orders);
		}

		public async Task<OrderDTO> FindByIdAsync(int orderId)
		{
			var order = await _orders.GetByIdAsync(orderId);
			return _mapper.Map<OrderDTO>(order);
		}

		public async Task<OrderDTO> UpdateAsync(UpdateOrderDTO orderToUpdate)
		{
			var order = await _orders.GetByIdAsync(orderToUpdate.Id);
			order = _mapper.Map(orderToUpdate, order);

			var updated = await _orders.UpdateAsync(order);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<OrderDTO>(updated);
		}
	}
}
