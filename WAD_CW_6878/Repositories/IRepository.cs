using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_6878.Repositories
{
    interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Boolean Exists(int id);
    }
}
