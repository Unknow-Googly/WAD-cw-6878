using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_6878.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        Task SaveChangesAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> FindAsync(int id);
        Task<List<T>> GetAll();
        Boolean Exists(int id);
    }
}
