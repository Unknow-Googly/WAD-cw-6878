using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW_6878.Models;

namespace WAD_CW_6878.Repositories
{
    public abstract class InsertUpdateRepo<T> where T : class
    {
        protected readonly BlogDBContext dbContext;
        

        public async Task UpdateAsync(T entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task InsertAsync(T entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        protected InsertUpdateRepo(BlogDBContext context)
        {
            dbContext = context;
        }

    }
}
