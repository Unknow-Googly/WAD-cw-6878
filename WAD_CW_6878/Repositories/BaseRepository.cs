using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW_6878.Models;

namespace WAD_CW_6878.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly BlogDBContext _context;
        

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task InsertAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        protected BaseRepository(BlogDBContext context)
        {
            _context = context;
        }

    }
}
