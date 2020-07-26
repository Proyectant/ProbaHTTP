using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProbaHTTP.Server;
using ProbaHTTP.Shared;

namespace ProbaHTTP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsobasController : ControllerBase
    {
        private readonly Baza _context;

        public OsobasController(Baza context)
        {
            _context = context;
        }

        // GET: api/Osobas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Osoba>>> GetOsobas()
        {
            return await _context.Osobas.ToListAsync();
        }

        // GET: api/Osobas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Osoba>> GetOsoba(int id)
        {
            var osoba = await _context.Osobas.FindAsync(id);

            if (osoba == null)
            {
                return NotFound();
            }

            return osoba;
        }

        // PUT: api/Osobas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOsoba(int id, Osoba osoba)
        {
            if (id != osoba.ID)
            {
                return BadRequest();
            }

            _context.Entry(osoba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsobaExists(id))
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

        // POST: api/Osobas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Osoba>> PostOsoba(Osoba osoba)
        {
            _context.Osobas.Add(osoba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOsoba", new { id = osoba.ID }, osoba);
        }

        // DELETE: api/Osobas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Osoba>> DeleteOsoba(int id)
        {
            var osoba = await _context.Osobas.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }

            _context.Osobas.Remove(osoba);
            await _context.SaveChangesAsync();

            return osoba;
        }

        private bool OsobaExists(int id)
        {
            return _context.Osobas.Any(e => e.ID == id);
        }
    }
}
