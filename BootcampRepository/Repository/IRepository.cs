using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampRepository.Repository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
    }
}
