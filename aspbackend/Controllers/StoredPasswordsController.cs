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
    /// api controller for the users apps they add
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StoredPasswordsController : ControllerBase
    {
        /// <summary>
        /// database context
        /// </summary>
        private readonly UserContext _context;

        public StoredPasswordsController(UserContext context)
        {
            _context = context;
        }
        // GET: api/StoredPasswords/5
        /// <summary>
        /// Default get by id auto generated
        /// searches the database for the app by id and returns it
        /// </summary>
        /// <param name="id">id for the app</param>
        /// <returns>the app or 404 not found</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StoredPassword>> GetStoredPassword(long id)
        {
            var storedPassword = await _context.StoredPasswords.FindAsync(id);

            if (storedPassword == null)
            {
                return NotFound();
            }

            return storedPassword;
        }
        /// <summary>
        /// custom get that uses userid
        /// searches for the app by the user's id and returns the app
        /// </summary>
        /// <param name="userId">the user's Id</param>
        /// <returns>a list of all the apps or 404 not found if the user has not apps</returns>
        [HttpGet("userid/{userId}")]
        public async Task<ActionResult<IEnumerable<StoredPassword>>> GetUserPasswords(long userId){
            var storedPasswords = await _context.StoredPasswords.Where(storedPass => storedPass.UserId == userId).ToListAsync();

            if(storedPasswords.Count == 0){
                return new List<StoredPassword>();
            }            
            
            return storedPasswords;
        }

        // PUT: api/StoredPasswords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Default put auto generated
        /// </summary>
        /// <param name="id">app's Id</param>
        /// <param name="storedPassword">the whole application</param>
        /// <returns>nocontent success if completed and a badrequest or not found otherwise</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoredPassword(long id, StoredPassword storedPassword)
        {
            if (id != storedPassword.Id)
            {
                return BadRequest();
            }

            _context.Entry(storedPassword).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoredPasswordExists(id))
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

        // POST: api/StoredPasswords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Default post auto generated
        /// Creates an app and returns it
        /// </summary>
        /// <param name="storedPassword">all the app information</param>
        /// <returns>the app if successful or a 400 if an error occurs</returns>
        [HttpPost]
        public async Task<ActionResult<StoredPassword>> PostStoredPassword(StoredPassword storedPassword)
        {
            _context.StoredPasswords.Add(storedPassword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoredPassword", new { id = storedPassword.Id }, storedPassword);
        }

        // DELETE: api/StoredPasswords/5
        /// <summary>
        /// Default delete auto generated
        /// Deletes an app by its id
        /// </summary>
        /// <param name="id">the id of the app</param>
        /// <returns>204 no content if successful or 404 notfound if it cant find the app by its id</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoredPassword(long id)
        {
            var storedPassword = await _context.StoredPasswords.FindAsync(id);
            if (storedPassword == null)
            {
                return NotFound();
            }

            _context.StoredPasswords.Remove(storedPassword);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Default method
        /// used to check if an app exists
        /// </summary>
        /// <param name="id">the app id </param>
        /// <returns>the app if found and null if not</returns>
        private bool StoredPasswordExists(long id)
        {
            return _context.StoredPasswords.Any(e => e.Id == id);
        }
    }
}
