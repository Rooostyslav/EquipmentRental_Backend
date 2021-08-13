using EquipmentRental.BLL.DTO.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services
{
	public interface IRoleService
	{
		Task<IEnumerable<RoleDTO>> FindAllRolesAsync();

		Task<RoleDTO> FindByIdAsync(int roleId);

		Task<RoleDTO> CreateAsync(CreateRoleDTO role);

		Task<RoleDTO> UpdateAsync(UpdateRoleDTO roleToUpdate);

		Task<RoleDTO> DeleteAsync(int roleId);
	}
}
