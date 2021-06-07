using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_6878.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> FindAsync(int id);
        Task<List<T>> GetAllAsync();
        Boolean Exists(int id);
    }
}
