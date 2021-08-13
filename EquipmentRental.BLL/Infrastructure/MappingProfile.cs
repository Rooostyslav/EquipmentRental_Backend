using AutoMapper;
using EquipmentRental.BLL.DTO.Equipment;
using EquipmentRental.BLL.DTO.Order;
using EquipmentRental.BLL.DTO.Payment;
using EquipmentRental.BLL.DTO.Role;
using EquipmentRental.BLL.DTO.User;
using EquipmentRental.DAL.Entity;

namespace EquipmentRental.BLL.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//User
			CreateMap<User, UserDTO>()
				.ForMember(desc => desc.RoleName, opt => opt.MapFrom(u => u.Role.Name));
			CreateMap<CreateUserDTO, User>();
			CreateMap<UpdateUserDTO, User>();

			//Role
			CreateMap<Role, RoleDTO>();
			CreateMap<CreateRoleDTO, Role>();
			CreateMap<UpdateRoleDTO, Role>();

			//Payment
			CreateMap<Payment, PaymentDTO>();
			CreateMap<CreatePaymentDTO, Payment>();
			CreateMap<UpdatePaymentDTO, Payment>();

			//Order
			CreateMap<Order, OrderDTO>();
			CreateMap<CreateOrderDTO, Order>();
			CreateMap<UpdateOrderDTO, Order>();

			//Equipment
			CreateMap<Equipment, EquipmentDTO>();
			CreateMap<CreateEquipmentDTO, Equipment>();
			CreateMap<UpdateEquipmentDTO, Equipment>();
		}
	}
}
