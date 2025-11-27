using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeListLibrary.Models;

namespace AnimeListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeItemsController : ControllerBase
    {
        private readonly AnimeContext _context;

        public AnimeItemsController(AnimeContext context)
        {
            _context = context;
        }

        // GET: api/AnimeItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeItem>>> GetAnimeItems()
        {
            return await _context.AnimeItems.ToListAsync();
        }

        // GET: api/AnimeItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeItem>> GetAnimeItem(long id)
        {
            var animeItem = await _context.AnimeItems.FindAsync(id);

            if (animeItem == null)
            {
                return NotFound();
            }

            return animeItem;
        }

        // PUT: api/AnimeItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeItem(long id, AnimeItem animeItem)
        {
            if (id != animeItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(animeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeItemExists(id))
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

        // POST: api/AnimeItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimeItem>> PostAnimeItem(AnimeItem animeItem)
        {
            _context.AnimeItems.Add(animeItem);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetAnimeItem", new { id = animeItem.Id }, animeItem);
            return CreatedAtAction(nameof(GetAnimeItem), new { id = animeItem.Id }, animeItem);
        }

        // DELETE: api/AnimeItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeItem(long id)
        {
            var animeItem = await _context.AnimeItems.FindAsync(id);
            if (animeItem == null)
            {
                return NotFound();
            }

            _context.AnimeItems.Remove(animeItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeItemExists(long id)
        {
            return _context.AnimeItems.Any(e => e.Id == id);
        }
    }
}
