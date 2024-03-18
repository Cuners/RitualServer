using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ColorController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getColors")]
        public async Task<ActionResult<IEnumerable<Color>>> Get()
        {
            return await _ritualbdContext.Colors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Color>>> Get(int id)
        {
            Color monument = await _ritualbdContext.Colors.FirstOrDefaultAsync(x => x.ColorId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Color>> Post(Color monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Colors.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Color>> Put(Color monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Colors.Any(x => x.ColorId == monument.ColorId))
            {
                return NotFound();
            }
            _ritualbdContext.Colors.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> Delete(int id)
        {
            Color monument = _ritualbdContext.Colors.FirstOrDefault(x => x.ColorId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Colors.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
