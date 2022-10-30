using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn.Entities;
using DoAn.Services;

namespace DoAn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericShoesController : ControllerBase
    {
        private readonly Context _context;

        public GenericShoesController(Context context)
        {
            _context = context;
        }

        // GET: api/GenericShoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenericShoes>>> GetGenericShoes()
        {
            return await _context.GenericShoes.ToListAsync();
        }

        // GET: api/GenericShoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenericShoes>> GetGenericShoes(int id)
        {
            var genericShoes = await _context.GenericShoes.FindAsync(id);

            if (genericShoes == null)
            {
                return NotFound();
            }

            return genericShoes;
        }

        // PUT: api/GenericShoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenericShoes(int id, GenericShoes genericShoes)
        {
            if (id != genericShoes.GenericShoesID)
            {
                return BadRequest();
            }

            _context.Entry(genericShoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenericShoesExists(id))
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

        // POST: api/GenericShoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenericShoes>> PostGenericShoes(GenericShoes genericShoes)
        {
            _context.GenericShoes.Add(genericShoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenericShoes", new { id = genericShoes.GenericShoesID }, genericShoes);
        }

        // DELETE: api/GenericShoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenericShoes(int id)
        {
            var genericShoes = await _context.GenericShoes.FindAsync(id);
            if (genericShoes == null)
            {
                return NotFound();
            }

            _context.GenericShoes.Remove(genericShoes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenericShoesExists(int id)
        {
            return _context.GenericShoes.Any(e => e.GenericShoesID == id);
        }
    }
}
