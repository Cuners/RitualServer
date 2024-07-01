using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ClientController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getClients")]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await _ritualbdContext.Clients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Client>>> Get(int id)
        {
            Client monument = await _ritualbdContext.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }
        [HttpGet("search")]
        public async Task<ActionResult<Client>> SearchClient(string name, string email, string phone)
        {
            var client = await _ritualbdContext.Clients
                .FirstOrDefaultAsync(c => c.FIO == name && c.Email == email && c.Telephone == phone);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Clients.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> Put(Client monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Clients.Any(x => x.ClientId == monument.ClientId))
            {
                return NotFound();
            }
            _ritualbdContext.Clients.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            Client monument = _ritualbdContext.Clients.FirstOrDefault(x => x.ClientId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Clients.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
