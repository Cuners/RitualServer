using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public OrderController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await _ritualbdContext.Orders.AsNoTracking().AsQueryable().Include(x => x.Shipments).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get(int id)
        {
            Order monument = await _ritualbdContext.Orders.AsNoTracking().AsQueryable().Include(x=>x.Shipments).FirstOrDefaultAsync(x => x.OrderId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.Orders.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Put(Order monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.Orders.Any(x => x.OrderId == monument.OrderId))
            {
                return NotFound();
            }
            _ritualbdContext.Orders.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            Order monument = _ritualbdContext.Orders.FirstOrDefault(x => x.OrderId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.Orders.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
