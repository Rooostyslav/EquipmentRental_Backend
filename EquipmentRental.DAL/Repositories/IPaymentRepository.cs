using EquipmentRental.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories
{
	public interface IPaymentRepository
	{
		Task<IEnumerable<Payment>> GetAllAsync();

		Task<Payment> GetByIdAsync(int paymentId);

		Task<Payment> AddAsync(Payment payment);

		Task<Payment> UpdateAsync(Payment updatedPayment);

		Task<Payment> DeleteAsync(Payment payment);
	}
}
