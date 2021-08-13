using EquipmentRental.API.UserClaims;
using EquipmentRental.BLL.DTO.Order;
using EquipmentRental.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.API.Controllers
{
	[ApiController]
	[Route("api/orders")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetOrders()
		{
			var items = await _orderService.FindAllOrdersAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetOrderById(int id)
		{
			var item = await _orderService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpGet("my")]
		[Authorize]
		public async Task<IActionResult> GetMyOrders()
		{
			int myId = User.Id();
			var orders = await _orderService.FindAllOrdersAsync();
			var myOrders = orders.Where(o => o.UserId == myId);

			if (myOrders.Count() > 0)
			{
				return Ok(myOrders);
			}

			return NoContent();
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Createorder(
			[FromBody] CreateOrderDTO orderToCreate)
		{
			var result = await _orderService.CreateAsync(orderToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Updateorder(
			[FromBody] UpdateOrderDTO orderToUpdate)
		{
			var result = await _orderService.UpdateAsync(orderToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Deleteorder(int id)
		{
			await _orderService.DeleteAsync(id);
			return Ok();
		}
	}
}
