//https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio
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
    /// <summary>
    /// Api controller for the <see cref="User"/>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// database context
        /// </summary>
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Searches the database by the userName for the user 
        /// </summary>
        /// <param name="userName">the name for the User we are searching for</param>
        /// <returns>the user if found or a 404 notfound if it doesnt match the database</returns>
        [HttpGet("username/{userName}")]
        public async Task<ActionResult<User>> GetUserByUserName(string userName){
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions?view=efcore-9.0
            var user = await _context.Users.FirstOrDefaultAsync(name => name.UserName == userName);
            if(user == null){
                return NotFound();
            }
            return user;
        }

        // GET: api/Users/5
        /// <summary>
        /// Default get auto generated 
        /// used to get the user by their id
        /// </summary>
        /// <param name="id">the users id</param>
        /// <returns>the user if found or 404 notfound otherwise</returns>
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
        /// <summary>
        /// Used to change the users username or password
        /// </summary>
        /// <param name="id">the id of the user</param>
        /// <param name="user">The user we are changing</param>
        /// <returns>if successful it returns a 204 nocontent otherwise it returns a badrequest or a notfound</returns>
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
        /// <summary>
        /// Default post
        /// used to create a new user
        /// </summary>
        /// <param name="user">all the users information</param>
        /// <returns>the created user when successful and badrequest or 400 if user exist or an error occurs</returns>
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
        /// <summary>
        /// Used to check the login the user submits
        /// </summary>
        /// <param name="login">the users login they are trying to use to login</param>
        /// <returns>a 404 if user is not found a 401 if the user inputs the wrong password or the user if successful</returns>
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
        /// <summary>
        /// Default Delete auto generated
        /// Takes the user id and delets the user from the database and all their apps
        /// </summary>
        /// <param name="id">the user's id</param>
        /// <returns>nocontent if successful or notfound if it cant find the user</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            var apps = await _context.StoredPasswords.Where(storedPass => storedPass.UserId == id).ToListAsync();
            _context.StoredPasswords.RemoveRange(apps);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Default method
        /// used to check if a user exist
        /// </summary>
        /// <param name="id">user's id</param>
        /// <returns>the user if found else it returns null</returns>
        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
