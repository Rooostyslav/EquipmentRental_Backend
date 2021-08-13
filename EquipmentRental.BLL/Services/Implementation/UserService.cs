using AutoMapper;
using EquipmentRental.BLL.BusinessModels;
using EquipmentRental.BLL.DTO.User;
using EquipmentRental.BLL.Infrastructure;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories;
using EquipmentRental.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services.Implementation
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IUserRepository _users;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_users = unitOfWork.Users;
		}

		public async Task<UserDTO> CreateAsync(CreateUserDTO user)
		{
			var mapped = _mapper.Map<User>(user);
			mapped.Password = HashAlgorithm.CreateMD5(user.Password);

			var result = await _users.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<UserDTO>(result);
		}

		public async Task<UserDTO> DeleteAsync(int userId)
		{
			var user = await _users.GetByIdAsync(userId);
			if (user != null)
			{
				var deleted = await _users.DeleteAsync(user);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<UserDTO>(user);
			}

			return null;
		}

		public async Task<IEnumerable<UserDTO>> FindAllUsersAsync()
		{
			var users = await _users.GetAllAsync();
			return _mapper.Map<IEnumerable<UserDTO>>(users);
		}

		public async Task<UserDTO> FindByIdAsync(int userId)
		{
			var user = await _users.GetByIdAsync(userId);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> FindByLoginAsync(Login login)
		{
			var users = await _users.GetAllAsync();
			string passwordHash = HashAlgorithm.CreateMD5(login.Password);
			var user = users.FirstOrDefault(u => u.Email == login.Email && 
				u.Password == passwordHash);

			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> UpdateAsync(UpdateUserDTO userToUpdate)
		{
			var user = await _users.GetByIdAsync(userToUpdate.Id);
			user = _mapper.Map(userToUpdate, user);
			user.Password = HashAlgorithm.CreateMD5(userToUpdate.Password);

			var updated = await _users.UpdateAsync(user);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<UserDTO>(updated);
		}
	}
}
