using EquipmentRental.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories
{
	public interface IEquipmentRepository
	{
		Task<IEnumerable<Equipment>> GetAllAsync();

		Task<Equipment> GetByIdAsync(int equipmentId);

		Task<Equipment> AddAsync(Equipment equipment);

		Task<Equipment> UpdateAsync(Equipment updatedEquipment);

		Task<Equipment> DeleteAsync(Equipment equipment);
	}
}
