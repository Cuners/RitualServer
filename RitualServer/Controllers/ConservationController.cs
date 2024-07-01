using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConservationController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ConservationController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getConservation")]
        public async Task<ActionResult<IEnumerable<Conservation>>> Get()
        {
            return await _ritualbdContext.Conservations.Include(x => x.Participants).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Conservation>>> Get(int id)
        {
            Conservation monument = await _ritualbdContext.Conservations.FirstOrDefaultAsync(x => x.ConservationId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Conservation>> Post(Conservation monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Conservations.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Conservation>> Put(Conservation monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Conservations.Any(x => x.ConservationId == monument.ConservationId))
            {
                return NotFound();
            }
            _ritualbdContext.Conservations.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Conservation>> Delete(int id)
        {
            Conservation monument = _ritualbdContext.Conservations.FirstOrDefault(x => x.ConservationId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Conservations.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
