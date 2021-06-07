using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW_6878.Models;

namespace WAD_CW_6878.Repositories
{
    public class UserRepository : InsertUpdateRepo<User>, IRepository<User>
    {
       
        public async Task DeleteAsync(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return dbContext.Users.Any(m => m.UserId == id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> FindAsync(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(m => m.UserId == id);
        }

        public UserRepository(BlogDBContext context) : base(context)
        {

        }
    }
}
