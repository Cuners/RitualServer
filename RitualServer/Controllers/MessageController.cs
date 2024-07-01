using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public MessageController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getMessages")]
        public async Task<ActionResult<IEnumerable<Message>>> Get()
        {
            //return await _ritualbdContext.Messages.Include(x=>x.VlozheniaMesses).ToListAsync();
            return await _ritualbdContext.Messages.Include(x => x.VlozheniaMesses).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Message>>> Get(int id)
        {
            Message monument = await _ritualbdContext.Messages.Include(x => x.VlozheniaMesses).FirstOrDefaultAsync(x => x.MessageId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Messages.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Message>> Put(Message monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Messages.Any(x => x.MessageId == monument.MessageId))
            {
                return NotFound();
            }
            _ritualbdContext.Messages.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Message>> Delete(int id)
        {
            Message monument = _ritualbdContext.Messages.FirstOrDefault(x => x.MessageId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Messages.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
