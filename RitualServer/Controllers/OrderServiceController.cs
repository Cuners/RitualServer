using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public OrderServiceController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getOrderServices")]
        public async Task<ActionResult<IEnumerable<OrderService>>> Get()
        {
            return await _ritualbdContext.OrderServices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderService>>> Get(int id)
        {
            OrderService monument = await _ritualbdContext.OrderServices.FirstOrDefaultAsync(x => x.OrderServiceId == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderService>>> GetOrder(int idorder)
        {
            OrderService monument = await _ritualbdContext.OrderServices.Include(x => x.Service).Include(x => x.Order).FirstOrDefaultAsync(x => x.OrderId == idorder);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }
        [HttpPost]
        public async Task<ActionResult<OrderService>> Post(OrderService monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.OrderServices.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderService>> Put(OrderService monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.OrderServices.Any(x => x.OrderServiceId == monument.OrderServiceId))
            {
                return NotFound();
            }
            _ritualbdContext.OrderServices.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderService>> Delete(int id)
        {
            OrderService monument = _ritualbdContext.OrderServices.FirstOrDefault(x => x.OrderServiceId == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.OrderServices.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
