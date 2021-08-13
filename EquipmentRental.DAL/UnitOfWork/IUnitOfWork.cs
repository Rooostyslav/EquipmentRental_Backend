using EquipmentRental.DAL.Repositories;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.UnitOfWork
{
	public interface IUnitOfWork
	{
		IEquipmentRepository Equipments { get; }

		IPaymentRepository Payments { get; }

		IOrderRepository Orders { get; }

		IUserRepository Users { get; }

		IRoleRepository Roles { get; }

		Task SaveAsync();
	}
}
