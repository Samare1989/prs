using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Modles;

namespace Prs_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestlinesController : ControllerBase
    {
        private readonly PrsDbContext _context;

        public RequestlinesController(PrsDbContext context)
        {
            _context = context;
        }

        // GET: api/Requestlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requestline>>> GetRequestlines()
        {
            return await _context.Requestlines.ToListAsync();
        }

        // GET: api/Requestlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requestline>> GetRequestline(int id)
        {
            var requestline = await _context.Requestlines.FindAsync(id);

            if (requestline == null)
            {
                return NotFound();
            }

            return requestline;
        }

        // PUT: api/Requestlines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestline(int id, Requestline requestline)
        {
            if (id != requestline.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                Recalculatetotal(requestline.RequestId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestlineExists(id))
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

        // POST: api/Requestlines
        [HttpPost]
        public async Task<ActionResult<Requestline>> PostRequestline(Requestline requestline)
        {
            _context.Requestlines.Add(requestline);
            await _context.SaveChangesAsync();
            Recalculatetotal(requestline.RequestId);
            return CreatedAtAction("GetRequestline", new { id = requestline.Id }, requestline);
        }

        // DELETE: api/Requestlines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Requestline>> DeleteRequestline(int id)
        {
            var requestline = await _context.Requestlines.FindAsync(id);
            if (requestline == null)
            {
                return NotFound();
            }

            _context.Requestlines.Remove(requestline);
            await _context.SaveChangesAsync();

            Recalculatetotal(requestline.RequestId);

            return requestline;
        }
        //This is for Requestline to calculate the total

        [HttpPut("/api/Requestsline/Review/{id}")]
        private bool Recalculatetotal(int requestId)
        {
            var request = _context.Requests.SingleOrDefault( r => r.Id == requestId);
            if(request== null)
            {
                return false;
            }

            request.Total = _context.Requestlines.Include(L=> L.Product)
                .Where(L=> L.RequestId == requestId).
                Sum(L => L.Quantity * L.Product.Price);

            _context.SaveChanges();

            return true;
        }


        private bool RequestlineExists(int id)
        {
            return _context.Requestlines.Any(e => e.Id == id);
        }
    }
}
