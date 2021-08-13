using EquipmentRental.BLL.DTO.Payment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services
{
	public interface IPaymentService
	{
		Task<IEnumerable<PaymentDTO>> FindAllPaymentsAsync();

		Task<PaymentDTO> FindByIdAsync(int paymentId);

		Task<PaymentDTO> CreateAsync(CreatePaymentDTO payment);

		Task<PaymentDTO> UpdateAsync(UpdatePaymentDTO paymentToUpdate);

		Task<PaymentDTO> DeleteAsync(int paymentId);
	}
}
