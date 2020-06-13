using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lcmsgapi.Models;

namespace lcmsgapi.Controllers
{
    [Route("api/lcmsg")]
    [ApiController]
    public class LCMsgController : ControllerBase
    {
        private readonly LCMsgContext _context;

        public LCMsgController(LCMsgContext context)
        {
            _context = context;
        }

        // GET: api/LCMsg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LCMsg>>> GetLCMsgs()
        {
            return await _context.LCMsgs.ToListAsync();
        }

        // GET: api/LCMsg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LCMsg>> GetLCMsg(long id)
        {
            var lCMsg = await _context.LCMsgs.FindAsync(id);

            if (lCMsg == null)
            {
                return NotFound();
            }

            return lCMsg;
        }

        // PUT: api/LCMsg/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLCMsg(long id, LCMsg lCMsg)
        {
            if (id != lCMsg.Id)
            {
                return BadRequest();
            }

            _context.Entry(lCMsg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LCMsgExists(id))
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

        // POST: api/LCMsg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LCMsg>> PostLCMsg(LCMsg lCMsg)
        {

            if (lCMsg.Username == null) return BadRequest();
            if (lCMsg.Content == null) return BadRequest();
            if (lCMsg.Id != null) return BadRequest();

            lCMsg.Id = Utils.IdGen.UnixMillis();

            _context.LCMsgs.Add(lCMsg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLCMsg", new { id = lCMsg.Id }, lCMsg);
        }

        // DELETE: api/LCMsg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LCMsg>> DeleteLCMsg(long id)
        {
            var lCMsg = await _context.LCMsgs.FindAsync(id);
            if (lCMsg == null)
            {
                return NotFound();
            }

            _context.LCMsgs.Remove(lCMsg);
            await _context.SaveChangesAsync();

            return lCMsg;
        }

        private bool LCMsgExists(long id)
        {
            return _context.LCMsgs.Any(e => e.Id == id);
        }
    }
}
