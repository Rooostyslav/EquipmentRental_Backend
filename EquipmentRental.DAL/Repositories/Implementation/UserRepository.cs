using EquipmentRental.DAL.EF;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories.Implementation
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly DbSet<User> _users;

		public UserRepository(EquipmentRentalContext equipmentRentalContext)
			: base(equipmentRentalContext)
		{
			_users = equipmentRentalContext.Users;
		}

		public override async Task<User> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(u => u.Id == id);
		}

		public override async Task<IEnumerable<User>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		private IQueryable<User> GetQueryWithIncludes()
		{
			return _users.Include(u => u.Role)
				.Include(u => u.Orders);
		}
	}
}
