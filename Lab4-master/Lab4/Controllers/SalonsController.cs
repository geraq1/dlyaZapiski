using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab4.DAL;
using Lab4.Domain;

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Salons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetAddress()
        {
            return await _context.Salon.ToListAsync();
        }

        // GET: api/Salons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salon>> GetSalon(int id)
        {
            var salon = await _context.Salon.FindAsync(id);

            if (salon == null)
            {
                return NotFound();
            }

            return salon;
        }

        // PUT: api/Salons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalon(int id, Salon salon)
        {
            if (id != salon.Id)
            {
                return BadRequest();
            }

            _context.Entry(salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(id))
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

        // POST: api/Salons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salon>> PostSalon(Salon salon)
        {
            await _context.Salon.AddAsync(salon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalon", new { id = salon.Id }, salon);
        }

        // DELETE: api/Salons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalon(int id)
        {
            var salon = await _context.Salon.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            _context.Salon.Remove(salon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalonExists(int id)
        {
            return _context.Salon.Any(e => e.Id == id);
        }
    }
}
