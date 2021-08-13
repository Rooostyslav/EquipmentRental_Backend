using EquipmentRental.DAL.EF;
using EquipmentRental.DAL.Repositories;
using EquipmentRental.DAL.Repositories.Implementation;
using System;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EquipmentRentalContext _equipmentRentalContext;
		private IEquipmentRepository _equipmentRepository;
		private IPaymentRepository _paymentRepository;
		private IOrderRepository _orderRepository;
		private IUserRepository _userRepository;
		private IRoleRepository _roleRepository;

		public UnitOfWork(EquipmentRentalContext equipmentRentalContext)
		{
			_equipmentRentalContext = equipmentRentalContext;
		}

		public IEquipmentRepository Equipments
		{
			get
			{
				if (_equipmentRepository == null)
				{
					_equipmentRepository = new EquipmentRepository(_equipmentRentalContext);
				}

				return _equipmentRepository;
			}
		}

		public IPaymentRepository Payments
		{
			get
			{
				if (_paymentRepository == null)
				{
					_paymentRepository = new PaymentRepository(_equipmentRentalContext);
				}

				return _paymentRepository;
			}
		}

		public IOrderRepository Orders
		{
			get
			{
				if (_orderRepository == null)
				{
					_orderRepository = new OrderRepository(_equipmentRentalContext);
				}

				return _orderRepository;
			}
		}

		public IUserRepository Users
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserRepository(_equipmentRentalContext);
				}

				return _userRepository;
			}
		}

		public IRoleRepository Roles
		{
			get
			{
				if (_roleRepository == null)
				{
					_roleRepository = new RoleRepository(_equipmentRentalContext);
				}

				return _roleRepository;
			}
		}

		public async Task SaveAsync()
		{
			await _equipmentRentalContext.SaveChangesAsync();
		}
	}
}
