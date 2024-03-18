using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffinController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public CoffinController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getCoffins")]
        public async Task<ActionResult<IEnumerable<Coffin>>> Get()
        {
            return await _ritualbdContext.Coffins.Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Coffin>>> Get(int id)
        {
            Coffin monument = await _ritualbdContext.Coffins.Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).FirstOrDefaultAsync(x => x.CoffinId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Coffin>> Post(Coffin monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Coffins.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Coffin>> Put(Coffin monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Coffins.Any(x => x.CoffinId == monument.CoffinId))
            {
                return NotFound();
            }
            _ritualbdContext.Coffins.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Coffin>> Delete(int id)
        {
            Coffin monument = _ritualbdContext.Coffins.FirstOrDefault(x => x.CoffinId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Coffins.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
