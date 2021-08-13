using AutoMapper;
using EquipmentRental.BLL.DTO.Payment;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories;
using EquipmentRental.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services.Implementation
{
	public class PaymentService : IPaymentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IPaymentRepository _payments;

		public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_payments = unitOfWork.Payments;
		}

		public async Task<PaymentDTO> CreateAsync(CreatePaymentDTO payment)
		{
			var mapped = _mapper.Map<Payment>(payment);
			var result = await _payments.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<PaymentDTO>(result);
		}

		public async Task<PaymentDTO> DeleteAsync(int paymentId)
		{
			var payment = await _payments.GetByIdAsync(paymentId);
			if (payment != null)
			{
				var deleted = await _payments.DeleteAsync(payment);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<PaymentDTO>(payment);
			}

			return null;
		}

		public async Task<IEnumerable<PaymentDTO>> FindAllPaymentsAsync()
		{
			var payments = await _payments.GetAllAsync();
			return _mapper.Map<IEnumerable<PaymentDTO>>(payments);
		}

		public async Task<PaymentDTO> FindByIdAsync(int paymentId)
		{
			var payment = await _payments.GetByIdAsync(paymentId);
			return _mapper.Map<PaymentDTO>(payment);
		}

		public async Task<PaymentDTO> UpdateAsync(UpdatePaymentDTO paymentToUpdate)
		{
			var payment = await _payments.GetByIdAsync(paymentToUpdate.Id);
			payment = _mapper.Map(paymentToUpdate, payment);

			var updated = await _payments.UpdateAsync(payment);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<PaymentDTO>(updated);
		}
	}
}
