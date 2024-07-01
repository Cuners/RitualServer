using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusOrderController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public StatusOrderController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getStatusOrders")]
        public async Task<ActionResult<IEnumerable<StatusOrder>>> Get()
        {
            return await _ritualbdContext.StatusOrders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StatusOrder>>> Get(int id)
        {
            StatusOrder monument = await _ritualbdContext.StatusOrders.FirstOrDefaultAsync(x => x.StatusOrderId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<StatusOrder>> Post(StatusOrder monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.StatusOrders.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StatusOrder>> Put(StatusOrder monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.StatusOrders.Any(x => x.StatusOrderId == monument.StatusOrderId))
            {
                return NotFound();
            }
            _ritualbdContext.StatusOrders.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusOrder>> Delete(int id)
        {
            StatusOrder monument = _ritualbdContext.StatusOrders.FirstOrDefault(x => x.StatusOrderId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.StatusOrders.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
