using EquipmentRental.BLL.DTO.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services
{
	public interface IEquipmentService
	{
		Task<IEnumerable<EquipmentDTO>> FindAllEquipmentsAsync();

		Task<EquipmentDTO> FindByIdAsync(int equipmentId);

		Task<EquipmentDTO> CreateAsync(CreateEquipmentDTO equipment);

		Task<EquipmentDTO> UpdateAsync(UpdateEquipmentDTO equipmentToUpdate);

		Task<EquipmentDTO> DeleteAsync(int equipmentId);

		Task<string> GenerateReportInExcel(int equipmentId);
	}
}
