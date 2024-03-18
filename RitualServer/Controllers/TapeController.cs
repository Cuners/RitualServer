using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapeController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public TapeController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getTapes")]
        public async Task<ActionResult<IEnumerable<Tape>>> Get()
        {
            return await _ritualbdContext.Tapes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Tape>>> Get(int id)
        {
            Tape monument = await _ritualbdContext.Tapes.Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).FirstOrDefaultAsync(x => x.TapeId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Tape>> Post(Tape monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Tapes.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tape>> Put(Tape monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Tapes.Any(x => x.TapeId == monument.TapeId))
            {
                return NotFound();
            }
            _ritualbdContext.Tapes.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tape>> Delete(int id)
        {
            Tape monument = _ritualbdContext.Tapes.FirstOrDefault(x => x.TapeId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Tapes.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
