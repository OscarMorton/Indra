using CapgeminiUnitOfWork.Infrastructure.Repository.DataContext.Generic;
using Indra.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<System.Collections.Generic.IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await _unitOfWork.Context.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> RemoveByIdAsync(int id)
        {
            var dbEntity = await _unitOfWork.Context.Set<T>().FindAsync(id);
            if (dbEntity != null)
            {
                _unitOfWork.Context.Remove(dbEntity);
                return dbEntity;
            }
            return null;
        }

        public virtual Task<T> UpdateAsync(int id, T identity)
        {
            throw new System.NotImplementedException();
        }
    }
}