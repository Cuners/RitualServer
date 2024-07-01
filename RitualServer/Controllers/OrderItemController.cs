using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public OrderItemController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getOrderItems")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> Get()
        {
            return await _ritualbdContext.OrderItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> Get(int id)
        {
            OrderItem monument = await _ritualbdContext.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrder(int idorder)
        {
            OrderItem monument = await _ritualbdContext.OrderItems.Include(x=>x.Product).Include(x=>x.Order).FirstOrDefaultAsync(x => x.OrderId == idorder);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }
        [HttpPost]
        public async Task<ActionResult<OrderItem>> Post(OrderItem monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.OrderItems.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItem>> Put(OrderItem monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.OrderItems.Any(x => x.OrderItemId == monument.OrderItemId))
            {
                return NotFound();
            }
            _ritualbdContext.OrderItems.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItem>> Delete(int id)
        {
            OrderItem monument = _ritualbdContext.OrderItems.FirstOrDefault(x => x.OrderItemId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.OrderItems.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
