using EquipmentRental.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories
{
	public interface IRoleRepository
	{
		Task<IEnumerable<Role>> GetAllAsync();

		Task<Role> GetByIdAsync(int roleId);

		Task<Role> AddAsync(Role role);

		Task<Role> UpdateAsync(Role updatedRole);

		Task<Role> DeleteAsync(Role role);
	}
}
