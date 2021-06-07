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
    public class UsersController : ControllerBase
    {
        //private readonly BlogDBContext userRepository;
        private IRepository<User> userRepository;

        public UsersController(IRepository<User> context)
        {
            userRepository = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var all = await userRepository.GetAll();

            return all;
            //return await userRepository.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await userRepository.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            //userRepository.Entry(user).State = EntityState.Modified;

            try
            {
                await userRepository.SaveChangesAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            //userRepository.Users.Add(user);
            await userRepository.InsertAsync(user);

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userRepository.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await userRepository.DeleteAsync(id);
            //await userRepository.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return userRepository.Exists(id);
        }
    }
}
