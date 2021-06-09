using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_CW_6878.Models;
using WAD_CW_6878.Repositories;

namespace WAD_CW_6878.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        //private readonly BlogDBContext _context;

        private IRepository<Blog> blogRepository;
        public BlogsController(IRepository<Blog> context)
        {
            //_context = context;
            blogRepository = context;

        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await blogRepository.GetAllAsync();//_context.Blogs.ToListAsync();
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await blogRepository.FindAsync(id);//_context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.BlogId)
            {
                return BadRequest();
            }

            //_context.Entry(blog).State = EntityState.Modified;

            try
            {
                await blogRepository.UpdateAsync(blog);//_context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            //_context.Blogs.Add(blog);
            await blogRepository.InsertAsync(blog);//_context.SaveChangesAsync();

            return CreatedAtAction("GetBlog", new { id = blog.BlogId }, blog);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = blogRepository.FindAsync(id);//await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            //_context.Blogs.Remove(blog);
            await blogRepository.DeleteAsync(id);//_context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogExists(int id)
        {
            return blogRepository.Exists(id);//_context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
