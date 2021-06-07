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
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Users.Any(m => m.UserId == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
        }

        public UserRepository(BlogDBContext context) : base(context)
        {

        }
    }
}
