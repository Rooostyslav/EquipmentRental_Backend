using EquipmentRental.DAL.EF;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories.Implementation
{
	public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
	{
		private readonly DbSet<Equipment> _equipments;

		public EquipmentRepository(EquipmentRentalContext equipmentRentalContext)
			: base(equipmentRentalContext)
		{
			_equipments = equipmentRentalContext.Equipments;
		}

		public override async Task<IEnumerable<Equipment>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		private IQueryable<Equipment> GetQueryWithIncludes()
		{
			return _equipments.Include(e => e.Orders);
		}
	}
}
