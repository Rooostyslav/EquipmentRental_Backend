using EquipmentRental.BLL.DTO.Equipment;
using EquipmentRental.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.API.Controllers
{
	[ApiController]
	[Route("api/equipments")]
	public class EquipmentsController : ControllerBase
	{
		private readonly IEquipmentService _equipmentService;

		public EquipmentsController(IEquipmentService equipmentService)
		{
			_equipmentService = equipmentService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetEquipments()
		{
			var items = await _equipmentService.FindAllEquipmentsAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetEquipmentById(int id)
		{
			var item = await _equipmentService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpGet("{id}/report")]
		public async Task<IActionResult> GetEquipmentReportInExcel(int id)
		{
			string filePath = await _equipmentService.GenerateReportInExcel(id);
			string fileType = "application/xlsx";
			string fileName = $"equipment{id}.xlsx";

			return PhysicalFile(filePath, fileType, fileName);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreateEquipment(
			[FromBody] CreateEquipmentDTO equipmentToCreate)
		{
			var result = await _equipmentService.CreateAsync(equipmentToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateEquipment(
			[FromBody] UpdateEquipmentDTO equipmentToUpdate)
		{
			var result = await _equipmentService.UpdateAsync(equipmentToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteEquipment(int id)
		{
			await _equipmentService.DeleteAsync(id);
			return Ok();
		}
	}
}
