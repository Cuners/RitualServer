using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrnController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public UrnController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getUrns")]
        public async Task<ActionResult<IEnumerable<Urn>>> Get()
        {
            return await _ritualbdContext.Urns.AsNoTracking().AsQueryable().Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Urn>>> Get(int id)
        {
            Urn monument = await _ritualbdContext.Urns.Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).FirstOrDefaultAsync(x => x.UrnId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Urn>> Post(Urn monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Urns.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Urn>> Put(Urn monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Urns.Any(x => x.UrnId == monument.UrnId))
            {
                return NotFound();
            }
            _ritualbdContext.Urns.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Urn>> Delete(int id)
        {
            Urn monument = _ritualbdContext.Urns.FirstOrDefault(x => x.UrnId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Urns.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
