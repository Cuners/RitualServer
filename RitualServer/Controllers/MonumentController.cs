using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;
using System.Reflection.Metadata;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonumentController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public MonumentController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getMonuments")]
        public async Task<ActionResult<IEnumerable<Monument>>> Get()
        {
            return await _ritualbdContext.Monuments.AsNoTracking().AsQueryable().Include(x=>x.Material).Include(x=>x.Color).Include(x=>x.Product).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Monument>>> Get(int id)
        {
            Monument monument = await _ritualbdContext.Monuments.Include(x => x.Material).Include(x => x.Color).Include(x => x.Product).FirstOrDefaultAsync(x => x.MonumentId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Monument>> Post(Monument monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Monuments.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Monument>> Put(Monument monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Monuments.Any(x => x.MonumentId == monument.MonumentId))
            {
                return NotFound();
            }
            _ritualbdContext.Monuments.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Monument>> Delete(int id)
        {
            Monument monument = _ritualbdContext.Monuments.FirstOrDefault(x => x.MonumentId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Monuments.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
