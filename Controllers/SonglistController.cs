using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moment4_dt191g.Data;
using moment4_dt191g.Models;

namespace moment4_dt191g.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SonglistController : ControllerBase
    {
        private readonly SonglistDbContext _context;

        public SonglistController(SonglistDbContext context)
        {
            _context = context;
        }

        // GET: api/Songlist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SonglistModel>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Songlist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SonglistModel>> GetSonglistModel(int id)
        {
            var songlistModel = await _context.Songs.FindAsync(id);

            if (songlistModel == null)
            {
                return NotFound();
            }

            return songlistModel;
        }

        // PUT: api/Songlist/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSonglistModel(int id, SonglistModel songlistModel)
        {
            if (id != songlistModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(songlistModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SonglistModelExists(id))
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

        // POST: api/Songlist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SonglistModel>> PostSonglistModel(SonglistModel songlistModel)
        {
            _context.Songs.Add(songlistModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSonglistModel", new { id = songlistModel.Id }, songlistModel);
        }

        // DELETE: api/Songlist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSonglistModel(int id)
        {
            var songlistModel = await _context.Songs.FindAsync(id);
            if (songlistModel == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(songlistModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SonglistModelExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
