using EquipmentRental.DAL.EF;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories.Implementation
{
	public class PaymentRepository : Repository<Payment>, IPaymentRepository
	{
		private readonly DbSet<Payment> _payments;

		public PaymentRepository(EquipmentRentalContext equipmentRentalContext)
			: base(equipmentRentalContext)
		{
			_payments = equipmentRentalContext.Payments;
		}

		public override async Task<IEnumerable<Payment>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		private IQueryable<Payment> GetQueryWithIncludes()
		{
			return _payments.Include(p => p.Orders);
		}
	}
}
