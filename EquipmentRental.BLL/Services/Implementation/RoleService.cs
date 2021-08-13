using AutoMapper;
using EquipmentRental.BLL.DTO.Role;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories;
using EquipmentRental.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services.Implementation
{
	public class RoleService : IRoleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IRoleRepository _roles;

		public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_roles = unitOfWork.Roles;
		}

		public async Task<RoleDTO> CreateAsync(CreateRoleDTO role)
		{
			var mapped = _mapper.Map<Role>(role);
			var result = await _roles.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<RoleDTO>(result);
		}

		public async Task<RoleDTO> DeleteAsync(int roleId)
		{
			var role = await _roles.GetByIdAsync(roleId);
			if (role != null)
			{
				var deleted = await _roles.DeleteAsync(role);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<RoleDTO>(role);
			}

			return null;
		}

		public async Task<IEnumerable<RoleDTO>> FindAllRolesAsync()
		{
			var roles = await _roles.GetAllAsync();
			return _mapper.Map<IEnumerable<RoleDTO>>(roles);
		}

		public async Task<RoleDTO> FindByIdAsync(int roleId)
		{
			var role = await _roles.GetByIdAsync(roleId);
			return _mapper.Map<RoleDTO>(role);
		}

		public async Task<RoleDTO> UpdateAsync(UpdateRoleDTO roleToUpdate)
		{
			var role = await _roles.GetByIdAsync(roleToUpdate.Id);
			role = _mapper.Map(roleToUpdate, role);

			var updated = await _roles.UpdateAsync(role);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<RoleDTO>(updated);
		}
	}
}
