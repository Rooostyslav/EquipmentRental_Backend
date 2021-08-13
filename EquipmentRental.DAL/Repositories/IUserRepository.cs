using EquipmentRental.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllAsync();

		Task<User> GetByIdAsync(int userId);

		Task<User> AddAsync(User user);

		Task<User> UpdateAsync(User updatedUser);

		Task<User> DeleteAsync(User user);
	}
}
