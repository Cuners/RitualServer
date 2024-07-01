using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientOrderController : Controller
    {
        private RitualbdContext? _ritualbdContext;
        public ClientOrderController(RitualbdContext ritualbdContext)
        {
            _ritualbdContext = ritualbdContext;
        }

        [HttpGet]
        [Route("/getClientOrders")]
        public async Task<ActionResult<IEnumerable<ClientOrder>>> Get()
        {
            return await _ritualbdContext.ClientOrders.Include(x => x.Clients).Include(x => x.Orders).Include(x=>x.Orders.Status).Include(x => x.Orders.Shipments).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ClientOrder>>> Get(int id)
        {
            ClientOrder monument = await _ritualbdContext.ClientOrders.Include(x => x.Clients).Include(x => x.Orders).Include(x => x.Orders.Status).Include(x => x.Orders.Shipments).FirstOrDefaultAsync(x => x.ClientOrdersID == id);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientOrder>>> GetOrder(int idorder)
        {
            ClientOrder monument = await _ritualbdContext.ClientOrders.Include(x => x.Clients).Include(x => x.Orders).Include(x => x.Orders.Status).Include(x => x.Orders.Shipments).FirstOrDefaultAsync(x => x.OrderID == idorder);
            if (monument == null)
                return NotFound();
            return new ObjectResult(monument);
        }

        [HttpPost]
        public async Task<ActionResult<ClientOrder>> Post(ClientOrder monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            _ritualbdContext.ClientOrders.Add(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientOrder>> Put(ClientOrder monument)
        {
            if (monument == null)
            {
                return BadRequest();
            }
            if (!_ritualbdContext.ClientOrders.Any(x => x.ClientOrdersID == monument.ClientOrdersID))
            {
                return NotFound();
            }
            _ritualbdContext.ClientOrders.Update(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientOrder>> Delete(int id)
        {
            ClientOrder monument = _ritualbdContext.ClientOrders.FirstOrDefault(x => x.ClientOrdersID == id);
            if (monument == null)
            {
                return NotFound();
            }
            _ritualbdContext.ClientOrders.Remove(monument);
            await _ritualbdContext.SaveChangesAsync();
            return Ok(monument);
        }
    }
}
