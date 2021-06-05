using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW_6878.Models;

namespace WAD_CW_6878.Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public Task CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserRepository(BlogDBContext context) : base(context)
        {

        }
    }
}
