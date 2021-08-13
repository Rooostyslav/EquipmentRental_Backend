using EquipmentRental.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.DAL.Repositories.Common
{
	public abstract class Repository<TEntity> where TEntity : class
	{
		private readonly EquipmentRentalContext _context;

		public Repository(EquipmentRentalContext equipmentRentalContext)
		{
			_context = equipmentRentalContext;
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public virtual async Task<TEntity> GetByIdAsync(int id)
		{
			return await _context.FindAsync<TEntity>(id);
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			var entityEntry = await _context.AddAsync(entity);
			return entityEntry.Entity;
		}

		public async Task<TEntity> UpdateAsync(TEntity updatedEntity)
		{
			var resultEntity = _context.Update(updatedEntity).Entity;
			await Task.CompletedTask;
			return resultEntity;
		}

		public virtual async Task<TEntity> DeleteAsync(TEntity entity)
		{
			await Task.CompletedTask;
			return _context.Remove(entity).Entity;
		}
	}
}
