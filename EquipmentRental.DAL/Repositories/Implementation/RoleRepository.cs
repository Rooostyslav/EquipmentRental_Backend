using EquipmentRental.DAL.EF;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories.Implementation
{
	public class RoleRepository : Repository<Role>, IRoleRepository
	{
		private readonly DbSet<Role> _roles;

		public RoleRepository(EquipmentRentalContext equipmentRentalContext)
			: base(equipmentRentalContext)
		{
			_roles = equipmentRentalContext.Roles;
		}

		public override async Task<IEnumerable<Role>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		private IQueryable<Role> GetQueryWithIncludes()
		{
			return _roles.Include(r => r.Users);
		}
	}
}
