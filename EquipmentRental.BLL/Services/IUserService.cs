using EquipmentRental.BLL.BusinessModels;
using EquipmentRental.BLL.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services
{
	public interface IUserService
	{
		Task<UserDTO> FindByLoginAsync(Login login);

		Task<IEnumerable<UserDTO>> FindAllUsersAsync();

		Task<UserDTO> FindByIdAsync(int userId);

		Task<UserDTO> CreateAsync(CreateUserDTO user);

		Task<UserDTO> UpdateAsync(UpdateUserDTO userToUpdate);

		Task<UserDTO> DeleteAsync(int userId);
	}
}
