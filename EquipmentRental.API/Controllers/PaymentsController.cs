using EquipmentRental.BLL.DTO.Payment;
using EquipmentRental.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.API.Controllers
{
	[ApiController]
	[Route("api/payments")]
	public class PaymentsController : ControllerBase
	{
		private readonly IPaymentService _paymentService;

		public PaymentsController(IPaymentService paymentService)
		{
			_paymentService = paymentService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetPayments()
		{
			var items = await _paymentService.FindAllPaymentsAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetPaymentById(int id)
		{
			var item = await _paymentService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreatePayment(
			[FromBody] CreatePaymentDTO PaymentToCreate)
		{
			var result = await _paymentService.CreateAsync(PaymentToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdatePayment(
			[FromBody] UpdatePaymentDTO PaymentToUpdate)
		{
			var result = await _paymentService.UpdateAsync(PaymentToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeletePayment(int id)
		{
			await _paymentService.DeleteAsync(id);
			return Ok();
		}
	}
}
