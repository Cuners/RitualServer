using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrossController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public CrossController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getCrosses")]
        public async Task<ActionResult<IEnumerable<Cross>>> Get()
        {
            return await _ritualbdContext.Crosses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Cross>>> Get(int id)
        {
            Cross monument = await _ritualbdContext.Crosses.Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).FirstOrDefaultAsync(x => x.CrossId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Cross>> Post(Cross monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Crosses.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cross>> Put(Cross monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Crosses.Any(x => x.CrossId == monument.CrossId))
            {
                return NotFound();
            }
            _ritualbdContext.Crosses.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cross>> Delete(int id)
        {
            Cross monument = _ritualbdContext.Crosses.FirstOrDefault(x => x.CrossId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Crosses.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}