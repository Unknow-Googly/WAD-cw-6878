using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_CW_6878.Models;

namespace WAD_CW_6878.Repositories
{
    public class BlogRepository : InsertUpdateRepo<Blog>, IRepository<Blog>
    {
        public Task InsertAsync(Blog entity)
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

        public Task<List<Blog>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Blog> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public BlogRepository(BlogDBContext context) : base(context)
        {

        }
    }
}
