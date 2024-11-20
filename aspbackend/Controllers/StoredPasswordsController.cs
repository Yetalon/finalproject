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
    public class StoredPasswordsController : ControllerBase
    {
        private readonly UserContext _context;

        public StoredPasswordsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/StoredPasswords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoredPassword>>> GetStoredPasswords()
        {
            return await _context.StoredPasswords.ToListAsync();
        }

        // GET: api/StoredPasswords/5
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
        [HttpPost]
        public async Task<ActionResult<StoredPassword>> PostStoredPassword(StoredPassword storedPassword)
        {
            _context.StoredPasswords.Add(storedPassword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoredPassword", new { id = storedPassword.Id }, storedPassword);
        }

        // DELETE: api/StoredPasswords/5
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

        private bool StoredPasswordExists(long id)
        {
            return _context.StoredPasswords.Any(e => e.Id == id);
        }
    }
}
