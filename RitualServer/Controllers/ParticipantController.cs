using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ParticipantController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getParticipants")]
        public async Task<ActionResult<IEnumerable<Participant>>> Get()
        {
            return await _ritualbdContext.Participants.Include(x=>x.Users).Include(x=>x.Conservation).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Participant>>> Get(int id)
        {
            Participant monument = await _ritualbdContext.Participants.FirstOrDefaultAsync(x => x.Id == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Participant>> Post(Participant monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Participants.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Participant>> Put(Participant monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Participants.Any(x => x.Id == monument.Id))
            {
                return NotFound();
            }
            _ritualbdContext.Participants.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Participant>> Delete(int id)
        {
            Participant monument = _ritualbdContext.Participants.FirstOrDefault(x => x.Id == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Participants.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
