using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspbackend.model;

namespace aspbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        [HttpGet("username/{userName}")]
        public async Task<ActionResult<User>> GetUserByUserName(string userName){
            var user = await _context.Users.FirstOrDefaultAsync(name => name.UserName == userName);
            if(user == null){
                return NotFound();
            }
            return user;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = await _context.Users.FindAsync(id);
            if(existingUser == null){
                return NotFound();
            }

            if(user.UserName != existingUser.UserName){
                var usernameExists = await _context.Users.AnyAsync(usernameExists => usernameExists.UserName == user.UserName);
                if(usernameExists){
                    return BadRequest("Username is already take.");
                }
                existingUser.UserName = user.UserName;
            }

            if(!string.IsNullOrEmpty(user.Password) && user.Password != existingUser.Password){
                existingUser.Password = user.Password;
            }

            try
            {
                await _context.SaveChangesAsync();
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
            var UserExists = await _context.Users.FirstOrDefaultAsync(userExist => userExist.UserName == user.UserName);
            if(UserExists != null){
                return BadRequest("User Already Exist");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> LogIn(Login login){
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == login.LoginUserName);
            if (user == null){
                return NotFound();
            }
            if(user.Password != login.HashedPassword){
                return Unauthorized("Invalid Username or Password");
            }           
            return user;
        }
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
