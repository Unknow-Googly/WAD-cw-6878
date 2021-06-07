﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW_6878.Models;

namespace WAD_CW_6878.Repositories
{
    public abstract class InsertUpdateRepo<T> where T : class
    {
        protected readonly BlogDBContext _context;
        

        public async Task SaveChangesAsync(T entity)
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
        protected InsertUpdateRepo(BlogDBContext context)
        {
            _context = context;
        }

    }
}