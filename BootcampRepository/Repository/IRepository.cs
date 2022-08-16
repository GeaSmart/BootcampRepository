using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampRepository.Repository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<List<T>> ReadAllAsync();
        Task<T> ReadOneAsync(int id);
        Task UpdateAsync(T entity);
    }
}
