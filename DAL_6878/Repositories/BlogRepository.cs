using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW_6878.Models;

namespace WAD_CW_6878.Repositories
{
    public class BlogRepository : InsertUpdateRepo<Blog>, IRepository<Blog>
    {
        

        public async Task DeleteAsync(int id)
        {
            var blog = await dbContext.Blogs.FindAsync(id);
            dbContext.Blogs.Remove(blog);
            await dbContext.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return  dbContext.Blogs.Any(b => b.BlogId == id);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await dbContext.Blogs.Include(b => b.User).ToListAsync();
        }

        public async Task<Blog> FindAsync(int id)
        {
            return await dbContext.Blogs.Include(b => b.User).FirstOrDefaultAsync(m => m.BlogId == id);
        }

        public BlogRepository(BlogDBContext context) : base(context)
        {

        }
    }
}
